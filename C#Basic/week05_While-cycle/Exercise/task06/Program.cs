using System;

namespace task06
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());

            int price = width * length;
            string input = "";
            while (input != "STOP" && price > 0)
            {
                input = Console.ReadLine();
                if (input != "STOP")
                {
                    price -= (int.Parse(input));
                }
            }
            if (price >= 0)
            {
                Console.WriteLine($"{price} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(price)} pieces more.");
            }

        }
    }
}
