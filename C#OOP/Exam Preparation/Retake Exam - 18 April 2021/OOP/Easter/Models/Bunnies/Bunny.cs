using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
		private string name;
		private int energy;
		private ICollection<IDye> dyes;

        public Bunny(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.dyes = new List<IDye>();
        }
        public ICollection<IDye> Dyes => dyes;
        
		public int Energy
        {
			get { return energy; }
			protected set 
            { 
                energy = value;
                if (energy < 0)
                {
                    energy = 0;
                }
            }
		}
		public string Name
		{
			get { return name; }
			private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }
                name = value;
            }
		}
        public void AddDye(IDye dye)
        {
            dyes.Add(dye);
        }
        public abstract void Work();
    }
}
