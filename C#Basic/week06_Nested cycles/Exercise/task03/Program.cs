using System;

namespace task03
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int sumOne = 0;
            int sumTwo = 0;
            while(number != "stop")
            {
                int currNum = int.Parse(number.ToString());
                if(currNum < 0)
                {
                    Console.WriteLine("Number is negative.");
                    number = Console.ReadLine();
                    continue;
                }
                bool isSimple = false;
                for (int i = 2; i < currNum; i++)
                {
                    if( currNum % i == 0)
                    {
                        isSimple = true;
                    }
                }
                if (isSimple)
                    sumOne += currNum;
                else
                    sumTwo += currNum;
                number = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumTwo}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumOne}");
        }
    }
}
