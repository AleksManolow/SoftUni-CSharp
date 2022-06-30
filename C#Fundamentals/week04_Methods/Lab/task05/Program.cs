using System;

namespace task05
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            calculates(input, n);
        }
        static void calculates(string s, int n )
        {
            switch (s)
            {
                case "coffee":
                    Console.WriteLine($"{1.50 * n:F2}");
                    break;
                case "water":
                    Console.WriteLine($"{1 * n:F2}");
                    break;
                case "coke":
                    Console.WriteLine($"{1.40 * n:F2}");
                    break;
                case "snacks":
                    Console.WriteLine($"{2.00 * n:F2}");
                    break;
            }
        }
    }
}
