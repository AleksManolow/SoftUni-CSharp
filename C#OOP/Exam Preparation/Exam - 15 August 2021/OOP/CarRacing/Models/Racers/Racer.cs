using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
		private string username;
		private string racingBehavior ;
		private int drivingExperience ;
		private ICar car;
        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;
        }
        public ICar Car
		{
			get { return car; }
			set 
            {
                if (value is null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }
                car = value;
            }
		}
		public int DrivingExperience
        {
            get { return drivingExperience; }
            protected set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }
                drivingExperience = value;
            }
		}
		public string RacingBehavior
        {
			get { return racingBehavior ; }
			private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new AggregateException(ExceptionMessages.InvalidRacerBehavior);
                }
                racingBehavior  = value;
            }
		}
		public string Username
        {
			get { return username; }
			private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }
                username = value; 
            }
		}

        public bool IsAvailable()
        {
            return Car.FuelAvailable >= Car.FuelConsumptionPerRace;
        }

        public virtual void Race()
        {
            car.Drive();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {this.Username}");
            sb.AppendLine($"--Driving behavior: {this.RacingBehavior}");
            sb.AppendLine($"--Driving experience: {this.DrivingExperience}");
            sb.AppendLine($"--Car: {car.Make} {car.Model} ({car.VIN})");

            return sb.ToString().TrimEnd();
        }
    }
}
