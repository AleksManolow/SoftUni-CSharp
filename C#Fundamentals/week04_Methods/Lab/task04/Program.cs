using System;

namespace task04
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i <= n; i++)
            {
                printLine(1, i);
                Console.WriteLine();
            }
            for (int i = n - 1; i >= 1; i--)
            {
                printLine(1, i);
                Console.WriteLine();
            }
        }
        static void printLine(int a, int b)
        {
            for (int i = a; i <= b; i++)
            {
                Console.Write($"{i} ");
            }
        }
    }
}
