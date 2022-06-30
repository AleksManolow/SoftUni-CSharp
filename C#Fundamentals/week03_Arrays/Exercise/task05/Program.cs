using System;
using System.Linq;

namespace task05
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < elements.Length; i++)
            {
                bool isTop = true;
                for (int j = i + 1; j < elements.Length; j++)
                {
                    if (elements[i] <= elements[j])
                    {
                        isTop = false;
                        break;
                    }
                }

                if (isTop)
                {
                    Console.Write(elements[i] + " ");
                }
            }
        }
    }
}
