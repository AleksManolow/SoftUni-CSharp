using System;

namespace task05
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPackagesOfChemicals = int.Parse(Console.ReadLine());
            int numberOfPacketMarkers = int.Parse(Console.ReadLine());
            int litersOfBoardCleaner = int.Parse(Console.ReadLine());
            double percentageReduction = double.Parse(Console.ReadLine());

            double priceOfEverything = numberOfPackagesOfChemicals * 5.80
                + numberOfPacketMarkers * 7.20
                + litersOfBoardCleaner * 1.20;
            double priceWithDiscount = priceOfEverything - ((percentageReduction / 100) * priceOfEverything);

            Console.WriteLine(priceWithDiscount);
        }
    }
}
