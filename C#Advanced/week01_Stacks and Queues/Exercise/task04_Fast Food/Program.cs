using System;
using System.Collections.Generic;
using System.Linq;

namespace task04_Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());
            int[] quantityOfOrder = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> quantiyOfOrderQueue = new Queue<int>(quantityOfOrder);
            Console.WriteLine(quantiyOfOrderQueue.Max());

            while (quantiyOfOrderQueue.Count > 0)
            {
                if (quantityFood < quantiyOfOrderQueue.Peek())
                {
                    break;
                }
                quantityFood -= quantiyOfOrderQueue.Dequeue();
            }
            if (quantiyOfOrderQueue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine("Orders left: " + string.Join(", ", quantiyOfOrderQueue));
            }
        }
    }
}
