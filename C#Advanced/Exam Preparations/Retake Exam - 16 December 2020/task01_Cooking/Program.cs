using System;
using System.Collections.Generic;
using System.Linq;

namespace task01_Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> liquid = new Queue<int>(input);
            input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Stack<int> ingredient = new Stack<int>(input);

            int countBread = 0;
            int countCake = 0;
            int countPastry = 0;
            int countFruitPie = 0;
            while (liquid.Any() && ingredient.Any())
            {
                int sum = liquid.Peek() + ingredient.Peek();
                if (sum == 25 || sum == 50 || sum ==75 || sum == 100)
                {
                    switch (sum)
                    {
                        case 25:
                            countBread++;
                            break;
                        case 50:
                            countCake++;
                            break;
                        case 75:
                            countPastry++;
                            break;
                        case 100:
                            countFruitPie++;
                            break;
                    }
                    liquid.Dequeue();
                    ingredient.Pop();
                }
                else
                {
                    ingredient.Push(ingredient.Pop() + 3);
                    liquid.Dequeue();
                }

            }
            if (countBread != 0 && countCake != 0 && countFruitPie != 0 && countPastry != 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquid.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine("Liquids left: " + string.Join(", ", liquid));
            }

            if (ingredient.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine("Ingredients left: " + string.Join(", ", ingredient));
            }

            Console.WriteLine($"Bread: {countBread}");
            Console.WriteLine($"Cake: {countCake}");
            Console.WriteLine($"Fruit Pie: {countFruitPie}");
            Console.WriteLine($"Pastry: {countPastry}");
        }
    }
}
