using System;
using System.Linq;

namespace task08
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (elements.Length != 1)
            {
                int[] newArrElements = new int[elements.Length - 1];
                for (int i = 0; i < newArrElements.Length; i++)
                {
                    newArrElements[i] = elements[i] + elements[i + 1];
                }
                elements = newArrElements;
            }
            Console.WriteLine(elements[0]);

        }
    }
}
