using System;
using System.Collections.Generic;
using System.Linq;

namespace task05_Print_Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> elements = new Queue<int>(numbers.Where(x => x % 2 == 0).ToArray());
            Console.WriteLine(string.Join(", ", elements));
        }
    }
}
