using System;

namespace task03
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double ownedMoney = double.Parse(Console.ReadLine());
            int dayCounter = 0;
            int spendingCounter = 0;
            while (ownedMoney < neededMoney && spendingCounter < 5)
            {
                string command = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                dayCounter++;
                if (command == "save")
                {
                    ownedMoney += money;
                    spendingCounter = 0;
                }
                else
                {
                    ownedMoney -= money;
                    spendingCounter++;
                    if (ownedMoney < 0) 
                    { 
                        ownedMoney = 0; 
                    }     
                }

            }
            if (spendingCounter == 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(dayCounter);
            }
            if (ownedMoney >= neededMoney)
            {
                Console.WriteLine($"You saved the money for {dayCounter} days.");
            }
        }
    }
}
