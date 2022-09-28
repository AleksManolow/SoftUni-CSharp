using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        private double speed;
        private double power;
        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public double Power
        {
            get { return power; }
            set { power = value; }
        }
        public Engine(double speed, double power)
        {
            this.speed = speed;
            this.power = power;
        }



    }
}
