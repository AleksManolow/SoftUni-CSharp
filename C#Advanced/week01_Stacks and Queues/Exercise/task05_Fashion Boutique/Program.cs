using System;
using System.Collections.Generic;
using System.Linq;

namespace task05_Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothingValues = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int capacityOfRack = int.Parse(Console.ReadLine());

            Stack<int> clothingValuesStack = new Stack<int>(clothingValues);
            int countRack = 0;
            int countCapacity = capacityOfRack;
            while (clothingValuesStack.Count > 0)
            {
                if (clothingValuesStack.Peek() <= countCapacity)
                {
                    countCapacity -= clothingValuesStack.Pop();
                }
                else
                {
                    countCapacity = capacityOfRack;
                    countRack++;
                }
            }
            if (countCapacity < capacityOfRack)
            {
                countRack++;
            }
            Console.WriteLine(countRack);
        }
    }
}
