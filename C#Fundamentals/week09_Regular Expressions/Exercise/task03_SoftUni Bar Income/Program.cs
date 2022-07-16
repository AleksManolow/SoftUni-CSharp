using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace task03_SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<customer>[A-Z][a-z]+)%[^%$|.]*?<(?<product>\w+)>[^%$|.]*?\|(?<count>\d+)\|[^%$|.]*?(?<price>\d+(.\d+)?)\$";
            string input = Console.ReadLine();

            double totalPrice = 0;
            while (input != "end of shift")
            {
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    Console.WriteLine($"{match.Groups["customer"].Value}: " +
                        $"{match.Groups["product"].Value} - " +
                        $"{(int.Parse(match.Groups["count"].Value) * double.Parse(match.Groups["price"].Value)):F2}");
                    totalPrice += (int.Parse(match.Groups["count"].Value) * double.Parse(match.Groups["price"].Value));
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalPrice:F2}");
        }
    }
}
