using System;
using System.Collections.Generic;

namespace task03_P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> cities = new Dictionary<string, int[]>();
            string[] inputCities = Console.ReadLine().Split("||");
            while (inputCities[0] != "Sail")
            {
                int[] arr = { 0, 0};
                if (!cities.ContainsKey(inputCities[0]))
                {
                    cities.Add(inputCities[0], arr);
                }
                cities[inputCities[0]][0] += int.Parse(inputCities[1]);
                cities[inputCities[0]][1] += int.Parse(inputCities[2]);

                inputCities = Console.ReadLine().Split("||");
            }

            string[] inputEvents = Console.ReadLine().Split("=>");
            while (inputEvents[0] != "End")
            {

                if (inputEvents[0] == "Plunder")
                {
                    cities[inputEvents[1]][0] -= int.Parse(inputEvents[2]);
                    cities[inputEvents[1]][1] -= int.Parse(inputEvents[3]);
                    Console.WriteLine($"{inputEvents[1]} plundered! {inputEvents[3]} gold stolen, {inputEvents[2]} citizens killed.");
                    if (cities[inputEvents[1]][0] <= 0 || cities[inputEvents[1]][1] <= 0)
                    {
                        Console.WriteLine($"{inputEvents[1]} has been wiped off the map!");
                        cities.Remove(inputEvents[1]);
                    }
                }
                else if (inputEvents[0] == "Prosper")
                {
                    if (int.Parse(inputEvents[2]) < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        cities[inputEvents[1]][1] += int.Parse(inputEvents[2]); 
                        Console.WriteLine($"{inputEvents[2]} gold added to the city treasury. {inputEvents[1]} now has {cities[inputEvents[1]][1]} gold.");
                    }
                }
                inputEvents = Console.ReadLine().Split("=>");
            }
            if (cities.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var city in cities)
                {
                    Console.WriteLine($"{city.Key} -> Population: { city.Value[0]} citizens, Gold: { city.Value[1]} kg");
                }
            }

        }
    }
}
