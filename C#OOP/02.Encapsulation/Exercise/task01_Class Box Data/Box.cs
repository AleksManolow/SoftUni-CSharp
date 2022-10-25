using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
		private double length ;
        private double height;
        private double width;

        public double Length 
		{
			get { return length ; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                length = value;
            }
        }
		public double Width 
		{
			get { return width ; }
            private set
            {
				if (value <= 0)
				{
					throw new ArgumentException($"Width cannot be zero or negative.");
				}
				width  = value; 
			}
		}
		public double Height 
		{
			get { return height ; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }
                height = value;
            }
        }

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double SurfaceArea() => (Length * Height) * 2 + (Length * Width) * 2 + (Width * Height) * 2;
        public double LateralSurfaceArea() => (Length * Height) * 2 + (Width * Height) * 2;
        public double Volume() => Length * Height * Width;
    }
}
