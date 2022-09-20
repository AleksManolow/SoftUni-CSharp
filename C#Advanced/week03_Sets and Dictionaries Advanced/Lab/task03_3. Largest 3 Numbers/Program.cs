using System;
using System.Linq;

namespace task03__Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Array.ForEach(Console.ReadLine().
                Split(' ').
                Select(int.Parse).
                ToArray().
                OrderByDescending(x => x).
                Take(3).
                ToArray(), 
                x => Console.Write(x + " "));
        }
    }
}
