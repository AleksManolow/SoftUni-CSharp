using System;

namespace task03
{
    class Program
    {
        static void Main(string[] args)
        {
            double depositAmount = double.Parse(Console.ReadLine());
            int termOfDeposit = int.Parse(Console.ReadLine());
            double annualInterestRate = double.Parse(Console.ReadLine());

            double sum = depositAmount + termOfDeposit * ((depositAmount * (annualInterestRate / 100)) / 12);
            Console.WriteLine(sum);
        }
    }
}
