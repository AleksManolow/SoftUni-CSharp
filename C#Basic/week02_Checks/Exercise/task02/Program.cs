using System;

namespace task02
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = int.Parse(Console.ReadLine());
            double points = 0;
            if (number < 100)
                points += 5;
            else if (number < 1000)
                points += (number * 0.2);
            else
                points += (number * 0.1);

            if (number % 2 == 0)
                points += 1;
            else if (number % 10 == 0 || number % 10 == 5)
                points += 2;
            Console.WriteLine(points);
            Console.WriteLine(number + points);
        }
    }
}
