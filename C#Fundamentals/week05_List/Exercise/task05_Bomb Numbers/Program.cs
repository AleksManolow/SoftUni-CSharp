using System;
using System.Collections.Generic;
using System.Linq;

namespace task05_Bomb_Numbers
{
    class Program
    {

        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int []command = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bomb = command[0];
            int power = command[1];
                
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bomb)
                {
                    bombNumber(numbers, power, i);
                }
            }
            Console.WriteLine(numbers.Sum());
        }

        private static void bombNumber(List<int> numbers, int power, int i)
        {
            int start = Math.Max(i - power, 0);
            int end = Math.Min(power + i, numbers.Count - 1);
            for (int k = start; k <= end; k++)
            {
                numbers[k] = 0;
            }
        }
    }
}
