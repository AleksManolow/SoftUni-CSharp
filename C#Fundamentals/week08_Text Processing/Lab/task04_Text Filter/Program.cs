using System;

namespace task04_Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(new char[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            foreach (var words in bannedWords)
            {
                text = text.Replace(words, new string('*', words.Length));
            }
            Console.WriteLine(text);
        }
    }
}
