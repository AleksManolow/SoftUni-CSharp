using System;
using System.Numerics;

namespace task11
{
    class Program
    {
        static void Main(string[] args)
        {
            int snowBalls = int.Parse(Console.ReadLine());
            BigInteger snowBallValue = 0;
            BigInteger snowBallShow= 0;
            BigInteger snowBallTime = 0;
            int snowBallQuality = 0;
            BigInteger bestSnowBall = int.MinValue;

            string bestSnowBallName = "";

            for (int i = 0; i < snowBalls; i++)
            {
                snowBallShow = BigInteger.Parse(Console.ReadLine());
                snowBallTime = BigInteger.Parse(Console.ReadLine());
                snowBallQuality = int.Parse(Console.ReadLine());

                BigInteger currentSnowBallValue = snowBallShow / snowBallTime;
                snowBallValue = BigInteger.Pow(currentSnowBallValue, snowBallQuality);
                if (snowBallValue > bestSnowBall)
                {
                    bestSnowBall = snowBallValue;
                    bestSnowBallName = $"{ snowBallShow } : {snowBallTime} = {snowBallValue} ({snowBallQuality})";
                }
            }
            Console.WriteLine(bestSnowBallName);
        }
    }
}
