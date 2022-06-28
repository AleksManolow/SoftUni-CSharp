using System;

namespace task10
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            if(!((num <= 200 && num >= 100) || num == 0) )
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
