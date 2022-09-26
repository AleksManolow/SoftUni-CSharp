using System;
using System.Linq;

namespace task03_Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minEl = x => x.Min();
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine(minEl(numbers));
        }
    }
}
