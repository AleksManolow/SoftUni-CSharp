using System;
using System.Collections.Generic;
using System.Linq;

namespace task01_Barista_Contest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Queue<int> quantitiesCoffee = new Queue<int>(input);
            input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Stack<int> quantitiesMilk = new Stack<int>(input);

            Dictionary<string, int> quantities = new Dictionary<string, int>();

            while (quantitiesCoffee.Any() && quantitiesMilk.Any())
            {
                int sum = quantitiesCoffee.Peek() + quantitiesMilk.Peek();
                if (sum == 50 || sum == 75 || sum == 100 || sum == 150 || sum == 200)
                {
                    switch (sum)
                    {
                        case 50:
                            if (!quantities.ContainsKey("Cortado"))
                            {
                                quantities.Add("Cortado", 0);
                            }
                            quantities["Cortado"]++;
                            break;
                        case 75:
                            if (!quantities.ContainsKey("Espresso"))
                            {
                                quantities.Add("Espresso", 0);
                            }
                            quantities["Espresso"]++;
                            break;
                        case 100:
                            if (!quantities.ContainsKey("Capuccino"))
                            {
                                quantities.Add("Capuccino", 0);
                            }
                            quantities["Capuccino"]++;
                            break;
                        case 150:
                            if (!quantities.ContainsKey("Americano"))
                            {
                                quantities.Add("Americano", 0);
                            }
                            quantities["Americano"]++;
                            break;
                        case 200:
                            if (!quantities.ContainsKey("Latte"))
                            {
                                quantities.Add("Latte", 0);
                            }
                            quantities["Latte"]++;
                            break;
                    }
                    quantitiesCoffee.Dequeue();
                    quantitiesMilk.Pop();
                }
                else
                {
                    quantitiesCoffee.Dequeue();
                    quantitiesMilk.Push(quantitiesMilk.Pop() - 5);
                }
                
            }

            if (quantitiesCoffee.Count == 0 && quantitiesMilk.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (quantitiesCoffee.Count > 0)
                Console.WriteLine("Coffee left: " + string.Join(", ", quantitiesCoffee));
            else
                Console.WriteLine("Coffee left: none");

            if (quantitiesMilk.Count > 0)
                Console.WriteLine("Milk left: " + string.Join(", ", quantitiesMilk));
            else
                Console.WriteLine("Milk left: none");

            
            foreach (var item in quantities.OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

        }
    }
}
