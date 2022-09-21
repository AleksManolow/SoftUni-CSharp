using System;
using System.Collections.Generic;
using System.Linq;

namespace task03_Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> chemicalCompounds = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                foreach (var c in input)
                {
                        chemicalCompounds.Add(c);
                }
            }
            chemicalCompounds = chemicalCompounds.OrderBy(x => x).ToHashSet();
            foreach (var c in chemicalCompounds)
            {
                Console.Write(c + " ");
            }
        }
    }
}
