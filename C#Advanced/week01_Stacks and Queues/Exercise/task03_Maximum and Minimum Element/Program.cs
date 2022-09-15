using System;
using System.Collections.Generic;
using System.Linq;

namespace task03_Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> elementsStack = new Stack<int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (input[0] == 1)
                {
                    elementsStack.Push(input[1]);
                }
                else if (input[0] == 2 && elementsStack.Count > 0)
                {
                    elementsStack.Pop();
                }
                else if (input[0] == 3 && elementsStack.Count > 0)
                {
                    Console.WriteLine(elementsStack.Max());
                }
                else if (input[0] == 4 && elementsStack.Count > 0)
                {
                    Console.WriteLine(elementsStack.Min());
                }
            }
            Console.WriteLine(string.Join(", ", elementsStack));
        }
    }
}
