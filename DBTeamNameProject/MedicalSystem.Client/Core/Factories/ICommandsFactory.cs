using MedicalSystem.Client.Commands.Contracts;

namespace MedicalSystem.Client.Core.Factories
{
    public interface ICommandsFactory
    {
        ICommand CreateCommandFromString(string commandName);
    }
}
