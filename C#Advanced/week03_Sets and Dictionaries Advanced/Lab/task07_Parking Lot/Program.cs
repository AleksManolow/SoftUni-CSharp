using System;
using System.Collections.Generic;

namespace task07_Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            HashSet<string> carsNumbers = new HashSet<string>();
            while (input[0] != "END")
            {
                if (input[0] == "IN")
                {
                    carsNumbers.Add(input[1]);
                }
                else if (input[0] == "OUT")
                {
                    carsNumbers.Remove(input[1]);
                }


                input = Console.ReadLine().Split(", ");
            }
            if (carsNumbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var carNumber in carsNumbers)
                {
                    Console.WriteLine(carNumber);
                }
            }

        }
    }
}
