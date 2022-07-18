using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace task02_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> players = new Dictionary<string, int>();
            List<string> names = Console.ReadLine().Split(", ").ToList();
            string patternName = @"[A-Za-z]+";
            string patternDigits = @"\d+";
            string input = Console.ReadLine();
            while (input != "end of race")
            {
                MatchCollection matchesName = Regex.Matches(input, patternName);
                MatchCollection matchesDigits = Regex.Matches(input, patternDigits);

                string name = string.Join("", matchesName);
                string digtis = string.Join("", matchesDigits);

                int sumDigits = 0;
                foreach (char digit in digtis)
                {
                    sumDigits += int.Parse(digit.ToString());
                }

                if (names.Contains(name))
                {
                    if (!players.ContainsKey(name))
                    {
                        players.Add(name, 0);
                    }
                    players[name] += sumDigits;
                }
                input = Console.ReadLine();
            }
            Dictionary<string, int> winners = players.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            int count = 1;
            foreach (var winner in winners)
            {
                if (count == 1)
                {
                    Console.WriteLine($"1st place: {winner.Key}");
                }
                else if (count == 2)
                {
                    Console.WriteLine($"2nd place: {winner.Key}");
                }
                else if (count == 3)
                {
                    Console.WriteLine($"3rd place: {winner.Key}");
                }
                else
                {
                    break;
                }
                count++;
            }
        }

    }
}
