 using System;
using System.Collections.Generic;
using System.Linq;

namespace task01_Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();
            Queue<double> water = new Queue<double>(input);
            input = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();
            Stack<double> flour = new Stack<double>(input);

            Dictionary<string, int> madeProducts = new Dictionary<string, int>()
            {
                ["Croissant"] = 0,
                ["Muffin"] = 0,
                ["Baguette"] = 0,
                ["Bagel"] = 0
            };

            while (water.Any() && flour.Any())
            {

                double currentWater = water.Peek();
                double currentFlour = flour.Peek();

                double waterPercentage = currentWater + currentFlour;
                waterPercentage = (currentWater * 100) / waterPercentage;

                double flourPercentage = currentWater + currentFlour;
                flourPercentage = (currentFlour * 100) / flourPercentage;

                if (waterPercentage == 50 && flourPercentage == 50)
                {
                    madeProducts["Croissant"]++;
                    flour.Pop();
                    water.Dequeue();
                }
                else if (waterPercentage == 40 && flourPercentage == 60)
                {
                    madeProducts["Muffin"]++;
                    flour.Pop();
                    water.Dequeue();
                }
                else if (waterPercentage == 30 && flourPercentage == 70)
                {
                    madeProducts["Baguette"]++;
                    flour.Pop();
                    water.Dequeue();
                }
                else if (waterPercentage == 20 && flourPercentage == 80)
                {
                    madeProducts["Bagel"]++;
                    flour.Pop();
                    water.Dequeue();
                }
                else
                {
                    madeProducts["Croissant"]++;
                    currentFlour -= currentWater;
                    water.Dequeue();
                    flour.Pop();
                    flour.Push(currentFlour);
                }
            }

            foreach (var product in madeProducts.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (product.Value > 0)
                {
                    Console.WriteLine($"{product.Key}: {product.Value}");
                }
            }

            if (water.Count > 0)
            {
                Console.WriteLine("Water left: " + String.Join(", ", water));
            }
            else
            {
                Console.WriteLine("Water left: None");
            }

            if (flour.Count > 0)
            {
                Console.WriteLine("Flour left: " + String.Join(", ", flour));
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }


        }
    }
}
