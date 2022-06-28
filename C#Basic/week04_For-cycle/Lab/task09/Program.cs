using System;

namespace task09
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sumOne = 0;
            int sumTwo = 0;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sumOne += num;
            }
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sumTwo += num;
            }
            if (sumOne == sumTwo)
            {
                Console.WriteLine($"Yes, sum = {sumOne}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(sumOne - sumTwo)}");
            }
        }
    }
}
