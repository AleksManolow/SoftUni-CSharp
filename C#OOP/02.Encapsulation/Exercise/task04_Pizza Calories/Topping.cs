using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Topping
    {
		Dictionary<string, double> TypeOfToppingCalories = new Dictionary<string, double>
		{
			{"meat", 1.2},
			{"veggies", 0.8},
			{"cheese", 1.1 },
			{"sauce", 0.9 },
		};	

        private const int CaloriesPerGram = 2;

        private string type;
        private double weigth;


		public Topping(string type, double weigth)
		{
			Type = type;
			Weigth = weigth;
		}

		public double Calories => CaloriesPerGram * Weigth * TypeOfToppingCalories[this.Type.ToLower()];

		public string Type
		{
			get { return type; }
            private set
            {
                if (!TypeOfToppingCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;
			}
		}

		public double Weigth
		{
			get { return weigth; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new InvalidOperationException($"{this.type} weight should be in the range [1..50].");
                }
                weigth = value;
			}
		}



	}
}