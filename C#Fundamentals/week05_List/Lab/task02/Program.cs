using System;
using System.Collections.Generic;
using System.Linq;

namespace task02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();
            int size = numbers.Count;
            for (int i = 0; i < size / 2; i++)
            {
                numbers[i] += numbers[size - 1 - i];
                numbers.RemoveAt(size - 1 - i);
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}