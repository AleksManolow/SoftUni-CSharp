using System;
using System.Text.RegularExpressions;

namespace task02_Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([\||\#])(?<itemName>[A-z\s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d+)\1";
            string text = Console.ReadLine();

            MatchCollection matches = Regex.Matches(text, pattern);
            int sumCal = 0;
            foreach (Match matche in matches)
            {
                sumCal += int.Parse(matche.Groups["calories"].Value);
            }
            Console.WriteLine($"You have food to last you for: {sumCal / 2000} days!");
            foreach (Match matche in matches)
            {
                Console.WriteLine($"Item: {matche.Groups["itemName"].Value}, " +
                    $"Best before: {matche.Groups["date"].Value}, " +
                    $"Nutrition: {matche.Groups["calories"].Value}");
            }
        }
    }
}
