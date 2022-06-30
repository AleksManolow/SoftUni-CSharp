using System;

namespace task01
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            theSmallestOfNumbers(num1, num2, num3);
        }
        static void theSmallestOfNumbers(int num1, int num2, int num3)
        {
            Console.WriteLine(Math.Min(num1, Math.Min(num2, num3)));
        }
    }
}
