using System;
using System.Collections.Generic;
using System.Linq;

namespace task01_Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int n = input[0];
            int s = input[1];
            int x = input[2];

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Stack<int> numberStack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                numberStack.Push(numbers[i]);
            }
            for (int i = 0; i < s; i++)
            {
                numberStack.Pop();
            }

            if (numberStack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (numberStack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numberStack.Min());
            }
        }
    }
}
