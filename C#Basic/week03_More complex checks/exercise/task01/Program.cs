using System;

namespace task01
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            int colums = int.Parse(Console.ReadLine());

            double income = 0.0;
            if(type =="Premiere")
            {
                income = row * colums * 12.00;
            }
            else if(type == "Normal")
            {
                income = row * colums * 7.50;
            }
            else if(type == "Discount")
            {
                income = row * colums * 5.00;
            }
            Console.WriteLine($"{ income:F2} leve");
        }
    }
}
