using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core.Engine
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter command)
        {
            commandInterpreter = command;
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                string result = this.commandInterpreter.Read(input);
                Console.WriteLine(result);
            }
        }
    }
}
