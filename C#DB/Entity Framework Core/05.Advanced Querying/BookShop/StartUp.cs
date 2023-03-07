namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Globalization;
    using System.Text;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            /*string ageRestriction = Console.ReadLine();
            string result = GetBooksByAgeRestriction(db, ageRestriction);
            Console.WriteLine(result);*/

            /*string result = GetGoldenBooks(db);
            Console.WriteLine(result);*/

            /*string result = GetBooksByPrice(db);
            Console.WriteLine(result);*/

            /*int year = int.Parse(Console.ReadLine());
            string result = GetBooksNotReleasedIn(db, year);
            Console.WriteLine(result);*/

            /*string input = Console.ReadLine();
            string result = GetBooksByCategory(db, input);
            Console.WriteLine(result);*/

            /*string input = Console.ReadLine();
            string result = GetBooksReleasedBefore(db, input);
            Console.WriteLine(result);*/

            /*string input = Console.ReadLine();
            string result = GetAuthorNamesEndingIn(db, input);
            Console.WriteLine(result);*/

            /*string input = Console.ReadLine();
            string result = GetBookTitlesContaining(db, input);
            Console.WriteLine(result);*/

            /*string input = Console.ReadLine();
            string result = GetBooksByAuthor(db, input);
            Console.WriteLine(result);*/

            /*int lengthTitile = int.Parse(Console.ReadLine());
            Console.WriteLine(CountBooks(db, lengthTitile));*/

            /*string result = CountCopiesByAuthor(db);
            Console.WriteLine(result);*/

            string result = GetTotalProfitByCategory(db);
            Console.WriteLine(result);
        }
        //Task 02
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction;

            var isParseSuccess = Enum.TryParse<AgeRestriction>(command, true, out ageRestriction);

            if (!isParseSuccess)
            {
                return string.Empty;
            }

            string[] bookTitles = context
                .Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }
        //Task03
        public static string GetGoldenBooks(BookShopContext context)
        {
            EditionType editionType;

            var isParseSuccess = Enum.TryParse<EditionType>("Gold", true, out editionType);

            var bookTitles = context.Books
                .Where(b => b.EditionType == editionType && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();
            return string.Join(Environment.NewLine, bookTitles);    
        }
        //Task04
        public static string GetBooksByPrice(BookShopContext context)
        {
            var bookTitlesAndPrice = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                     b.Title,
                     b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var book in bookTitlesAndPrice)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }
            return sb.ToString().TrimEnd();
        }
        //Task05
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var bookTitle = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();
            return string.Join(Environment.NewLine, bookTitle);
        }
        //Task06
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var bookTitle = context.Books
                .Where(b => b.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitle);
        }
        //Task07
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < parsedDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }
            return sb.ToString().TrimEnd();
        }
        //Task08
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray()
                .OrderBy(a => a)
                .ToArray();

            return string.Join(Environment.NewLine, authors);
        }
        //Task09
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var bookTitles = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();
            return string.Join(Environment.NewLine, bookTitles);
        }
        //Task10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToArray();
            return string.Join(Environment.NewLine, books);
        }
        //Task11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books.Where(b => b.Title.Length > lengthCheck).Count();
        }
        //Task12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authers = context.Authors
                .OrderByDescending(a => a.Books.Sum(b => b.Copies))
                .Select(a => $"{a.FirstName} {a.LastName} - {a.Books.Sum(b => b.Copies)}")
                .ToArray();
            return string.Join(Environment.NewLine, authers);
        }
        //Task13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            var profitsByCategory = context
                .Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Profit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)

                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.CategoryName)
                .ToArray();

            foreach (var c in profitsByCategory)
            {
                output.AppendLine($"{c.CategoryName} ${c.Profit:f2}");
            }

            return output.ToString().TrimEnd();
        }

    }
}


