using Bytes2you.Validation;
using MedicalSystem.Client.Commands.Contracts;
using MedicalSystem.Client.Common.Exceptions;
using MedicalSystem.Client.Core.Factories;
using MedicalSystem.Data.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MedicalSystem.Client.Commands.Adding
{
    public class CreateSpecialtyCommand : ICommand
    {
        private readonly IMedicalSystemFactory medicalSystemFactory;
        private readonly IMedicalSystemDbContext dbContext;

        public CreateSpecialtyCommand(IMedicalSystemFactory medicalSystemFactory, IMedicalSystemDbContext dbContext)
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

            var specialty = this.medicalSystemFactory.CreateSpecialty(parameters[0]);

            if (specialty == null)
            {
                throw new DatabaseValidationException("Specialty with same name is already in the database.");

            }

            dbContext.Specialty.Add(specialty);
            dbContext.SaveChanges();

            return "Successfully added a new specialty!";
        }
    }
}
