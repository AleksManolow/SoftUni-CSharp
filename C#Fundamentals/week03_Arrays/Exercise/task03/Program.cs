using System;
using System.Linq;

namespace task03
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[2];

            int[] evenElPositionArr = new int [n];
            int[] oddElPositionArr = new int [n];
            for (int i = 0; i < n; i++)
            {
                arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (i % 2 == 0)
                {
                    evenElPositionArr[i] = arr[0];
                    oddElPositionArr[i] = arr[1];
                }
                else
                {
                    evenElPositionArr[i] = arr[1];
                    oddElPositionArr[i] = arr[0];
                }
            }
            Console.WriteLine(string.Join(' ', evenElPositionArr));
            Console.WriteLine(string.Join(' ', oddElPositionArr));
        }
    }
}
