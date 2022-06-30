using System;

namespace task01
{
    class Program
    {
        static void Main(string[] args)
        {

            
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                Console.WriteLine(input.GetType());
                if (input.GetType() == typeof(int))
                {
                    Console.WriteLine($"{ input} is { input.GetType()} type");
                }
                
            }
        }
    }
}
