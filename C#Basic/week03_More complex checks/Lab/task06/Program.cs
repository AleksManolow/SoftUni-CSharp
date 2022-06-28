using System;

namespace task06
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            if(city == "Sofia")
            {
                switch (product)
                {
                    case "coffee":
                        Console.WriteLine(0.50 * quantity);
                        break;
                    case "water":
                        Console.WriteLine(0.80 * quantity);
                        break;
                    case "beer":
                        Console.WriteLine(1.20 * quantity);
                        break;
                    case "sweets":
                        Console.WriteLine(1.45 * quantity);
                        break;
                    case "peanuts":
                        Console.WriteLine(1.60 * quantity);
                        break;
                    default:
                        Console.WriteLine("unknown");
                        break;
                }
            }
            else if(city == "Plovdiv")
            {
                switch (product)
                {
                    case "coffee":
                        Console.WriteLine(0.40 * quantity);
                        break;
                    case "water":
                        Console.WriteLine(0.70 * quantity);
                        break;
                    case "beer":
                        Console.WriteLine(1.15 * quantity);
                        break;
                    case "sweets":
                        Console.WriteLine(1.30 * quantity);
                        break;
                    case "peanuts":
                        Console.WriteLine(1.50 * quantity);
                        break;
                    default:
                        Console.WriteLine("unknown");
                        break;
                }
            }
            else
            {
                switch (product)
                {
                    case "coffee":
                        Console.WriteLine(0.45 * quantity);
                        break;
                    case "water":
                        Console.WriteLine(0.70 * quantity);
                        break;
                    case "beer":
                        Console.WriteLine(1.10 * quantity);
                        break;
                    case "sweets":
                        Console.WriteLine(1.35 * quantity);
                        break;
                    case "peanuts":
                        Console.WriteLine(1.55 * quantity);
                        break;
                    default:
                        Console.WriteLine("unknown");
                        break;
                }
            }
        }
    }
}
