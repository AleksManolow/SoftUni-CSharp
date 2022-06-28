using System;

namespace task09
{
    class Program
    {
        static void Main(string[] args)
        {
            string produkt = Console.ReadLine();
            if(produkt == "banana"|| produkt == "apple" 
                || produkt == "kiwi" || produkt == "cherry"
                || produkt == "lemon" || produkt == "grapes")
            {
                Console.WriteLine("fruit");
            }
            else if(produkt == "tomato" || produkt == "cucumber"
                || produkt == "pepper" || produkt == "carrot")
            {
                Console.WriteLine("vegetable");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        
        }
    }
}
