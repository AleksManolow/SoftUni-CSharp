using System;

namespace task03
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            int numberOfPeople = int.Parse(Console.ReadLine());

            Console.WriteLine(Math.Ceiling((double)capacity / numberOfPeople));
        }
    }
}
