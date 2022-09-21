using System;
using System.Collections.Generic;
using System.Linq;

namespace task04_Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbersCount = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!numbersCount.ContainsKey(number))
                {
                    numbersCount.Add(number, 0);
                }
                numbersCount[number]++;
            }
            numbersCount = numbersCount.Where(x => x.Value % 2 == 0).ToDictionary(x => x.Key, x => x.Value);
            foreach (int number in numbersCount.Keys)
                Console.WriteLine(number);

        }
    }
}
