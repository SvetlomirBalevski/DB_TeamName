using System.Collections.Generic;

namespace MedicalSystem.Client.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
