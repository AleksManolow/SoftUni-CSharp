using System;

namespace task07
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGroubs = int.Parse(Console.ReadLine());
            int countPeople = 0;
            double cMusala = 0;
            double cMonblan = 0;
            double cKilimandjaro = 0;
            double cK2 = 0;
            double cEverest = 0;

            for (int i = 0; i < numberOfGroubs; i++)
            {
                int numberOfPeoples = int.Parse(Console.ReadLine());
                countPeople += numberOfPeoples;
                if (numberOfPeoples < 6)
                {
                    cMusala += numberOfPeoples;
                }
                else if (numberOfPeoples < 13)
                {
                    cMonblan += numberOfPeoples;
                }
                else if (numberOfPeoples < 26)
                {
                    cKilimandjaro += numberOfPeoples;
                }
                else if (numberOfPeoples < 41)
                {
                    cK2 += numberOfPeoples;
                }
                else 
                {
                    cEverest += numberOfPeoples;
                }
            }
            
            Console.WriteLine($"{(cMusala / countPeople)* 100:F2}%");
            Console.WriteLine($"{(cMonblan / countPeople) * 100:F2}%");
            Console.WriteLine($"{(cKilimandjaro / countPeople) * 100:F2}%");
            Console.WriteLine($"{(cK2 / countPeople) * 100:F2}%");
            Console.WriteLine($"{(cEverest/ countPeople) * 100:F2}%");
        }
    }
}
