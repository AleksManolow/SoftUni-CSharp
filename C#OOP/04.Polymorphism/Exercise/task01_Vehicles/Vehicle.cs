using System;
using System.Collections.Generic;
using System.Text;

namespace task01_Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public double FuelQuantity { get; set; }
        public virtual double FuelConsumptionPerKm { get; set; }

        public bool CanDrive(double km)
            => this.FuelQuantity - (km * this.FuelConsumptionPerKm) >= 0;
        public void Drive(double km)
        {
            if (CanDrive(km))
            {
                this.FuelQuantity -= km * this.FuelConsumptionPerKm;
            }
        }
        public virtual void Refuel(double amount)
        {
            this.FuelQuantity += amount;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
