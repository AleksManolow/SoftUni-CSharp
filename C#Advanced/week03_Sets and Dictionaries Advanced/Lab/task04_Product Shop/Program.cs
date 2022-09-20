using System;
using System.Collections.Generic;
using System.Linq;

namespace task04_Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> map = new Dictionary<string, Dictionary<string, double>>();

            string[] input = Console.ReadLine().Split(", ");
            while (input[0] != "Revision")
            {
                string shopName = input[0];
                string productName = input[1];
                double price = double.Parse(input[2]);
                if (!map.ContainsKey(shopName))
                {
                    map.Add(shopName, new Dictionary<string, double>());
                }
                map[shopName].Add(productName, price);
                input = Console.ReadLine().Split(", ");
            }
            map = map.OrderBy(x => x.Key).ToDictionary(x => x.Key, x=> x.Value);

            foreach (var item in map)
            {
                Console.WriteLine($"{item.Key}->");
                foreach (var d in item.Value)
                {
                    Console.WriteLine($"Product: {d.Key}, Price: {d.Value}");
                }

            }
        }
    }
}
