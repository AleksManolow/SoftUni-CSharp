using System;
using System.Collections.Generic;
using System.Linq;

namespace task05_Play_Catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int count = 0;
            while (count != 3)
            {
                string[] commands = Console.ReadLine().Split(' ');
                try
                {
                    switch (commands[0])
                    {
                        case "Replace":
                            {
                                int index = int.Parse(commands[1]);
                                int element = int.Parse(commands[2]);

                                numbers[index] = element;
                                break;
                            }
                        case "Print":
                            {
                                int startIndex = int.Parse(commands[1]);
                                int endIndex = int.Parse(commands[2]);

                                var rangeToPrint = new List<int>();

                                for (int i = startIndex; i <= endIndex; i++)
                                {
                                    rangeToPrint.Add(numbers[i]);
                                }

                                Console.WriteLine(string.Join(", ", rangeToPrint));
                                break;
                            }        
                        case "Show":
                            {
                                int index = int.Parse(commands[1]);
                                Console.WriteLine(numbers[index]);
                                break;
                            }
                            
                        
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    count++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    count++;
                }
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
