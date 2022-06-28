using System;

namespace task08
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double sum = 0.0;
            int cout = 0;

            double curr = 0.0;
            while (cout < 12)
            {
                curr = double.Parse(Console.ReadLine());
                if (curr < 4)
                {
                    break;
                }
                sum += curr;
                cout++;
            }
            if (cout == 12)
                Console.WriteLine($"{name} graduated. Average grade: {sum / 12:F2}");
            else
                Console.WriteLine($"{name} has been excluded at {cout + 1} grade");

        }
    }
}
