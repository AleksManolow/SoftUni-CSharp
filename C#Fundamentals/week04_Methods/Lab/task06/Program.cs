using System;

namespace task06
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = getRectangleArea(width, height);
            Console.WriteLine(area);
        }
        static double getRectangleArea(double width, double height)
        {
            return width * height;
        }
    }
}
