using System;
using System.Collections.Generic;

namespace task03_Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                string keyWord = Console.ReadLine();
                string valueWord = Console.ReadLine();

                if (!words.ContainsKey(keyWord))
                {
                    words.Add(keyWord, new List<string>());
                }
                words[keyWord].Add(valueWord);
            }
            foreach (var word in words)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");
            }
        }
    }
}
