using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
    public abstract class  Feline : Maamal
    {
        public Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            Breed = breed;
        }
        public string Breed { get; set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
