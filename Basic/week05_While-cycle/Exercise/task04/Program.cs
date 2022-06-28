using System;

namespace task04
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            int sumSteps = 0;
            while(sumSteps < 10000)
            {
                input = Console.ReadLine();
                if (input == "Going home")
                {
                    input = Console.ReadLine();
                    sumSteps += (int.Parse(input));
                    break;
                }
                sumSteps += (int.Parse(input));
            }
            if (sumSteps >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{sumSteps - 10000} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{10000 - sumSteps} more steps to reach goal.");
            }
        }
    }
}
