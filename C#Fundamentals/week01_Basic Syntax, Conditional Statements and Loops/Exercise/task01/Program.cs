﻿using System;

namespace task01
{
    class Program
    {
        static void Main(string[] args)
        {

            int age = int.Parse(Console.ReadLine());
            if (age <= 2)
                Console.WriteLine("baby");
            else if (age >= 3 && age <= 13)
                Console.WriteLine("child");
            else if (age >= 14 && age <= 19)
                Console.WriteLine("teenager");
            else if (age >= 20 && age <= 65)
                Console.WriteLine("adult");
            else
                Console.WriteLine("elder");
        }   
    }
}
