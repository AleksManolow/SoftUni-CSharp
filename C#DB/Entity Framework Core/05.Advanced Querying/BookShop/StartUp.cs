namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            string ageRestriction = Console.ReadLine();
            string result = GetBooksByAgeRestriction(db, ageRestriction);
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
    }
}


