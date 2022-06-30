using System;

namespace task04
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine()) + 30;
            if (minutes > 59)
            {
                hours += 1;
                minutes -= 60;
            }
            if (hours > 23)
            {
                hours = 0;
            }
            Console.WriteLine("{0}:{1:D2}", hours, minutes);
        }
    }
}
