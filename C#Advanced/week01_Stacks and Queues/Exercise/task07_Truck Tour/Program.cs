using System;
using System.Collections.Generic;
using System.Linq;

namespace task07_Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> pump = new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                pump.Enqueue(input);
            }
            int pumpNumber = 0;
            while (true)
            {
                Queue<int[]> tempPump = new Queue<int[]>(pump);
                int intermediateАmounOfPetrol = 0;
                while (tempPump.Count > 0)
                {
                    int[] tempArr = tempPump.Dequeue();
                    intermediateАmounOfPetrol += tempArr[0] - tempArr[1];
                    if (intermediateАmounOfPetrol < 0)
                    {
                        break;
                    }
                }
                if (tempPump.Count == 0)
                {
                    break;
                }
                pump.Enqueue(pump.Dequeue());
                pumpNumber++;
            }
            Console.WriteLine(pumpNumber);
        }
    }
}
