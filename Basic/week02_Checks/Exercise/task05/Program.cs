using System;

namespace task05
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());

            double decor = (budget * 0.1);
            double clothing = number * price;
            if (number > 150)
            {
                clothing -= (clothing * 0.1);
            }

            if(budget - (decor + clothing) >= 0)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - (decor + clothing):F2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {Math.Abs(budget - (decor + clothing)):F2} leva more.");
            }

        }
    }
}
