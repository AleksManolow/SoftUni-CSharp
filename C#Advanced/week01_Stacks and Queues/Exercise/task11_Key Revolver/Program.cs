using System;
using System.Collections.Generic;
using System.Linq;

namespace task11_Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletValue = int.Parse(Console.ReadLine());
            int sizeOfTheGunBarrel = int.Parse(Console.ReadLine());
            int[] infoBullets = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] infoLocks = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int valueOfTheIntelligence = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(infoBullets);
            Queue<int> locks = new Queue<int>(infoLocks);
            int countOfGunBarrel = 0;
            int totalGun = 0;
            while (locks.Any() && bullets.Any())
            {
                if (bullets.Peek() <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                countOfGunBarrel++;
                totalGun++;
                bullets.Pop();

                if ((countOfGunBarrel % sizeOfTheGunBarrel) == 0 && (bullets.Count > 0))
                {
                    countOfGunBarrel = 0;
                    Console.WriteLine("Reloading!");
                }
            }
            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned $" +
                    $"{valueOfTheIntelligence - (totalGun * bulletValue)}");
            }


        }
    }
}
