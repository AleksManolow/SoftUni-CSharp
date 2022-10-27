using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task03_Telephony
{
    public class Engine
    {
        private Smartphone smartphone;
        private List<string> phoneNumbers;
        private List<string> urls;

        public Engine()
        {
            this.smartphone = new Smartphone();
            this.phoneNumbers = new List<string>();
            this.urls = new List<string>();
        }

        public void Run()
        {
            this.phoneNumbers = Console.ReadLine().Split(' ').ToList();
            this.urls = Console.ReadLine().Split(' ').ToList();

            foreach (var number in phoneNumbers)
            {
                try
                {
                    Console.WriteLine(smartphone.Call(number));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            

            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(smartphone.Brow(url));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                
            }
            
        }
    } 
}
