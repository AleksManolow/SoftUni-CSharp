using System;
using System.Collections.Generic;
using System.Text;

namespace Sandwich
{
    public class Sandwich:IPrototype<Sandwich>
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;
        public Weight Weight { get; set; }

        public Sandwich(string bread, string meat, string cheese, string veggies, int gr)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
            Weight = new Weight(gr);
        }
        public Sandwich ShallowCopy()
            => this.MemberwiseClone() as Sandwich;

        public Sandwich DeepCopy()
        {
            Sandwich copy = this.MemberwiseClone() as Sandwich;
            copy.bread = new string(bread);
            copy.meat = new string(meat);
            copy.cheese = new string(cheese);
            copy.veggies = new string(veggies);
            copy.Weight = new Weight(copy.Weight.Gr);

            return copy;
        }
    }
    public class Weight
    {
        public int Gr { get; set; }

        public Weight(int gr)
        {
            Gr = gr;
        }
    }
}
