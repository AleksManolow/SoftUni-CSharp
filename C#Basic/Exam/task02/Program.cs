using System;

namespace task02
{
    class Program
    {
        static void Main(string[] args)
        {
            double pocket = double.Parse(Console.ReadLine());
            double winDay = double.Parse(Console.ReadLine());
            double cost = double.Parse(Console.ReadLine());
            double priceGift = double.Parse(Console.ReadLine());

            double savedMoney = 0;
            savedMoney = 5 * pocket;
            savedMoney += 5 * winDay;

            double temp = savedMoney - cost;

            if (temp >= priceGift)
            {
                Console.WriteLine($"Profit: {temp:F2} BGN, the gift has been purchased.");
            }
            else
            {
                Console.WriteLine($"Insufficient money: {priceGift - temp:F2} BGN.");
            }

        }
    }
}
