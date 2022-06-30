using System;

namespace task08
{
    class Program
    {
        static void Main(string[] args)
        {
            int bace = int.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            Console.WriteLine(recPow(bace, power));
        }
        static int recPow(int bace, int power)
        {
            if (power == 0)
            {
                return 1;
            }
            return bace * recPow(bace, power - 1);
        }
    }
}
