using System;

namespace task04
{
    class Program
    {
        static void Main(string[] args)
        {
            int budgetGroup = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numberOfFishmen = int.Parse(Console.ReadLine());

            double temp = 0;
            double remainderSum = 0;
            if(season == "Spring")
            {
                if(numberOfFishmen <= 6)
                {
                    temp = (3000 - (0.10 * 3000));
                }
                else if(numberOfFishmen <= 11)
                {
                    temp = (3000 - (0.15 * 3000));
                }
                else
                {
                    temp = (3000 - (0.25 * 3000));
                }
            }
            else if(season == "Summer" || season == "Autumn")
            {
                if (numberOfFishmen <= 6)
                {
                    temp = (4200 - (0.10 * 4200));
                }
                else if (numberOfFishmen <= 11)
                {
                    temp = (4200 - (0.15 * 4200));
                }
                else
                {
                    temp = (4200 - (0.25 * 4200));
                }
            }
            else
            {
                if (numberOfFishmen <= 6)
                {
                    temp = (2600 - (0.10 * 2600));
                }
                else if (numberOfFishmen <= 11)
                {
                    temp = (2600 - (0.15 * 2600));
                }
                else
                {
                    temp = (2600 - (0.25 * 2600));
                }
            }
            if(season != "Autumn" && numberOfFishmen % 2 == 0)
            {
                remainderSum = budgetGroup - (temp - (temp * 0.05)); 
            }
            else
            {
                remainderSum = budgetGroup - temp;
            }

            if(remainderSum >= 0)
            {
                Console.WriteLine($"Yes! You have {remainderSum:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(remainderSum):F2} leva.");
            }
        }
    }
}
