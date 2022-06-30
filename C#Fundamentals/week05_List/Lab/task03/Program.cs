using System;
using System.Collections.Generic;
using System.Linq;

namespace task03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> number1 = Console.ReadLine().Split().Select(double.Parse).ToList();
            List<double> number2 = Console.ReadLine().Split().Select(double.Parse).ToList();
            List<double> result = new List<double>();
            for (int i = 0; i < Math.Max(number1.Count, number2.Count); i++)
            {
                if (number1.Count > i)
                {
                    result.Add(number1[i]);
                }
                if (number2.Count > i)
                {
                    result.Add(number2[i]);
                }
            }
            Console.WriteLine(string.Join(" ", result));

        }
    }
}
