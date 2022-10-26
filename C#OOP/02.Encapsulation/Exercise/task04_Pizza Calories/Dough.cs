using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Dough
    {
        private Dictionary<string, double> flourTypeCalories = new Dictionary<string, double>
        {
            {"white", 1.5},
            {"wholegrain", 1},
        };

        private Dictionary<string, double> bakingTechniqueCalories = new Dictionary<string, double>
        {
            {"crispy", 0.9},
            {"chewy", 1.1},
            {"homemade", 1},
        };

        private const int CaloriesPerGram = 2;

        private string flourType;
        private string bakingTechniquemyVar;
        private double weigth;

		public Dough(string flourType, string bakingTechnique, double weigth)
		{
			FlourType = flourType;
			BakingTechnique = bakingTechnique;
			Weigth = weigth;
		}

		public string FlourType
        {
			get { return flourType; }
			private set 
            {
                if (!flourTypeCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
		}

		public string BakingTechnique
        {
			get { return bakingTechniquemyVar; }
            private set
            {
                if (!bakingTechniqueCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechniquemyVar = value;
            }
		}
		public double Weigth
		{
			get { return weigth; }
			set 
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weigth = value;
            }
		}
        public double Calories => CaloriesPerGram * Weigth * 
            flourTypeCalories[this.FlourType.ToLower()] *
            bakingTechniqueCalories[this.BakingTechnique.ToLower()];
    }
}