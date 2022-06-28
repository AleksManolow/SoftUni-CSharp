using System;

namespace task03
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string evaluation = Console.ReadLine();

            double price = 0;
            int night = day - 1;
            if (room == "room for one person")
            {
                price = night * 18;

            }
            else if (room == "apartment")
            {
                price = night * 25;
                if (day < 10)
                {
                    price -= (0.3 * price);
                }
                else if (day <= 15)
                {
                    price -= (0.35 * price);
                }
                else
                {
                    price -= (0.50 * price);
                }
            }
            else if (room == "president apartment")
            {
                price = night * 35;
                if (day < 10)
                {
                    price -= (0.1 * price);
                }
                else if (day <= 15)
                {
                    price -= (0.15 * price);
                }
                else
                {
                    price -= (0.20 * price);
                }
            }
            if (evaluation == "positive")
            {
                Console.WriteLine($"{price + (0.25 * price):F2}");
            }
            else
            {
                Console.WriteLine($"{price - (0.10 * price):F2}");
            }
        }
    }
}
