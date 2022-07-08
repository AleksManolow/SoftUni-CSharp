using System;
using System.Numerics;

namespace task02_BigFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger f = 1;
            for (int i = 2; i <= n; i++)
            {
                f *= i;
            }
            Console.WriteLine(f);
        }
    }
}
