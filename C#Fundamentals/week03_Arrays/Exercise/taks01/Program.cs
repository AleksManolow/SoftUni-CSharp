using System;
using System.Linq;

namespace taks01
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] elements = new int[size];
            for (int i = 0; i < size; i++)
            {
                elements[i] = int.Parse(Console.ReadLine());
            }
            

            int sum = 0;
            foreach (int element in elements)
            {
                sum += element;
            }
            Console.WriteLine(string.Join(' ', elements));
            Console.WriteLine(sum);
        }
    }
}
