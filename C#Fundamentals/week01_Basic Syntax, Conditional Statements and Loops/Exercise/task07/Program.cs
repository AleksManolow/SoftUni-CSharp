using System;

namespace task07
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double sum = 0;
            while (input != "Start")
            {
                double coins = double.Parse(input);
                if (coins == 2 || coins == 1 || coins == 0.5 || coins == 0.2 || coins == 0.1)
                {
                    sum += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                    break;
                }

                input = Console.ReadLine();
            }
            while (input != "End")
            {
                input = Console.ReadLine();
                if (input == "Nuts")
                {
                    if (sum - 2 >= 0)
                    {
                        Console.WriteLine($"Purchased {input.ToLower()}");
                        sum -= 2;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    
                }
                else if (input == "Water")
                {              
                    if (sum - 0.7 >= 0)
                    {
                        Console.WriteLine($"Purchased {input.ToLower()}");
                        sum -= 0.7;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Crisps")
                {
                    if (sum - 1.5 >= 0)
                    {
                        Console.WriteLine($"Purchased {input.ToLower()}");
                        sum -= 1.5;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Soda")
                {
                    if (sum - 0.8 >= 0)
                    {
                        Console.WriteLine($"Purchased {input.ToLower()}");
                        sum -= 0.8;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Coke")
                {
                    if (sum - 1 >= 0)
                    {
                        Console.WriteLine($"Purchased {input.ToLower()}");
                        sum -= 1;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if(input != "End")
                {
                    Console.WriteLine("Invalid product");
                }
            }
            Console.WriteLine($"Change: {sum:F2}");
        }
    }
}
