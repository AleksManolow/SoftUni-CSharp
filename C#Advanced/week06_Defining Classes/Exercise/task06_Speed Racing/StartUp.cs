using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();   
            for (int i = 0; i < n; i++)
            {
                string[] inputCar = Console.ReadLine().Split(' ');
                string model = inputCar[0];
                double fuelAmount = double.Parse(inputCar[1]);
                double fuelConsumptionPerKilometer = double.Parse(inputCar[2]);
                cars.Add(new Car(model, fuelAmount, fuelConsumptionPerKilometer));
            }
            string[] drive = Console.ReadLine().Split(' ');
            while (drive[0] != "End")
            {
                cars.Single(x => x.Model == drive[1]).drive(double.Parse(drive[2]));
                //tempCar.drive(double.Parse(drive[2]));

                drive = Console.ReadLine().Split(' ');
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }

        }
    }
}
