using System;

namespace task08_Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);

            double result = 0;
            foreach (var item in input)
            {
                double number = int.Parse(item.Substring(1, item.Length - 2));
                if (char.IsUpper(item[0]) && char.IsUpper(item[item.Length - 1]))
                {
                    number /= ((int)item[0] - 64);
                    number -= ((int)item[item.Length - 1] - 64);

                }
                else if (char.IsUpper(item[0]) && char.IsLower(item[item.Length - 1]))
                {
                    number /= ((int)item[0] - 64);
                    number += ((int)item[item.Length - 1] - 96);
                }
                else if (char.IsLower(item[0]) && char.IsUpper(item[item.Length - 1]))
                {
                    number *= ((int)item[0] - 96);
                    number -= ((int)item[item.Length - 1] - 64);
                }
                else if (char.IsLower(item[0]) && char.IsLower(item[item.Length - 1]))
                {
                    number *= ((int)item[0] - 96);
                    number += ((int)item[item.Length - 1] - 96);
                }
                result += number;
            }
            Console.WriteLine($"{result:F2}");
        }
    }
}
