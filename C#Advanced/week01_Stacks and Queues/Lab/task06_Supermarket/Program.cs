using System;
using System.Collections.Generic;
using System.Linq;

namespace task06_Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> names = new Queue<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Paid")
                {
                    while (names.Count > 0)
                    {
                        Console.WriteLine(names.Dequeue());
                    }
                    continue;
                }
                else if (input == "End")
                {
                    Console.WriteLine($"{names.Count} people remaining.");
                    break;
                }
                names.Enqueue(input);
            }
        }
    }
}
