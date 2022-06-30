using System;

namespace task01
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                string name = Console.ReadLine();
                double income = double.Parse(Console.ReadLine());
                double cost = double.Parse(Console.ReadLine());


                if (i % 5 == 0)
                {
                    income -= (0.1 * income);
                }
                else if (i % 3 == 0)
                {
                    cost += (0.5 * cost);
                }

                Console.WriteLine($"In {name} Burger Bus earned {income - cost:F2} leva.");
                sum += (income - cost);
            }
            Console.WriteLine($"Burger Bus total profit: {sum:F2} leva.");
        }
    }
}
