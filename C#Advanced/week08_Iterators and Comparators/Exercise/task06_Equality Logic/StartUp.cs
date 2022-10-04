using System;
using System.Collections.Generic;

namespace task06_Equality_Logic
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<Person> peopleHashSet = new HashSet<Person>();
            SortedSet<Person> poepleSortedSet = new SortedSet<Person>();    
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                peopleHashSet.Add(new Person(input[0], int.Parse(input[1])));
                poepleSortedSet.Add(new Person(input[0], int.Parse(input[1])));
            }
            Console.WriteLine(poepleSortedSet.Count);
            Console.WriteLine(peopleHashSet.Count);
            
        }
    }
}
