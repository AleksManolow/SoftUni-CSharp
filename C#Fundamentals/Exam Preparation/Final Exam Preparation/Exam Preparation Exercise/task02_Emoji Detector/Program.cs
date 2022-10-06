using System;
using System.Text.RegularExpressions;

namespace task02_Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattternCoolThreshold = @"\d";
            string patternEmojis = @"([:|*])\1[A-Z][a-z]{2,}\1\1";

            string text = Console.ReadLine();

            MatchCollection matchesCoolThreshold = Regex.Matches(text,pattternCoolThreshold);
            MatchCollection matchesEmojis = Regex.Matches(text,patternEmojis);
            int coolThreshold = 1;
            foreach (Match item in matchesCoolThreshold)
            {
                coolThreshold *= int.Parse(item.ToString());
            }
            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{matchesEmojis.Count} emojis found in the text. The cool ones are:");
            foreach (Match emoji in matchesEmojis)
            {
                string tempEmoji = emoji.ToString();
                int sumCharEmoji = 0;
                for (int i = 2; i < tempEmoji.Length - 2; i++)
                {
                    sumCharEmoji += (int)tempEmoji[i];
                }

                if (sumCharEmoji >= coolThreshold)
                {
                    Console.WriteLine($"{tempEmoji}");
                }
            }
        }
    }
}
