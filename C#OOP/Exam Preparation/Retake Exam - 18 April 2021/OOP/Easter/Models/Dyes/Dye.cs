using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;
        public Dye(int power)
        {
            this.Power = power;
        }
        public int Power
        {
            get { return power; }
            private set 
            { 
                power = value;
                if (power < 0)
                {
                    power = 0;
                }
            }
        }
        public void Use()
        {
            this.Power -= 10;
        }
        public bool IsFinished()
        {
            return this.Power == 0;
        }

        
    }
}
