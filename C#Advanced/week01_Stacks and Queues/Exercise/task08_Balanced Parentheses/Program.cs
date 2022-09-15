using System;
using System.Collections.Generic;

namespace task08_Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> parentheses = new Stack<char>();
            foreach (var item in input)
            {
                if (item == '{' || item == '[' || item == '(')
                {
                    parentheses.Push(item);
                }
                else if((item == '}' || item == ']' || item == ')') && parentheses.Count > 0)
                {
                    if (parentheses.Peek() == '{' && item == '}')
                    {
                        parentheses.Pop();
                    }
                    else if (parentheses.Peek() == '[' && item == ']')
                    {
                        parentheses.Pop();
                    }
                    else if (parentheses.Peek() == '(' && item == ')')
                    {
                        parentheses.Pop();
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    parentheses.Push(item);
                }
            }
            if (parentheses.Count > 0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }

        }
    }
}
