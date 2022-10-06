using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace task02_Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@#+[A-Z][A-Za-z0-9]{4,}[A-Z]@#+";
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();
                Regex regexBarcode = new Regex(pattern);
                if (regexBarcode.IsMatch(barcode))
                {
                    //string patternGroup = @"\d";
                    MatchCollection matches = Regex.Matches(barcode, @"\d");
                    if (matches.Count != 0)
                    {
                        Console.WriteLine($"Product group: {string.Join("", matches)}");
                    }
                    else
                    {
                        Console.WriteLine("Product group: 00");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
