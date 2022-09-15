using System;
using System.Collections.Generic;
using System.Linq;

namespace task09_Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> memory = new Stack<string>();
            memory.Push(string.Empty);
            string text = string.Empty;
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                if (input[0] == "1")
                {
                    text += input[1];
                    memory.Push(text);
                }
                else if (input[0] == "2")
                {
                    text = text.Remove(text.Length - int.Parse(input[1]), int.Parse(input[1]));
                    memory.Push(text);
                }
                else if (input[0] == "3")
                {
                    int index = int.Parse(input[1]);
                    if (index > 0 && index <= text.Length)
                    {
                        Console.WriteLine(text[index - 1]);
                    }
                }
                else if (input[0] == "4")
                {
                    memory.Pop();
                    text = memory.Peek();
                }
            }
        }
    }
}
