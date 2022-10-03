using System;
using System.Collections.Generic;
using System.Linq;

namespace task04_Froggy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> elements = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            Lake lake = new Lake(elements);
            Console.WriteLine(String.Join(", ", lake));
        }
    }
}
