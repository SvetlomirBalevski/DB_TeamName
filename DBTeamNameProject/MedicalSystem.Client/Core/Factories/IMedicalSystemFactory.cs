using MedicalSystem.Models;
using System.Collections.Generic;

namespace MedicalSystem.Client.Core.Factories
{
    public interface IMedicalSystemFactory
    {
        Specialty CreateSpecialty(string name);
    }
}
