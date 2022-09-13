using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace task02_Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNum = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Stack<int> numbers = new Stack<int>(inputNum);
            string command = Console.ReadLine().ToLower();
            while (command != "end")
            {
                string[] commadnItems = command.Split(' ');
                if (commadnItems[0] == "add")
                {
                    numbers.Push(int.Parse(commadnItems[1]));
                    numbers.Push(int.Parse(commadnItems[2]));
                }
                else if (commadnItems[0] == "remove" && numbers.Count > int.Parse(commadnItems[1]))
                {
                    for (int i = 0; i < int.Parse(commadnItems[1]); i++)
                    {
                        numbers.Pop();
                    }
                }
                command = Console.ReadLine().ToLower();
            }
            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
