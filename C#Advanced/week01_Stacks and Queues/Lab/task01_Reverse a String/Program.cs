using System;
using System.Collections.Generic;

namespace task01_Reverse_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> reverseString = new Stack<char>();
            foreach (char c in input)
            {
                reverseString.Push(c);
            }

            while (reverseString.Count > 0)
            {
                Console.Write(reverseString.Pop());
            }
        }
    }
}
