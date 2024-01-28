namespace MusicHub
{
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here

            //Console.WriteLine(ExportAlbumsInfo(context, 9));

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumInfo = context.Producers
                .Include(x => x.Albums)
                    .ThenInclude(a => a.Songs)
                    .ThenInclude(s => s.Writer) //This is done for creating the nested Fluent API and how to execute it
                .FirstOrDefault(x => x.Id == producerId)
                .Albums.Select(x => new
                {
                    AlbumName = x.Name,
                    ReleaseDate = x.ReleaseDate,
                    ProducerName = x.Producer.Name,
                    AlbumSongs = x.Songs.Select(x => new
                    {
                        SongName = x.Name,
                        SongPrice = x.Price,
                        SongWriterName = x.Writer.Name
                    }).OrderByDescending(x => x.SongName)
                        .ThenBy(x => x.SongWriterName),
                    TotalAlbumPrice = x.Price
                }).OrderByDescending(x => x.TotalAlbumPrice).AsEnumerable();

            StringBuilder sb = new StringBuilder();

            foreach (var album in albumInfo)
            {
                sb.AppendLine($"-AlbumnName: {album.AlbumName}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}")
                    .AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");

                if (album.AlbumSongs.Any())
                {
                    int counter = 1;

                    foreach (var song in album.AlbumSongs)
                    {
                        sb.AppendLine($"---#{counter++}")
                            .AppendLine($"---SongName: {song.SongName}")
                            .AppendLine($"---SongPrice: {song.SongPrice:f2}")
                            .AppendLine($"---SongName: {song.SongWriterName}");
                    }
                }

                sb.AppendLine($"-AlbumPrice: {album.TotalAlbumPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Include(s => s.SongsPerformers)
                    .ThenInclude(sp => sp.Performer)
                .Include(s => s.Writer)
                .Include(s => s.Album)
                    .ThenInclude(p => p.Producer)
                .ToList()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    SongWriter = s.Writer.Name,
                    Performers = s.SongsPerformers
                                .Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName)
                                .ToList(),
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.SongWriter);

            int counter = 1;

            StringBuilder sb = new StringBuilder();
            
            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{counter++}")
                .AppendLine($"---SongName: {song.SongName}")
                .AppendLine($"---Writer: {song.SongWriter}")
                .AppendLine($"---Album Producer: {song.AlbumProducer}")
                .AppendLine($"---Duration: {song.Duration}");

                if (song.Performers.Any())
                {
                    sb.AppendLine($"---Performer: {string.Join(", ", song.Performers)}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
