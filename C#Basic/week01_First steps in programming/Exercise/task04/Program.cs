using System;

namespace task04
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPages = int.Parse(Console.ReadLine());
            int pagesForHour = int.Parse(Console.ReadLine());
            int numberOfDays = int.Parse(Console.ReadLine());

            int numberOfHours = (numberOfPages / pagesForHour) / numberOfDays;
            Console.WriteLine(numberOfHours);
        }
    }
}
