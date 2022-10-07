using System;
using System.Collections.Generic;
using System.Linq;

namespace task01_Flower_Wreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split(",").Select(int.Parse).ToArray();
            Stack<int> lilis = new Stack<int>(inputNumbers);
            inputNumbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Queue<int> rose = new Queue<int>(inputNumbers);

            int sumOfRemove = 0;
            int countOfWreaths = 0;

            while (lilis.Any() && rose.Any())
            {
                int sum = lilis.Peek() + rose.Peek();
                if (sum > 15)
                {
                    lilis.Push(lilis.Pop() - 2);
                }
                else if (sum == 15)
                {
                    lilis.Pop();
                    rose.Dequeue();
                    countOfWreaths++;
                }
                else
                {
                    sumOfRemove += sum;
                    lilis.Pop();
                    rose.Dequeue();
                }
            }
            countOfWreaths += sumOfRemove / 15;
            if (countOfWreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {countOfWreaths } wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - countOfWreaths } wreaths more!");
            }
        }
    }
}
