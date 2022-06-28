using System;

namespace task03
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine());

            min += 15;
            if (min / 60 != 0)
            {
                if (hour == 23)
                    hour = 0;
                else
                    hour += 1;
            }
            min %= 60;

            if (min < 10)
                Console.WriteLine($"{hour}:0{min}");
            else
                Console.WriteLine($"{hour}:{min}");
        }
    }
}
