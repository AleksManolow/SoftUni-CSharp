using System;
using System.Collections.Generic;

namespace task03_Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> orders = new Dictionary<string, double>();
            Dictionary<string, int> newOrders = new Dictionary<string, int>();
            string[] input = Console.ReadLine().Split();
            while (input[0] != "buy")
            {
                if (!orders.ContainsKey(input[0]) && !newOrders.ContainsKey(input[0]))
                {
                    orders.Add(input[0], 0);
                    newOrders.Add(input[0], 0);
                }
                orders[input[0]] = double.Parse(input[1]);
                newOrders[input[0]] += int.Parse(input[2]);
                input = Console.ReadLine().Split();
            }
            foreach (var item in orders)
            {
                Console.WriteLine($"{item.Key} -> {newOrders[item.Key] * item.Value:F2}");
            }
        }
    }
}
