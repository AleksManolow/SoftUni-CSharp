using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
    public abstract class Maamal : Animal
    {
        protected Maamal(string name, double weight, string livingRegion) 
            : base(name, weight)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
