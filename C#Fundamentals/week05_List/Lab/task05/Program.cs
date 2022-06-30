using System;
using System.Collections.Generic;
using System.Linq;

namespace task05
{
    class Program
    {

        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            numbers.RemoveAll(num => num < 0);
            numbers.Reverse();
            if (numbers.Count == 0)
            { 
                Console.WriteLine("empty");
                return;
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
