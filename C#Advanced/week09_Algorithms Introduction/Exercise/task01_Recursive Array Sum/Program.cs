using System;
using System.Linq;

namespace task01_Recursive_Array_Sum
{
    
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine(Sum(arr, 0));
        }

        public static int Sum(int[] arr, int index)
        {
            if (index == arr.Count() - 1)
            {
                return arr[index];
            }
            return arr[index] + Sum(arr, index + 1);
        }
    }
}
