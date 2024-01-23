namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
            Console.WriteLine();

            //Console.WriteLine(CountBooks(db, 40));

            Console.WriteLine(CountCopiesByAuthor(db));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            if (Enum.TryParse<AgeRestriction>(command, true, out var ageRestriction))
            {

            }

            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold &&
                            b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - ${b.Price:f2}"));
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                .Select(b => new
                {
                    b.Title,
                    b.ReleaseDate
                })
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToArray();

            var books = context.Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                    b.ReleaseDate
                })
                .OrderByDescending(b => b.ReleaseDate)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - {b.EditionType} - {b.Price}"));
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var books = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                   FullName = a.FirstName + " " + a.LastName 
                })
                .OrderBy(a => a.FullName)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(a => a.FullName));
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.Contains(input.ToLower()))
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy (b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.StartsWith(input))
                .Select(b => new
                {
                    b.Title,
                    b.Author.FirstName,
                    b.Author.LastName
                })
                .ToList();


            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} ({b.FirstName} {b.LastName})"));
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var bookCount = context.Books
                .Where(b => b.Title.Length > lengthCheck);

            return bookCount.Count();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var bookCount = context.Authors
                .Select(a => new
                {
                    AuthorFullName = string.Join(Environment.NewLine, a.FirstName + " " + a.LastName),
                    TotalBooksByAuthor = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.TotalBooksByAuthor)
                .ToList();

            return string.Join(Environment.NewLine, bookCount.Select(a => $"{a.AuthorFullName} - {a.TotalBooksByAuthor}"));
        }
    }
}


