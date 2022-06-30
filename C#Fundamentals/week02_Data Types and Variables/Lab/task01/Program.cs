using System;

namespace task01
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double result = n / 1000.0;
            Console.WriteLine($"{result:f2}");
        }
    }
}
