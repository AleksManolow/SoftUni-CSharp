using System;

namespace task07
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int minNum = int.MaxValue;
            while (input != "Stop")
            {
                int num = int.Parse(input);
                if (minNum > num)
                {
                    minNum = num;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(minNum);
        }
    }
}
