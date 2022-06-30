using System;

namespace task03
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();

            double price = 0;

            if (day == "Friday")
            {
                if (type == "Students")
                {
                    price = 8.45 * countOfPeople;
                    if (countOfPeople >= 30)
                    {
                        price -= price * 0.15;
                    }
                }
                else if (type == "Business")
                {
                    price = 10.90 * countOfPeople;
                    if (countOfPeople >= 100)
                    {
                        price -= 10 * 10.90;
                    }
                }
                else if (type == "Regular")
                {
                    price = 15 * countOfPeople;
                    if (countOfPeople >= 10 && countOfPeople <= 20)
                    {
                        price -= price * 0.05;
                    }
                }
            }
            else if (day == "Saturday")
            {
                if (type == "Students")
                {
                    price = 9.80 * countOfPeople;
                    if (countOfPeople >= 30)
                    {
                        price -= price * 0.15;
                    }
                }
                else if (type == "Business")
                {
                    price = 15.60 * countOfPeople;
                    if (countOfPeople >= 100)
                    {
                        price -= 10 * 15.60;
                    }
                }
                else if (type == "Regular")
                {
                    price = 20 * countOfPeople;
                    if (countOfPeople >= 10 && countOfPeople <= 20)
                    {
                        price -= price * 0.05;
                    }
                }
            }
            else if (day == "Sunday")
            {
                if (type == "Students")
                {
                    price = 10.46 * countOfPeople;
                    if (countOfPeople >= 30)
                    {
                        price -= price * 0.15;
                    }
                }
                else if (type == "Business")
                {
                    price = 16 * countOfPeople;
                    if (countOfPeople >= 100)
                    {
                        price -= 10 * 16;
                    }
                }
                else if (type == "Regular")
                {
                    price = 22.50 * countOfPeople;
                    if (countOfPeople >= 10 && countOfPeople <= 20)
                    {
                        price -= price * 0.05;
                    }
                }
            }
            Console.WriteLine($"Total price: {price:F2}");
        }
    }
}
