using System;

namespace task09
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceOfLightsabers = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());

            double totalNumberOfLightsabers = Math.Ceiling(countOfStudents * 1.10);
            double numberOfFreeBelts = Math.Floor(countOfStudents / 6.0);

            double finalPriceForSaber = totalNumberOfLightsabers * priceOfLightsabers;
            double finalPriceForRobes = countOfStudents * priceOfRobes;
            double finalPriceForBelts = (countOfStudents - numberOfFreeBelts) * priceOfBelts;

            double finalPrice = finalPriceForBelts + finalPriceForRobes + finalPriceForSaber;
            if (amountOfMoney >= finalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {finalPrice:F2}lv.");
            }
            else
            {
                Console.WriteLine($" John will need {finalPrice - amountOfMoney :F2}lv more.");
            }
        }
    }
}
