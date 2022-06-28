using System;

namespace task12
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
            
            if(sales < 0)
            {
                Console.WriteLine("error");
            }
            else if(city == "Sofia")
            {
                if (0 <= sales && sales <= 500) 
                {
                    Console.WriteLine("{0:F2}", 0.05 * sales);
                }
                else if(sales <= 1000)
                {
                    Console.WriteLine("{0:F2}", 0.07 * sales);
                }
                else if(sales <= 10000)
                {
                    Console.WriteLine("{0:F2}", 0.08 * sales);
                }
                else
                {
                    Console.WriteLine("{0:F2}", 0.12 * sales);
                }
            }
            else if(city == "Varna")
            {
                if (0 <= sales && sales <= 500)
                {
                    Console.WriteLine("{0:F2}", 0.045 * sales);
                }
                else if (sales <= 1000)
                {
                    Console.WriteLine("{0:F2}", 0.075 * sales);
                }
                else if (sales <= 10000)
                {
                    Console.WriteLine("{0:F2}", 0.1 * sales);
                }
                else
                {
                    Console.WriteLine("{0:F2}", 0.13 * sales);
                }
            }
            else if(city == "Plovdiv")
            {
                if (0 <= sales && sales <= 500)
                {
                    Console.WriteLine("{0:F2}", 0.055 * sales);
                }
                else if (sales <= 1000)
                {
                    Console.WriteLine("{0:F2}", 0.08 * sales);
                }
                else if (sales <= 10000)
                {
                    Console.WriteLine("{0:F2}", 0.12 * sales);
                }
                else
                {
                    Console.WriteLine("{0:F2}", 0.145 * sales);
                }
            }
            else
            {
                Console.WriteLine("error");
            }


        }
    }
}
