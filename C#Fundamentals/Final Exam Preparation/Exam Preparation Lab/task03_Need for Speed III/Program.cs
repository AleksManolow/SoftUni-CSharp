using System;
using System.Collections.Generic;

namespace task03_Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, double[]> cars = new Dictionary<string, double[]>(n);
            for (int i = 0; i < n; i++)
            {
                string[] inputCar = Console.ReadLine().Split('|');
                double[] arr = { double.Parse(inputCar[1]), double.Parse(inputCar[2])};
                cars.Add(inputCar[0], arr);
            }
            string[] input = Console.ReadLine().Split(" : ");
            while (input[0] != "Stop")
            {
                if (input[0] == "Drive")
                {
                    if (double.Parse(input[3]) > cars[input[1]][1])
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[input[1]][0] += double.Parse(input[2]);
                        cars[input[1]][1] -= double.Parse(input[3]);
                        Console.WriteLine($"{input[1]} driven for {input[2]} kilometers. {input[3]} liters of fuel consumed.");
                    }

                    if (cars[input[1]][0] > 100000)
                    {
                        Console.WriteLine($"Time to sell the {input[1]}!");
                        cars.Remove(input[1]);
                    }
                }
                else if (input[0] == "Refuel")
                {
                    if (cars[input[1]][1] + double.Parse(input[2]) > 75)
                    {
                        Console.WriteLine($"{input[1]} refueled with {75 - cars[input[1]][1]} liters");
                        cars[input[1]][1] = 75;
                    }
                    else
                    {
                        Console.WriteLine($"{input[1]} refueled with {input[2]} liters");
                        cars[input[1]][1] += double.Parse(input[2]);
                    }
                }
                else if (input[0] == "Revert")
                {
                    if (cars[input[1]][0] - double.Parse(input[2]) >= 10000)
                    {
                        cars[input[1]][0] -= double.Parse(input[2]);
                        Console.WriteLine($"{input[1]} mileage decreased by {input[2]} kilometers");
                    }
                    else
                    {
                        cars[input[1]][0] = 10000;
                    }
                }
                input = Console.ReadLine().Split(" : ");
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value[0]} kms, Fuel in the tank: { car.Value[1]} lt.");
            }
        }
    }
}
