using System;
using System.Collections.Generic;
using System.Linq;

namespace task05_Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string lineInput = Console.ReadLine();
            Dictionary<char, int> symbolsCount = new Dictionary<char, int>();
            foreach (var symbol in lineInput)
            {
                if (!symbolsCount.ContainsKey(symbol))
                {
                    symbolsCount.Add(symbol, 0);
                }
                symbolsCount[symbol]++;
            }
            foreach (var symbol in symbolsCount.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value))
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
