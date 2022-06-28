using System;

namespace task05
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            while (destination != "End")
            {
                int price = int.Parse(Console.ReadLine());
                int savedMoney = 0;
                int sum = 0; 
                while (price > sum)
                {
                    savedMoney = int.Parse(Console.ReadLine());
                    sum += savedMoney;
                }
                if (price <= sum)
                {
                    Console.WriteLine($"Going to {destination}!");
                }
                destination = Console.ReadLine();
            }

        }
    }
}
