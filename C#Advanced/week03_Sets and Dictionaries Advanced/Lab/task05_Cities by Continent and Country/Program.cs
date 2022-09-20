using System;
using System.Collections.Generic;

namespace task05_Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> dic = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!dic.ContainsKey(continent))
                {
                    dic.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!dic[continent].ContainsKey(country))
                {
                    dic[continent].Add(country, new List<string>());
                }
                dic[continent][country].Add(city);
            }

            foreach (var d in dic)
            {
                Console.WriteLine($"{d.Key}:");
                foreach (var k in d.Value)
                {
                    Console.Write($"{k.Key} -> ");
                    Console.WriteLine(string.Join(", ", k.Value));
                }       
            }
        }
    }
}
