using System;
using System.Collections.Generic;
using System.Linq;

namespace task04_Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string command = Console.ReadLine();

            List<int> list = new List<int>();

            for (int i = input[0]; i <= input[1]; i++)
            {
                list.Add(i);
            }            

            Predicate<int> isOdd = x => x % 2 != 0;
            Predicate<int> isEven = x => x % 2 == 0;
            if (command == "odd")
            {
                list = list.FindAll(isOdd);
            }
            else
            {
                list = list.FindAll(isEven);
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
