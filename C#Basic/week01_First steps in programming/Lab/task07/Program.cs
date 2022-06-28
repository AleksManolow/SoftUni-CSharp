using System;

namespace task07
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameАrchitecture = Console.ReadLine();
            int numberOfProjects = int.Parse(Console.ReadLine());
            int requiredHours = numberOfProjects * 3;
            Console.WriteLine($"The architect {nameАrchitecture} will need {requiredHours} hours to complete {numberOfProjects} project/s.");
        }
    }
}
