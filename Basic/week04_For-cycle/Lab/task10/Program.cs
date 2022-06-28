using System;

namespace task10
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sumEven = 0;
            int sumOld = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                    sumEven += num;
                else
                    sumOld += num;
            }
            if (sumOld == sumEven)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sumOld}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(sumOld - sumEven)}");
            }
        }
    }
}
