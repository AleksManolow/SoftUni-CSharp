using System;
using System.Collections.Generic;
using System.Linq;

namespace task07_Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string[] input = Console.ReadLine().Split();
            while (input[0] != "End")
            {
                Person person = new Person(input[0], input[1], int.Parse(input[2]));
                bool isCreatorExist = people.Any(x => x.ID == input[1]);
                if (isCreatorExist)
                {
                    for (int i = 0; i < people.Count; i++)
                    {
                        if (input[1] == people[i].ID)
                        {
                            people[i].Name = input[0];
                            people[i].Years = int.Parse(input[2]);
                            break;
                        }
                    }
                }
                else
                {
                    people.Add(person);
                }
                input = Console.ReadLine().Split();
            }
            List<Person> orderedPersons = people.OrderBy(x => x.Years).ToList();
            foreach (Person person in orderedPersons)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Years} years old.");
            }
        }

    }
    class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Years { get; set; }

        public Person(string name, string id, int years)
        {
            Name = name;
            ID = id;
            Years = years;
        }
    }
}
