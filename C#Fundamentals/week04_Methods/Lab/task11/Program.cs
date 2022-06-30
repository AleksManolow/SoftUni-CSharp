using System;

namespace task11
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            string op = Console.ReadLine();
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine(calculate(a, op, b));
        }
        static int calculate(int a, string op, int b)
        {
            int result = 0;

            switch (op)
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "/":
                    result = a / b;
                    break;
                case "*":
                    result = a * b;
                    break;
            }

            return result;
        }
    }
}
