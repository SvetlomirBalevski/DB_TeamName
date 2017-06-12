using MedicalSystem.Client.Core.Contracts;
using System;

namespace MedicalSystem.Client.Core.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
