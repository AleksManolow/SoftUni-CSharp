using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        public double Radius  { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
        public override string Draw()
        {
            return base.Draw() + $"{this.GetType().Name}";     
        }
    }
}
