using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace task01_Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputElements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Stack<int> task = new Stack<int>(inputElements);
            inputElements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> thread = new Queue<int>(inputElements);
            int killValue = int.Parse(Console.ReadLine());

            while (task.Any() && thread.Any())
            {
                if (task.Peek() == killValue)
                {
                    
                    Console.WriteLine($"Thread with value {thread.Peek()} killed task {killValue}");
                    break;
                }

                if (thread.Peek() >= task.Peek())
                {
                    thread.Dequeue();
                    task.Pop();
                }
                else
                {
                    thread.Dequeue();
                }
            }
            Console.WriteLine(string.Join(" ", thread.ToArray()));

        }
    }
}
