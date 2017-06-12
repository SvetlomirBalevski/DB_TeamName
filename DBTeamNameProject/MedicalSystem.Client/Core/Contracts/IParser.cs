using MedicalSystem.Client.Commands.Contracts;
using System.Collections.Generic;

namespace MedicalSystem.Client.Core.Contracts
{
    public interface IParser
    {
        string ProcessCommand(string commandAsString);
    }
}
