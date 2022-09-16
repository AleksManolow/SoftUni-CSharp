using System;
using System.Collections.Generic;
using System.Linq;

namespace task10_Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            int totalCarsCrossroads = 0;
            bool isCrashHappened = false;
            while (command != "END")
            {
                if (command == "green")
                {
                    int tempGreenLight = greenLight;
                    while (cars.Any() && !isCrashHappened)
                    {
                        if (tempGreenLight == 0)
                        {
                            break;
                        }
                        else if (cars.Peek().Length <=  tempGreenLight)
                        {
                            tempGreenLight -= cars.Peek().Length;
                            cars.Dequeue();
                            totalCarsCrossroads++;
                        }
                        else if (cars.Peek().Length <= tempGreenLight + freeWindow)
                        {
                            tempGreenLight = 0;
                            cars.Dequeue();
                            totalCarsCrossroads++;
                        }
                        else
                        {
                            tempGreenLight = 0;
                            isCrashHappened = true;
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{cars.Peek()} was hit at {cars.Peek()[tempGreenLight + freeWindow + 1]}.");
                            cars.Dequeue();
                            break;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            if (!isCrashHappened)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCarsCrossroads} total cars passed the crossroads.");
            }
        }
    }
}
