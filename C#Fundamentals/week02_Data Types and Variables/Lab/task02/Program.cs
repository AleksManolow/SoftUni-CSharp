using System;

namespace task02
{
    class Program
    {
        static void Main(string[] args)
        {
            double pounds = double.Parse(Console.ReadLine());
            double result = pounds * 1.31;
            Console.WriteLine($"{result:f3}");
        }
    }
}
