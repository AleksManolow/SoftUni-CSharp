using System;
using System.Collections.Generic;
using System.Linq;

namespace task02_Basic_Queue_Operations
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
            Queue<int> numberQueue = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                numberQueue.Enqueue(numbers[i]);
            }
            for (int i = 0; i < s; i++)
            {
                numberQueue.Dequeue();
            }

            if (numberQueue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (numberQueue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numberQueue.Min());
            }
        }
    }
}
