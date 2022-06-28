using System;

namespace task05
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSea = int.Parse(Console.ReadLine());
            int numberOfMountain = int.Parse(Console.ReadLine());

            double profit = 0;
            string seaOrMountain = Console.ReadLine();
            while (seaOrMountain != "Stop" && (numberOfSea != 0 || numberOfMountain != 0))
            {
                if (seaOrMountain == "sea" && numberOfSea != 0)
                {
                    profit += 680;
                    numberOfSea--;
                }
                else if (seaOrMountain == "mountain" && numberOfMountain != 0)
                {
                    profit += 499;
                    numberOfMountain--;
                }
                seaOrMountain = Console.ReadLine();
            }
            if (numberOfSea == 0 && numberOfMountain == 0)
            {
                Console.WriteLine("Good job! Everything is sold.");
            }
            Console.WriteLine($"Profit: {profit} leva.");

        }
    }
}
