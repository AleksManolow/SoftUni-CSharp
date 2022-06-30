using System;

namespace task02
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            Console.WriteLine(SearchForVowles(input));
        }
        static int SearchForVowles(string text)
        {
            int count = 0;
            foreach (char vowle in text)
            {
                if ("aouei".Contains(vowle))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
