using System;

namespace task06
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == 'a')
                {
                    sum += 1;
                }
                else if(name[i] == 'e')
                {
                    sum += 2;
                }
                else if (name[i] == 'i')
                {
                    sum += 3;
                }
                else if (name[i] == 'o')
                {
                    sum += 4;
                }
                else if (name[i] == 'u')
                {
                    sum += 5;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
