using System;

namespace task01_Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases =
            {
                "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can't live without this product."
            };
            string[] events =
            {
                "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"
            };
            string[] authors =
            {
                "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"
            };
            string[] cities =
            {
                "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"
            };

            int n = int.Parse(Console.ReadLine());
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {

                int pos1 = rnd.Next(phrases.Length);
                int pos2 = rnd.Next(events.Length);
                int pos3 = rnd.Next(authors.Length);
                int pos4 = rnd.Next(cities.Length);

                Console.WriteLine($"{phrases[pos1]}{events[pos2]} {authors[pos3]} – {cities[pos4]}.");
            }
        }
    }
}
