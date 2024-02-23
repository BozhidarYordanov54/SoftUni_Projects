namespace SeminarHub.Models
{
    public class SeminarInfoViewModel
    {
        public SeminarInfoViewModel(int id, string topic, string lecturer, string details, string category, DateTime startingTime, string organizer)
        {
            Id = id;
            Topic = topic;
            Lecturer = lecturer;
            Details = details;
            Category = category;
            StartingTime = startingTime;
            Organizer = organizer;

        }

        public int Id { get; set; }
        public string Topic { get; set; }
        public string Lecturer { get; set; }
        public string Details { get; set; }
        public string Category { get; set; }
        public DateTime StartingTime { get; set; }
        public string Organizer { get; set; }

    }
}
