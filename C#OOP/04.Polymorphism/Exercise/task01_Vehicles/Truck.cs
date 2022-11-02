using System;
using System.Collections.Generic;
using System.Text;

namespace task01_Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm) 
            : base(fuelQuantity, fuelConsumptionPerKm)
        {

        }
        public override double FuelConsumptionPerKm 
            => base.FuelConsumptionPerKm + 1.6;

        public override void Refuel(double amount)
        {
            amount *= 0.95;
            base.Refuel(amount);
        }
    }
}
