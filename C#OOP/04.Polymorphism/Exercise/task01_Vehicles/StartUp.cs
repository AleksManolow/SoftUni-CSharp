using System;

namespace task01_Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));

            string[] truckInfo = Console.ReadLine().Split();
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] commands = Console.ReadLine().Split();
                string action = commands[0];
                string typeOfVehicle = commands[1];
                double value = double.Parse(commands[2]);

                if (action == "Drive")
                {
                    if (typeOfVehicle == "Car")
                    {
                        if (car.CanDrive(value))
                        {
                            car.Drive(value);
                            Console.WriteLine($"Car travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine($"Car needs refueling");
                        }
                    }
                    else
                    {
                        if (truck.CanDrive(value))
                        {
                            truck.Drive(value);
                            Console.WriteLine($"Truck travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine($"Truck needs refueling");
                        }
                    }
                }
                else
                {
                    if (typeOfVehicle == "Car")
                    {
                        car.Refuel(value);
                    }
                    else
                    {
                        truck.Refuel(value);
                    }
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
