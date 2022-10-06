using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace task02_Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> pairsOfWords = new Dictionary<string, string>();
            string pattern = @"([#|@])[A-z]{3,}\1\1[A-z]{3,}\1";
            string text = Console.ReadLine();

            MatchCollection matches = Regex.Matches(text, pattern);
            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }
            foreach (Match match in matches)
            {
                char[] delimiters = { '@', '#' };
                string tempStr = match.ToString();
                string[] pairToStringArr = tempStr.Split(delimiters);
                string reverse = "";
                for (int i = pairToStringArr[3].Length - 1; i >= 0; i--)
                {
                    reverse += pairToStringArr[3][i];
                }
                if (pairToStringArr[1] == reverse)
                {
                    pairsOfWords.Add(pairToStringArr[1], pairToStringArr[3]);
                }
            }
            
            if (pairsOfWords.Count != 0)
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", pairsOfWords.Select(x => x.Key + " <=> " + x.Value).ToArray()));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }



        }
    }
}
