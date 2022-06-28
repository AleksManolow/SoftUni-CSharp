using System;

namespace task05
{
    class Program
    {
        static void Main(string[] args)
        {

            double balance = 0.0;
            string input;

            while ((input = Console.ReadLine()) != "NoMoreMoney")
            {

                double amount = double.Parse(input);
                if (amount < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                
                }

                balance += amount;
                Console.WriteLine($"Increase: {amount:F2}");
            }
            Console.WriteLine($"Total: {balance:F2}");
        }
    }
}
