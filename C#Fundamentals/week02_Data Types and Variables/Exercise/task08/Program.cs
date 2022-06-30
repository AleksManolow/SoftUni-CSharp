using System;

namespace task08
{
    class Program
    {
        static void Main(string[] args)
        {
            int nLines = int.Parse(Console.ReadLine());

            double bigestKeg = double.MinValue;
            string bigestKegName = "";

            for (int i = 0; i < nLines; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int hight = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * hight;
                if (volume > bigestKeg)
                {
                    bigestKeg = volume;
                    bigestKegName = model;
                }
            }
            Console.WriteLine(bigestKegName);

        }
    }
}
