using System;
using System.Collections.Generic;
using System.Linq;

namespace task02_Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string []comand = Console.ReadLine().Split();

            while (comand[0] != "end")
            {
                if (comand[0] == "Delete")
                {
                    numbers.Remove(int.Parse(comand[1]));
                }
                else if(comand[0] == "Insert")
                {
                    numbers.Insert(int.Parse(comand[2]), int.Parse(comand[1]));
                }
                comand = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
