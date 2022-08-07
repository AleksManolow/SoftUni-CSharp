using System;
using System.Text.RegularExpressions;

namespace task02_Message_Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\$|\%)(?<tag>[A-Z][a-z]{3,})\1: \[(?<fNum>\d+){1}\]\|\[(?<sNum>\d+){1}\]\|\[(?<tNum>\d+){1}\]\|";
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);

                if (match.Success && match.ToString().Length == input.Length)
                {
                    Console.WriteLine($"{match.Groups["tag"].Value}: {(char)int.Parse(match.Groups["fNum"].Value)}{(char)int.Parse(match.Groups["sNum"].Value)}{(char)int.Parse(match.Groups["tNum"].Value)}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
            
        }
    }
}
