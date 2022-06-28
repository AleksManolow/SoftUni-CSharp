using System;

namespace task04
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int yearPriceCount = 0;
            int coutToy = 0;
            int sumPrice = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    sumPrice += 5 * i;
                    yearPriceCount++;
                }
                else
                {
                    coutToy++;
                }
            }
            sumPrice = sumPrice + (coutToy * toyPrice) - yearPriceCount;
            if (sumPrice >= price)
            {
                Console.WriteLine($"Yes! {sumPrice - price:F2}");
            }
            else
            {
                Console.WriteLine($"No! {Math.Abs(price - sumPrice):F2}");
            }
        }
    }
}
