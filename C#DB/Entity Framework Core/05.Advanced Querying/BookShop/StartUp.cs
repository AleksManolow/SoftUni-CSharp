namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Text;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            /*string ageRestriction = Console.ReadLine();
            string result = GetBooksByAgeRestriction(db, ageRestriction);
            Console.WriteLine(result);*/

            /*string result = GetGoldenBooks(db);
            Console.WriteLine(result);*/

            string result = GetBooksByPrice(db);
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
    }
}


