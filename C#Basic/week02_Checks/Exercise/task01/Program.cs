using System;

namespace task01
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine());
            int secoundTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());

            int totalTime = firstTime + secoundTime + thirdTime;

            int min = totalTime / 60;
            int sec = totalTime % 60;

            if (sec < 10)
                Console.WriteLine($"{min}:0{sec}");
            else
                Console.WriteLine($"{min}:{sec}");
        }
    }
}
