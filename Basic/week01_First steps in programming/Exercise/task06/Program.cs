using System;

namespace task06
{
    class Program
    {
        static void Main(string[] args)
        {
            int requiredAmountOfNylon = int.Parse(Console.ReadLine());
            int requiredAmountOfCombat = int.Parse(Console.ReadLine());
            int amountOfDiluent = int.Parse(Console.ReadLine());
            int hoursForWhichTheMastersWillDoWork = int.Parse(Console.ReadLine());

            double total = (requiredAmountOfNylon + 2) * 1.50 +
                (requiredAmountOfCombat + (requiredAmountOfCombat * 0.1)) * 14.50 +
                amountOfDiluent * 5.00 + 0.40;
            double endSum = total + ((total * 0.30) * hoursForWhichTheMastersWillDoWork);
            Console.WriteLine(endSum);
        }
    }
}
