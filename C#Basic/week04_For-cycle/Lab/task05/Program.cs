using System;

namespace task05
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            for (int i = 0; i < name.Length ; i++)
            {
                Console.WriteLine(name[i]);
            }
        }
    }
}
