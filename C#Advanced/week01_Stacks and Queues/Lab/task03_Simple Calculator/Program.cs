using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace task03_Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            Stack<string> calcStack = new Stack<string>(input.Reverse());
            int resultCalc = int.Parse(calcStack.Pop());

            while (calcStack.Count > 0)
            {
                string temp = calcStack.Pop();
                if (temp == "+")
                {
                    resultCalc += int.Parse(calcStack.Pop());
                }
                else if (temp == "-")
                {
                    resultCalc -= int.Parse(calcStack.Pop());
                }
            }
            Console.WriteLine(resultCalc);
        }
    }
}
