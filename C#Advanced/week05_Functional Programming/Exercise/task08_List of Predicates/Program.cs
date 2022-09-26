using System;
using System.Collections.Generic;
using System.Linq;

namespace task08_List_of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> numbers = Enumerable.Range(1, n).ToList();

            int[] divNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            List<Predicate<int>> predicats = new List<Predicate<int>>();
            foreach (var number in divNumbers)
            {
                predicats.Add(x => x % number != 0);
            }

            foreach (var number in numbers)
            {
                bool isDiv = true;
                foreach (var predicat in predicats)
                {
                    if (predicat(number))
                    {
                        isDiv = false;
                        break;
                    }
                }
                if(isDiv)
                    Console.Write(number + " ");
            }
        }
    }
}
