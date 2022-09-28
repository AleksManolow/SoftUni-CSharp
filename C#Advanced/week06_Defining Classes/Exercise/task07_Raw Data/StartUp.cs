using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                string model = input[0];
                double engineSpeed = Convert.ToInt32(input[1]);
                double enginePower = Convert.ToInt32(input[2]);
                double cargoWeight = Convert.ToInt32(input[3]);
                string cargoType = input[4];



                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);

                Tire[] tires = new Tire[4];

                double tirePressure01 = Convert.ToDouble(input[5]);
                int tireYear01 = Convert.ToInt32(input[6]);
                Tire newTire01 = new Tire(tireYear01, tirePressure01);
                double tirePressure02 = Convert.ToDouble(input[7]);
                int tireYear02 = Convert.ToInt32(input[8]);
                Tire newTire02 = new Tire(tireYear02, tirePressure02);
                double tirePressure03 = Convert.ToDouble(input[9]);
                int tireYear03 = Convert.ToInt32(input[10]);
                Tire newTire03 = new Tire(tireYear03, tirePressure03);
                double tirePressure04 = Convert.ToDouble(input[11]);
                int tireYear04 = Convert.ToInt32(input[12]);
                Tire newTire04 = new Tire(tireYear04, tirePressure04);
                tires[0] = newTire01;
                tires[1] = newTire02;
                tires[2] = newTire03;
                tires[3] = newTire04;

                Car newCar = new Car(model, engine, cargo, tires);
                cars.Add(newCar);
            }

            string inputCategory = Console.ReadLine();
            if (inputCategory == "fragile")
            {
                var filteredCars = cars.Where(cargoType => cargoType.Cargo.Type == "fragile");
                foreach (var car in filteredCars.Where(tire => tire.Tires.FirstOrDefault(pressure => pressure.Pressure < 1) != null))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (inputCategory == "flammable")
            {
                foreach (var car in cars.Where(x => x.Cargo.Type == "flammable" && x.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
