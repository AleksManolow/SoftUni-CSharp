using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace task07_Custom_Comparator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Array.Sort(array);
            var sortedArray = array.OrderBy(number => number % 2 != 0).ThenBy(number => number % 2 == 0);
            Console.WriteLine(string.Join(' ', array));
        }
    }
}
