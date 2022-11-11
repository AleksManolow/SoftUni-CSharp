using CommandPattern.Core.Contracts;
using System;
namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string args = Console.ReadLine();
                string result = commandInterpreter.Read(args);
                Console.WriteLine(result);
            }
        }
    }
}
