using System;
using System.Collections.Generic;
using System.Linq;

namespace task06
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                string[] comands = input.Split();

                switch (comands[0])
                {
                    case "Add":
                        int numToAdd = int.Parse(comands[1]);
                        numbers.Add(numToAdd);
                        break;
                    case "Remove":
                        int numToRemove = int.Parse(comands[1]);
                        numbers.Remove(numToRemove);
                        break;
                    case "RemoveAt":
                        int indexToRemove = int.Parse(comands[1]);
                        numbers.RemoveAt(indexToRemove);
                        break;
                    case "Insert":
                        int numToInsert = int.Parse(comands[1]);
                        int indexToInsert = int.Parse(comands[2]);
                        numbers.Insert(indexToInsert, numToInsert);
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
