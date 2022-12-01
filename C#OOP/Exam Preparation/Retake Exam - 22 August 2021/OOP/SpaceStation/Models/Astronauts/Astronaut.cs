using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;
using System;
namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
		private string name;
		private double oxygen;
		private IBag bag;

        protected Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            this.bag = new Backpack();
        }
        public IBag Bag => bag;
		public bool CanBreath => oxygen > 0;
		
		public double Oxygen
		{
			get { return oxygen; }
			protected set 
			{
				if (value < 0)
				{
					throw new ArithmeticException(ExceptionMessages.InvalidOxygen);
				}
				oxygen = value;
			}
		}
		public string Name
		{
			get { return name; }
			private set 
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
				}
				name = value;
			}
		}

        public virtual void Breath()
        {
            this.oxygen -= 10;
            if (oxygen < 0)
            {
                oxygen = 0;
            }
        }
    }
}
