using System;
using System.Collections.Generic;

namespace task02_Generic_Box_of_Integer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Box<int>> list = new List<Box<int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                list.Add(new Box<int>(input));
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
