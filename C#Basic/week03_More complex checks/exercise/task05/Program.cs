﻿using System;

namespace task05
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            if(budget <= 100)
            {
                Console.WriteLine("Somewhere in Bulgaria");
                if(season == "summer")
                {
                    Console.WriteLine($"Camp - {Math.Round(budget * 0.3, 2):F2}");
                }
                else
                {
                    Console.WriteLine($"Hotel - {Math.Round(budget * 0.7, 2):F2}");
                }
            }
            else if(budget <= 1000)
            {
                Console.WriteLine("Somewhere in Balkans");
                if (season == "summer")
                {
                    Console.WriteLine($"Camp - {Math.Round(budget * 0.4, 2):F2}");
                }
                else
                {
                    Console.WriteLine($"Hotel - {Math.Round(budget * 0.8, 2):F2}");
                }
            }
            else
            {
                Console.WriteLine("Somewhere in Europe");
                Console.WriteLine($"Hotel - {Math.Round( budget * 0.9, 2):F2}");
            }



        }
    }
}
