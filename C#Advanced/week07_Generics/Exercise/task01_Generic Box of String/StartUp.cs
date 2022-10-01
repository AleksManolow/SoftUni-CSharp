using System;
using System.Collections.Generic;

namespace task01_Generic_Box_of_String
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Box<string>> list = new List<Box<string>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                list.Add(new Box<string>(input));
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
