using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace task07_Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split(' ');
            string[] secondLine = Console.ReadLine().Split(' ');
            string[] thirdLine = Console.ReadLine().Split(' ');

            Tuple<string, string> firstTuple = new Tuple<string, string>(firstLine[0] + firstLine[1], firstLine[2]);
            Tuple<string, int> secoundtuple = new Tuple<string, int>(secondLine[0],int.Parse(secondLine[1]));
            Tuple<int, double> thitdTuple = new Tuple<int, double>(int.Parse(thirdLine[0]), double.Parse(thirdLine[1]));

            Console.WriteLine(firstTuple);
            Console.WriteLine(secoundtuple);
            Console.WriteLine(thitdTuple);
        }
    }
}
