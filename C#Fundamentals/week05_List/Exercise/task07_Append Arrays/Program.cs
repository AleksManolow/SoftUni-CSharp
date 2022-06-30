using System;
using System.Collections.Generic;
using System.Linq;

namespace task07_Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numberAsString = Console.ReadLine().Split('|').ToList();
            numberAsString.Reverse();
            List<int> numbers = new List<int>();
            foreach (var item in numberAsString)
            {
                numbers.AddRange(item.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
