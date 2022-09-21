using System;
using System.Collections.Generic;

namespace task01_Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> collection = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                collection.Add(Console.ReadLine());
            }
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
