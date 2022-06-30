using System;
using System.Collections.Generic;

namespace task04
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            List<string> names = new List<string>();
            for (int i = 0; i < size; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
            }
            names.Sort();
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"{i + 1}.{names[i]}");
            }
        }
    }
}
