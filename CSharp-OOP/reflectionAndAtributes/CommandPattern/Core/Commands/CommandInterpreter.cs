namespace CommandPattern.Core.Models
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Core.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string result = string.Empty;

            string[] inputInfo = args.Split();

            string commandName = inputInfo[0] + "Command";

            string[] parameters = inputInfo[1..];

            ICommand command = null;

            Type classType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == commandName);

            if (classType != null)
            {
                command = (ICommand)Activator.CreateInstance(classType, new object[] { });
                result = command.Execute(parameters);
            }
            else
            {
                throw new InvalidOperationException("Invalid command");
            }
            return result;
        }
    }
}
