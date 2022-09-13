using System;
using System.Collections.Generic;

namespace task04_Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string mathExpresion = Console.ReadLine();
            Stack<int> bracketIndex = new Stack<int>();
            for (int i = 0; i < mathExpresion.Length; i++)
            {
                if(mathExpresion[i] == '(')
                {
                    bracketIndex.Push(i);
                }
                else if (mathExpresion[i] == ')')
                {
                    int startIndex = bracketIndex.Pop();
                    Console.WriteLine(mathExpresion.Substring(startIndex, i - startIndex + 1));
                }
            }
        }
    }
}
