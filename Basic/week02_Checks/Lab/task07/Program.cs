using System;

namespace task07
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double area = 0;
            if(figure == "square")
            {
                double a = double.Parse(Console.ReadLine());
                area = a * a;
            }
            else if (figure == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                area = a * b;
            }
            else if (figure == "circle")
            {
                double a = double.Parse(Console.ReadLine());
                area = a * a * Math.PI;
            }
            else if (figure == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                area = a * h / 2;

            }
            Console.WriteLine(area);

        }
    }
}
