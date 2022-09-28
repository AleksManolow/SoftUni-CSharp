using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tire
    {
        private int age;
        private double pressure;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public double Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }
        public Tire(int age, double presssure)
        {
            this.Age = age;
            this.Pressure = presssure;
        }



    }
}
