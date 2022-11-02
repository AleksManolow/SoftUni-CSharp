using System;
using System.Collections.Generic;
using System.Text;

namespace task01_Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumptionPerKm) 
            : base(fuelQuantity, fuelConsumptionPerKm)
        {

        }
        public override double FuelConsumptionPerKm 
            => base.FuelConsumptionPerKm + 0.9;
        
    }
}
