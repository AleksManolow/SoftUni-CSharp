using System;
using System.Collections.Generic;
using System.Linq;

namespace task01_Energy_Drinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Stack<int> caffeinе = new Stack<int>(input);
            input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Queue<int> energyDrink = new Queue<int>(input);


            int maximumCaffeine = 0;
            while (caffeinе.Any() && energyDrink.Any())
            {
                int multiplication = caffeinе.Peek() * energyDrink.Peek();
                if (maximumCaffeine + multiplication <= 300)
                {
                    caffeinе.Pop();
                    energyDrink.Dequeue();
                    maximumCaffeine += multiplication;
                }
                else
                {
                    caffeinе.Pop();
                    energyDrink.Enqueue(energyDrink.Dequeue());
                    if (maximumCaffeine >= 30)
                    {
                        maximumCaffeine -= 30;
                    }
                } 
            }
            if (energyDrink.Count > 0)
            {
                Console.WriteLine("Drinks left: " + string.Join(", ", energyDrink));
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {maximumCaffeine} mg caffeine.");

        }
    }
}
