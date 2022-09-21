using System;
using System.Collections.Generic;

namespace task08_SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();  
            string input = Console.ReadLine();
            while (input != "PARTY")
            {
                guests.Add(input);
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "END")
            {
                if (guests.Contains(input))
                {
                    guests.Remove(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(guests.Count);
            foreach (var item in guests)
            {
                if (Char.IsDigit(input[0]))
                    Console.WriteLine(item);
                
            }
            foreach(var item in guests)
            {
                if (Char.IsLetter(input[0]))
                    Console.WriteLine(item);
            }
        }
    }
}
