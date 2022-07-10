using System;
using System.Collections.Generic;

namespace task02_A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> collection = new Dictionary<string, int>();
            while (true)
            {
                string resource = Console.ReadLine();
                if (resource == "stop")
                {
                    break;
                }
                int quantity = int.Parse(Console.ReadLine());

                if (!collection.ContainsKey(resource))
                {
                    collection.Add(resource, 0);
                }
                collection[resource] += quantity;
            }
            foreach (var item in collection)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
