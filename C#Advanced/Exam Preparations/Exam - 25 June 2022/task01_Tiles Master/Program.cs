using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace task01_Tiles_Master
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Stack<int> whiteTiles = new Stack<int>(inputNumbers);
            inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> greyTiles = new Queue<int>(inputNumbers);

            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();


            while (whiteTiles.Any() && greyTiles.Any())
            {
                if (whiteTiles.Peek() == greyTiles.Peek())
                {
                    int sumOfTiles = whiteTiles.Peek() + greyTiles.Peek();
                    switch (sumOfTiles)
                    {
                        case 40:
                            if (!keyValuePairs.ContainsKey("Sink"))
                            {
                                keyValuePairs.Add("Sink", 0);
                            }
                            keyValuePairs["Sink"]++;
                            break;
                        case 50:
                            if (!keyValuePairs.ContainsKey("Oven"))
                            {
                                keyValuePairs.Add("Oven", 0);
                            }
                            keyValuePairs["Oven"]++;
                            break;
                        case 60:
                            if (!keyValuePairs.ContainsKey("Countertop"))
                            {
                                keyValuePairs.Add("Countertop", 0);
                            }
                            keyValuePairs["Countertop"]++;
                            break;
                        case 70:
                            if (!keyValuePairs.ContainsKey("Wall"))
                            {
                                keyValuePairs.Add("Wall", 0);
                            }
                            keyValuePairs["Wall"]++;
                            break;
                        default:
                            if (!keyValuePairs.ContainsKey("Floor"))
                            {
                                keyValuePairs.Add("Floor", 0);
                            }
                            keyValuePairs["Floor"]++;
                            break;
                    }
                    whiteTiles.Pop();
                    greyTiles.Dequeue();
                }
                else
                {
                    whiteTiles.Push(whiteTiles.Pop() / 2);
                    greyTiles.Enqueue(greyTiles.Dequeue());
                }
            }

            if (whiteTiles.Count == 0)
                Console.WriteLine("White tiles left: none");
            else
                Console.WriteLine($"White tiles left: " + string.Join(", ", whiteTiles));

            if (greyTiles.Count == 0)
                Console.WriteLine("Grey tiles left: none");
            else
                Console.WriteLine($"Grey tiles left: " + string.Join(", ", greyTiles));


            foreach (var item in keyValuePairs.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
