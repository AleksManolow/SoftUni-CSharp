using System;
using System.Runtime.ConstrainedExecution;
using _03._Car_Constructors;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car fisrtCar = new Car();
            Car secoundCar = new Car(make, model, year);
            Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);

        }
    }
}
