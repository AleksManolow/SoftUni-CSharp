using System;

namespace task04
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceEks = double.Parse(Console.ReadLine());
            int numberOfPuzzle = int.Parse(Console.ReadLine());
            int numberOfDoll = int.Parse(Console.ReadLine());
            int numberOfBear = int.Parse(Console.ReadLine());
            int numberOfMinion = int.Parse(Console.ReadLine());
            int numberOfTruck = int.Parse(Console.ReadLine());

            int sumOfNumbers = numberOfPuzzle + numberOfDoll + numberOfBear + numberOfMinion + numberOfTruck;
            double allPrice = numberOfPuzzle * 2.6 + numberOfDoll * 3 + numberOfBear * 4.1 + numberOfMinion * 8.2 + numberOfTruck * 2;
            if (sumOfNumbers >= 50)
            {
                allPrice -= (allPrice * 0.25);
            }
            allPrice -= (allPrice * 0.1);
            if(allPrice >= priceEks)
            {
                Console.WriteLine($"Yes! {Math.Round(allPrice - priceEks, 2):F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {Math.Round(Math.Abs(allPrice - priceEks), 2):F2} lv needed.");
            }
        }
    }
}
