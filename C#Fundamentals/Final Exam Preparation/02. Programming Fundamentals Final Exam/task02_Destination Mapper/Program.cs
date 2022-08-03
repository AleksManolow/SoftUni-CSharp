using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace task02_Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"([=|\/])[A-Z][A-z]{2,}\1";
            int pointToTravel = 0;

            List<string> destinations = new List<string>();
            MatchCollection matches = Regex.Matches(text, pattern);
            foreach (Match match in matches)
            {
                destinations.Add(match.ToString().Substring(1, match.ToString().Length - 2));
                pointToTravel += match.ToString().Substring(1, match.ToString().Length - 2).Length;
            }
            
            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {pointToTravel}");
        }
    }
}
