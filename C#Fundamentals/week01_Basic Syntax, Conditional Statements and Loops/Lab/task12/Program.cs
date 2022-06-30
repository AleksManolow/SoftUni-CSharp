using System;

namespace task12
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            do
            {
                n = int.Parse(Console.ReadLine());
                if (n % 2 == 0)
                {
                        Console.WriteLine($"The number is: {Math.Abs(n)}");
                }
                else
                {
                    Console.WriteLine("Please write an even number.");
                }
            } while (!(n % 2 == 0));
        }
    }
}
