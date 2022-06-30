using System;
using System.Collections.Generic;
using System.Linq;

namespace task09_Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int index;
            List<int> removeEl = new List<int>();
            while (pokemons.Count != 0)
            {
                index = int.Parse(Console.ReadLine());
                if (index < 0)
                {
                    int temp = pokemons[0];
                    pokemons[0] = pokemons[pokemons.Count - 1];
                    removeEl.Add(temp);
                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (pokemons[i] <= temp)
                        {
                            pokemons[i] += temp;
                        }
                        else
                        {
                            pokemons[i] -= temp;
                        }
                    }
                }
                else if (index >= pokemons.Count)
                {
                    int temp = pokemons[pokemons.Count - 1];
                    pokemons[pokemons.Count - 1] = pokemons[0];
                    removeEl.Add(temp);
                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (pokemons[i] <= temp)
                        {
                            pokemons[i] += temp;
                        }
                        else
                        {
                            pokemons[i] -= temp;
                        }
                    }
                }
                else
                {
                    int valueOfRemoveEl = pokemons[index];
                    removeEl.Add(valueOfRemoveEl);
                    pokemons.RemoveAt(index);
                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (pokemons[i] <= valueOfRemoveEl)
                        {
                            pokemons[i] += valueOfRemoveEl;
                        }
                        else
                        {
                            pokemons[i] -= valueOfRemoveEl;
                        }
                    }

                }
            }
            Console.WriteLine(removeEl.Sum());
        }
    }
}
