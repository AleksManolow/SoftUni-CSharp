using System;
using System.Collections.Generic;
using System.Linq;

namespace task04_Generic_Swap_Method_Integer
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            List<int> list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int input = Convert.ToInt32(Console.ReadLine());
                list.Add(input);
            }

            var box = new Box<int>(list);
            int[] indexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            box.Swap(list, indexes[0], indexes[1]);
            Console.WriteLine(box);
        }
    }
}
