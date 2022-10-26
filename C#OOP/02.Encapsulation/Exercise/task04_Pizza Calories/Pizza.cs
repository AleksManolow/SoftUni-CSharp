using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int ToppingsCapacity = 10; 

        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }
        public IReadOnlyCollection<Topping> Toppings => toppings;
        public void AddToppings(Topping topping)
        {
            if (toppings.Count == ToppingsCapacity)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);
        }

        public double GetTotalCalories() => this.Dough.Calories + this.toppings.Sum(x => x.Calories);

        public string Name
		{
			get { return name; }
			private set
            {

                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
		}
		public Dough Dough
        {
			get { return dough; }
            private set { dough = value; }
		}
       

    }
}
