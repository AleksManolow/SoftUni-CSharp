using System;
using System.Collections.Generic;
using System.Linq;

namespace task02_Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> fisrtSet = new HashSet<int>();
            HashSet<int> secoundSet = new HashSet<int>();

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = numbers[0];
            int m = numbers[1];
            for (int i = 0; i < n; i++)
            {
                fisrtSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < m; i++)
            {
                secoundSet.Add(int.Parse(Console.ReadLine()));
            }

            foreach (var item in fisrtSet)
            {
                if (secoundSet.Contains(item))
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}
