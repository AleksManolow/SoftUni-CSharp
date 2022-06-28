using System;

namespace task07
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            double sum = a * 250 + b * (0.35 * (a * 250)) + c * (0.1 * (a * 250));
            if(a > b)
            {
                sum -= (sum * 0.15);
            }

            if(sum <= budget)
            {
                Console.WriteLine($"You have {budget - sum:F2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(budget - sum):F2} leva more!");
            }

        }
    }
}
