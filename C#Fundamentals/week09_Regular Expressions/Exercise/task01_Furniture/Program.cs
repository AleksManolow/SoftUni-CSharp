using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace task01_Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[>]{2}(?<name>[A-Za-z]+)[<]{2}(?<price>\d+(.\d+)?)\!(?<quantity>\d+)";
            string input = Console.ReadLine();

            List<string> names = new List<string>();
            double totalPrice = 0;
            while (input != "Purchase")
            {
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    names.Add(match.Groups["name"].Value);
                    totalPrice += (double.Parse(match.Groups["price"].Value) * double.Parse(match.Groups["quantity"].Value));
                }

                input = Console.ReadLine();
            }
            Console.WriteLine("Bought furniture:");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine($"Total money spend: {totalPrice:F2}");
        }
    }
}
