using Bytes2you.Validation;
using MedicalSystem.Client.Commands.Contracts;
using MedicalSystem.Client.Common.Exceptions;
using MedicalSystem.Client.Core.Factories;
using MedicalSystem.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Client.Commands.Listing
{
    public class ListAllCommand : ICommand
    {
        private readonly IMedicalSystemFactory medicalSystemFactory;
        private readonly IMedicalSystemDbContext dbContext;

        public ListAllCommand(IMedicalSystemFactory medicalSystemFactory, IMedicalSystemDbContext dbContext)
        {
            Guard.WhenArgument(medicalSystemFactory, "medicalSystemFactory cannot be null").IsNull().Throw();
            Guard.WhenArgument(dbContext, "dbContext cannot be null!").IsNull().Throw();

            this.medicalSystemFactory = medicalSystemFactory;
            this.dbContext = dbContext;
        }

        public string Execute(IList<string> parameters)
        {
            if (parameters.Count != 1)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            string tableName = parameters[0];

            switch (tableName)
            {
                case "specialty":
                    return string.Join("\n", dbContext.Specialty.ToList());
                default:
                    throw new UserValidationException($"There is no {tableName} table in database!");
            }
        }
    }
}
