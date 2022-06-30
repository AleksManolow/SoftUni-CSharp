using System;
using System.Collections.Generic;
using System.Linq;

namespace task03_House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            int count = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (names.Contains(input[0]) && input[2] == "going!")
                {
                    Console.WriteLine($"{input[0]} is already in the list!");
                }
                else if (!names.Contains(input[0]) && input[2] == "not")
                {
                    Console.WriteLine($"{input[0]} is not in the list!");
                }
                else if (input[2] == "not")
                {
                    names.Remove(input[0]);
                }
                else
                {
                    names.Add(input[0]);
                }
            }
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

        }
    }
}
