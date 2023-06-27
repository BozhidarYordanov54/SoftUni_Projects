using CommandPattern.Core.Contracts;
using CommandPattern.Exceptions;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core.CommandIterpreter
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public CommandInterpreter()
        {

        }
        public string Read(string args)
        {
            string[] tokens = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandName = (tokens[0] + "Command").ToLower();
            string[] cmdArgs = tokens.Skip(1).ToArray();

            Type type = Assembly.GetCallingAssembly()
                 .GetTypes()
                 .FirstOrDefault(t => t.Name.ToLower() == commandName);

            if (type == null)
            {
                throw new InvalidCommandException();
            }

            ICommand instanceType = Activator.CreateInstance(type) as ICommand;

            if (instanceType == null)
            {
                throw new InvalidCommandException();
            }

            return instanceType.Execute(cmdArgs);
        }
    }
}
