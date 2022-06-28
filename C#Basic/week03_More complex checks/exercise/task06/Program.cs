using System;

namespace task06
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            char opr = char.Parse(Console.ReadLine());

            double result = 0;
            if(opr == '+')
            {
                result = n1 + n2;
                if(result % 2 == 0)
                    Console.WriteLine($"{n1} + {n2} = {Math.Round(result, 2)} - even");
                else
                    Console.WriteLine($"{n1} + {n2} = {Math.Round(result, 2)} - odd");
            }
            else if(opr == '-')
            {
                result = n1 - n2;
                if(result % 2 == 0)
                    Console.WriteLine($"{n1} - {n2} = {Math.Round(result, 2)} - even");
                else
                    Console.WriteLine($"{n1} - {n2} = {Math.Round(result, 2)} - odd");
            }
            else if(opr == '*')
            {
                result = n1 * n2;
                if(result % 2 == 0)
                    Console.WriteLine($"{n1} * {n2} = {Math.Round(result, 2)} - even");
                else
                    Console.WriteLine($"{n1} * {n2} = {Math.Round(result, 2)} - odd");
            }
            else if(opr == '/')
            {
                if(n2 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else
                {
                    result = n1 / n2;
                    Console.WriteLine($"{n1} / {n2} = {result:F2}");
                }       
            }
            else
            {
                if (n2 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else
                {
                    result = n1 % n2;
                    Console.WriteLine($"{n1} % {n2} = {Math.Round(result, 2)}");
                }
            }  
        }
    }
}
