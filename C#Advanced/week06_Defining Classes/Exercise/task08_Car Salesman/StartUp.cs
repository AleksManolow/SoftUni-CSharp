using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string model = input[0];
                int power = int.Parse(input[1]);
                if (input.Length == 3)
                {
                    bool isDesplacement = int.TryParse(input[2], out int displacement);
                    
                    if (isDesplacement)
                    {
                        engines.Add(new Engine(model, power, displacement));
                    }
                    else
                    {
                        string efficiency = input[2];
                        engines.Add(new Engine(model, power, efficiency));
                    }
                }
                else if (input.Length == 4)
                {
                    int displacement = int.Parse(input[2]);
                    string efficiency = input[3];
                    engines.Add(new Engine(model, power, displacement, efficiency));
                }
                else
                {
                    engines.Add(new Engine(model, power));
                }
            }

            List<Car> cars = new List<Car>();
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string model = input[0];
                string modelEngine = input[1];
                Engine engine = engines.Single(x => x.Model == modelEngine);
                if (input.Length == 3)
                {
                    bool isWeight = int.TryParse(input[2], out int weight);
                    if (isWeight)
                    {
                        cars.Add(new Car(model, engine, weight));
                    }
                    else
                    {
                        string color = input[2];
                        cars.Add(new Car(model, engine, color));
                    }
                }
                else if (input.Length == 4)
                {
                    int weight = int.Parse(input[2]);
                    string color = input[3];
                    cars.Add(new Car(model, engine,weight ,color));
                }
                else
                {
                    cars.Add(new Car(model, engine));
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.Model + ":");
                Console.WriteLine(" " + car.Engine.Model + ":");
                Console.WriteLine("  Power: " + car.Engine.Power);
                if (car.Engine.Displacement != null)
                {
                    Console.WriteLine("  Displacement: " + car.Engine.Displacement);
                }
                else
                {
                    Console.WriteLine("  Displacement: n/a");
                }
                if (car.Engine.Efficiency != null)
                {
                    Console.WriteLine("  Efficiency: " + car.Engine.Efficiency);
                }
                else
                {
                    Console.WriteLine("  Efficiency: n/a");
                }
                if (car.Weight != null)
                {
                    Console.WriteLine(" Weight: " + car.Weight);
                }
                else
                {
                    Console.WriteLine(" Weight: n/a");
                }
                if (car.Color != null)
                {
                    Console.WriteLine(" Color: " + car.Color);
                }
                else
                {
                    Console.WriteLine(" Color: n/a");
                }
            }
        }
    }
}
