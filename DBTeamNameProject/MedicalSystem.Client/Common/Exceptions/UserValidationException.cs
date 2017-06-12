using System;

namespace MedicalSystem.Client.Common.Exceptions
{
    public class UserValidationException : Exception
    {
        public UserValidationException(string msg)
            : base(" - Error: " + msg)
        {
        }
    }
}
