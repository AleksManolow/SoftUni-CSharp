using System;
using System.Collections.Generic;
using System.Linq;

namespace task12_Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] infoCups = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] infoBottles = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(infoCups);
            Stack<int> bottles = new Stack<int>(infoBottles);
            
            
            int waterWasted = 0;
            int topCup = 0;
            while (cups.Any() && bottles.Any())
            {
                int topBottles = bottles.Pop();
                if (topCup == 0)
                {
                    topCup = cups.Dequeue();
                }

                if (topBottles < topCup)
                {
                    
                   topCup -= topBottles;
                }
                else
                {
                    
                    waterWasted += topBottles - topCup;
                    topCup = 0;
                }
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(' ', bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(' ', cups)}");
            }
            Console.WriteLine($"Wasted litters of water: {waterWasted}");
        }
    }
}
