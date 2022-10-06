using System;
using System.Collections.Generic;
using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace task01_Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Queue<int> bombEffects = new Queue<int>(inputArr);
            inputArr = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Stack<int> bombCasing = new Stack<int>(inputArr);


            int countDaturaBombs = 0;
            int countCherryBombs = 0;
            int countSmokeDecoyBombs = 0;

            bool isFilled = false;
            while (bombEffects.Any() && bombCasing.Any())
            {
                int sum = bombCasing.Peek() + bombEffects.Peek();
                if (sum == 40 || sum == 60 || sum == 120)
                {
                    switch (sum)
                    {
                        case 40:
                            countDaturaBombs++;
                            break;
                        case 60:
                            countCherryBombs++;
                            break;
                        case 120:
                            countSmokeDecoyBombs++;
                            break;
                    }
                    bombCasing.Pop();
                    bombEffects.Dequeue();
                    if (countDaturaBombs >= 3 && countCherryBombs >= 3 && countSmokeDecoyBombs >= 3)
                    {
                        isFilled = true;
                        break;
                    }
                }
                else
                {
                    bombCasing.Push(bombCasing.Pop() - 5);
                }

            }
            if (isFilled)
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            else
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");

            if (bombEffects.Count == 0)
                Console.WriteLine("Bomb Effects: empty");
            else
                Console.WriteLine("Bomb Effects: " + string.Join(", ", bombEffects));

            if (bombCasing.Count == 0)
                Console.WriteLine("Bomb Casings: empty");
            else
                Console.WriteLine("Bomb Casings: " + string.Join(", ", bombCasing));

            Console.WriteLine($"Cherry Bombs: {countCherryBombs}");
            Console.WriteLine($"Datura Bombs: {countDaturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {countSmokeDecoyBombs}");
        }
    }
}
