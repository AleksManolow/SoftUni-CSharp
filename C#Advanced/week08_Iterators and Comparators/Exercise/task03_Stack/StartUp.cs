﻿using System;
using System.Linq;

namespace task03_Stack
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var stack = new Stack<int>();

            while (input != "END")
            {
                if (input.Contains("Push"))
                {
                    string[] elements = input
                        .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Skip(1).ToArray();

                    foreach (string element in elements)
                    {
                        stack.Push(int.Parse(element));
                    }
                }
                else if (input == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var number in stack)
            {
                Console.WriteLine(number);
            }

            foreach (var number in stack)
            {
                Console.WriteLine(number);
            }
        }
    }
}
