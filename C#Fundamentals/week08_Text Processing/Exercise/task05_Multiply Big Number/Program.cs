using System;

namespace task05_Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int numberMul = int.Parse(Console.ReadLine());

            string newNumber = "";
            int count = 0;
            int remainder = 0;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                int tempNumber = ((int)number[i] - 48)  * numberMul;
                tempNumber += remainder;

                newNumber += (tempNumber % 10);
                remainder = tempNumber / 10;
                count++;
            }
            if (remainder != 0)
            {
                newNumber += remainder;
            }
            

            string reverse = "";
            for (int i = newNumber.Length - 1; i >= 0 ; i--)
            {
                reverse += newNumber[i];
            }
            Console.WriteLine(reverse);

        }
    }
}
