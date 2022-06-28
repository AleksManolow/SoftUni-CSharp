using System;

namespace task03
{
    class Program
    {
        static void Main(string[] args)
        {
            string kindOfFlowers = Console.ReadLine();
            int numFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double remainderSum = 0;
            if(kindOfFlowers == "Roses")
            {
                if(numFlowers > 80 )
                {
                    remainderSum = budget - ((numFlowers * 5) - (0.10 * (numFlowers * 5)));
                }
                else
                {
                    remainderSum = budget - (numFlowers * 5);
                }
            }
            else if(kindOfFlowers == "Dahlias")
            {
                if (numFlowers > 90)
                {
                    remainderSum = budget - ((numFlowers * 3.80) - (0.15 * (numFlowers * 3.80)));
                }
                else
                {
                    remainderSum = budget - (numFlowers * 3.80);
                }
            }
            else if (kindOfFlowers == "Tulips")
            {
                if (numFlowers > 80)
                {
                    remainderSum = budget - ((numFlowers * 2.80) - (0.15 * (numFlowers * 2.80)));
                }
                else
                {
                    remainderSum = budget - (numFlowers * 2.80);
                }
            }
            else if (kindOfFlowers == "Narcissus")
            {

                if (numFlowers < 120)
                {
                    remainderSum = budget - ((numFlowers * 3) + (0.15 * (numFlowers * 3)));
                }
                else
                {
                    remainderSum = budget - (numFlowers * 3);
                }
            }
            else
            {
                if (numFlowers < 80)
                {
                    remainderSum = budget - ((numFlowers * 2.50) + (0.20 * (numFlowers * 2.50)));
                }
                else
                {
                    remainderSum = budget - (numFlowers * 2.50);
                }
            }
            if(remainderSum >= 0)
            {
                Console.WriteLine($"Hey, you have a great garden with {numFlowers} {kindOfFlowers} and {remainderSum:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {Math.Abs(remainderSum):F2} leva more.");
            }


        }
    }
}
