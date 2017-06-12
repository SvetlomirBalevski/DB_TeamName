using MedicalSystem.Client.Common.Exceptions;
using MedicalSystem.Client.Core.Contracts;
using MedicalSystem.Client.Core.Factories;
using System.Linq;

namespace MedicalSystem.Client.Core.Providers
{
    public class CommandParser : IParser
    {
        private readonly ICommandsFactory commandsFactory;

        public CommandParser(ICommandsFactory commandsFactory)
        {
            this.commandsFactory = commandsFactory;
        }

        public string ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new UserValidationException("Command cannot be null or empty.");
            }

            var command = this.commandsFactory.CreateCommandFromString(commandAsString.Split(' ')[0]);
            var executionResult = command.Execute(commandAsString.Split(' ').Skip(1).ToList());
            return executionResult;
        }
    }
}
