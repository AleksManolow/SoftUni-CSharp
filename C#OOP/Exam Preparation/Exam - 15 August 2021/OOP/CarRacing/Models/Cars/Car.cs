using CarRacing.Models.Cars.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        private string make;
        private string model;
		private string vin;
		private int horsePower;
		private double fuelAvailable ;
		private double fuelConsumptionPerRace;

        protected Car(string make, string model, string vin, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = vin;
            this.HorsePower = horsePower;
            this.FuelAvailable = fuelAvailable;
            this.FuelConsumptionPerRace = fuelConsumptionPerRace;
        }

        public double FuelConsumptionPerRace
        {
			get { return fuelConsumptionPerRace; }
			private set 
			{
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarFuelConsumption);
                }
                fuelConsumptionPerRace = value;
            }
		}
		public double FuelAvailable
        {
			get { return fuelAvailable ; }
			private set 
			{
				if (value < 0)
				{
                    value = 0;
				}
                fuelAvailable = value;
            }
		}
		public int HorsePower 
        {
			get { return horsePower; }
			protected set 
			{
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarHorsePower);
                }
                horsePower = value;
            }
		}
		public string VIN
		{
			get { return vin; }
			private set 
			{
				if (value.Length != 17)
				{
					throw new ArgumentException(ExceptionMessages.InvalidCarVIN);
				}
				vin = value;
			}
		}
		public string Model
		{
			get { return model; }
			private set 
			{
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarModel);
                }
                model = value;
			}
		}
        public string Make
        {
            get { return make; }
            private set 
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(ExceptionMessages.InvalidCarMake);
				}
				make = value;
			}
        }

        public virtual void Drive()
        {
            FuelAvailable -= FuelConsumptionPerRace;
        }
    }
}
