using System;
using System.Collections.Generic;
using System.Threading;

namespace task05_ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string[] input = Console.ReadLine().Split(' ');
            while (input[0] != "END")
            {

                people.Add(new Person(input[0], int.Parse(input[1]), input[2]));

                input = Console.ReadLine().Split(' ');
            }

            int n = int.Parse(Console.ReadLine());
            Person personToCompere = people[n - 1];

            int equal = 0;
            int deff = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(personToCompere) == 0)
                {
                    equal++;
                }
                else
                {
                    deff++;
                }
            }
            if (equal == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equal} {deff} {people.Count}");
            }
            
        }
    }
}
