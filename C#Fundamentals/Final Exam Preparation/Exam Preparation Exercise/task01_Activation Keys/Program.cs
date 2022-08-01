using System;

namespace task01_Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            string[] input = Console.ReadLine().Split(">>>");
            while (input[0] != "Generate")
            {
                if (input[0] == "Contains")
                {
                    if (key.Contains(input[1]))
                    {
                        Console.WriteLine($"{key} contains {input[1]}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (input[0] == "Flip")
                {
                    if (input[1] == "Upper")
                    {
                        key = key.Substring(0, int.Parse(input[2])) + 
                            key.Substring(int.Parse(input[2]), int.Parse(input[3]) - int.Parse(input[2])).ToUpper() + 
                            key.Substring(int.Parse(input[3]));
                    }
                    else
                    {
                        key = key.Substring(0, int.Parse(input[2])) +
                            key.Substring(int.Parse(input[2]), int.Parse(input[3]) - int.Parse(input[2])).ToLower() +
                            key.Substring(int.Parse(input[3]));
                    }
                    Console.WriteLine(key);
                }
                else if (input[0] == "Slice")
                {
                    key = key.Remove(int.Parse(input[1]), int.Parse(input[2]) - int.Parse(input[1]));
                    Console.WriteLine(key);
                }

                input = Console.ReadLine().Split(">>>");
            }
            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
