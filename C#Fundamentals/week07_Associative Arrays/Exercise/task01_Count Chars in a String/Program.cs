using System;
using System.Collections.Generic;

namespace task01_Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> numberOfOccurrencesOfLetters = new Dictionary<char, int>();
            string[] words = Console.ReadLine().Split();
            foreach (string word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (!numberOfOccurrencesOfLetters.ContainsKey(word[i]))
                    {
                        numberOfOccurrencesOfLetters.Add(word[i], 0);
                    }
                    numberOfOccurrencesOfLetters[word[i]]++;
                }
            }

            foreach (var item in numberOfOccurrencesOfLetters)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
