using Bakery.Models.BakedFoods.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.BakedFoods
{
    public abstract class BakedFood : IBakedFood
    {
		
		private string name;
		private int portion;
		private decimal price;

        protected BakedFood(string name, int portion, decimal price)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
        }

        public decimal Price 
		{
			get { return price; }
			private set 
			{
				if (value <= 0)
				{
					throw new ArgumentException(ExceptionMessages.InvalidPrice);
				}
				price = value;
			}
		}

		public int Portion
        {
			get { return portion; }
			private set 
			{
				if (value <= 0)
				{
					throw new ArgumentException(ExceptionMessages.InvalidPortion);
				}
				portion = value;
			}
		}

		public string Name
		{
			get { return name; }
			private set 
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(ExceptionMessages.InvalidName);
				}
				name = value;
			}
		}

        public override string ToString()
        {
            return $"{Name}: {Portion}g - {Price:F2}";
        }
    }
}
