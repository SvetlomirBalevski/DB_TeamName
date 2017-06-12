using System;

namespace MedicalSystem.Client.Common.Exceptions
{
    public class DatabaseValidationException : Exception
    {
        public DatabaseValidationException(string msg)
            : base(" - Database error: " + msg)
        {
        }
    }
}
