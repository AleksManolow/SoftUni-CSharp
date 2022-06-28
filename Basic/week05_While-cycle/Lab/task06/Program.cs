using System;

namespace task06
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int maxNum = int.MinValue;
            while (input != "Stop")
            {
                int num = int.Parse(input);
                if(maxNum < num)
                {
                    maxNum = num;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(maxNum);
        }
    }
}
