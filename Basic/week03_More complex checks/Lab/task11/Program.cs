using System;

namespace task11
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            if (day == "Monday" || day == "Tuesday"
                || day == "Wednesday" || day == "Thursday"
                || day == "Friday")
            {
                switch (fruit)
                {
                    case "banana":
                        Console.WriteLine("{0:F2}", 2.50 * quantity);
                        break;
                    case "apple":
                        Console.WriteLine("{0:F2}", 1.20 * quantity);
                        break;
                    case "orange":
                        Console.WriteLine("{0:F2}", 0.85 * quantity);
                        break;
                    case "grapefruit":
                        Console.WriteLine("{0:F2}", 1.45 * quantity);
                        break;
                    case "kiwi":
                        Console.WriteLine("{0:F2}", 2.70 * quantity);
                        break;
                    case "pineapple":
                        Console.WriteLine("{0:F2}", 5.50 * quantity);
                        break;
                    case "grapes":
                        Console.WriteLine("{0:F2}", 3.85 * quantity);
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if (day == "Saturday" || day == "Sunday")
            {
                switch (fruit)
                {
                    case "banana":
                        Console.WriteLine("{0:F2}", 2.70 * quantity);
                        break;
                    case "apple":
                        Console.WriteLine("{0:F2}", 1.25 * quantity);
                        break;
                    case "orange":
                        Console.WriteLine("{0:F2}", 0.90 * quantity);
                        break;
                    case "grapefruit":
                        Console.WriteLine("{0:F2}", 1.60 * quantity);
                        break;
                    case "kiwi":
                        Console.WriteLine("{0:F2}", 3.00 * quantity);
                        break;
                    case "pineapple":
                        Console.WriteLine("{0:F2}", 5.60 * quantity);
                        break;
                    case "grapes":
                        Console.WriteLine("{0:F2}", 4.20 * quantity);
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else
            {
                Console.WriteLine("error");
            }

        }
    }
}
