using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food;

namespace WildFarm.Animals
{
    using WildFarm.Food;
    public class Mouse : Maamal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }
        public override double WeightGainPerUnitOfFood => 0.10;

        public override void Feed(Food food)
        {
            if (!(food is Vegetable) && !(food is Fruit))
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }

            base.Feed(food);
        }
        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
