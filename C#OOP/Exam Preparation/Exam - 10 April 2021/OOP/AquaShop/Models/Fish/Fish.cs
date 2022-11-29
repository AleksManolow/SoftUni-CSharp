using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
		private string name;
		private string species;
		private decimal price;

        protected Fish(string name, string species, decimal price)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
        }

        public decimal Price
		{
			get { return price; }
			private set 
			{
				if (value <= 0)
				{
					throw new ArgumentException(ExceptionMessages.InvalidFishPrice);
				}
				price = value;
			}
		}

		public virtual int Size { get; set; }	

		public string Species 
		{
			get { return species; }
            private set
            {
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(ExceptionMessages.InvalidFishSpecies);
				}
				species = value;
			}
		}

		public string Name
		{
			get { return name; }
			private set 
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(ExceptionMessages.InvalidFishName);
				}
				name = value;
			}
		}
		public abstract void Eat();
    }
}
