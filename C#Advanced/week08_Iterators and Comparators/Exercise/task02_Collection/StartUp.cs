using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace IteratorsAndComparators
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split().Skip(1).ToList();
            ListyIterator<string> iterator = new ListyIterator<string>(elements);
            string[] command = Console.ReadLine().Split(' ');

            try
            {
                while (command[0] != "END")
                {
                    if (command[0] == "Move")
                    {
                        Console.WriteLine(iterator.Move());
                    }
                    else if (command[0] == "HasNext")
                    {
                        Console.WriteLine(iterator.HasNext());
                    }
                    else if (command[0] == "Print")
                    {
                        iterator.Print();
                    }
                    else if (command[0] == "PrintAll")
                    {
                        foreach (var item in iterator)
                        {
                            Console.Write($"{item} ");
                        }
                        Console.WriteLine();
                    }

                    command = Console.ReadLine().Split(' ');
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
