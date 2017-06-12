using Bytes2you.Validation;
using MedicalSystem.Client.Commands.Contracts;
using MedicalSystem.Client.Common.Exceptions;
using MedicalSystem.Client.Core.Factories;
using MedicalSystem.Data.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MedicalSystem.Client.Commands.Deleting
{
    public class DeleteSpecialtyCommand : ICommand
    {
        private readonly IMedicalSystemFactory medicalSystemFactory;
        private readonly IMedicalSystemDbContext dbContext;

        public DeleteSpecialtyCommand(IMedicalSystemFactory medicalSystemFactory, IMedicalSystemDbContext dbContext)
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

            string specialtyName = parameters[0];

            var specialty = dbContext.Specialty.FirstOrDefault(s => s.Name == specialtyName);

            if (specialty != null)
            {
                this.dbContext.Specialty.Remove(specialty);
                dbContext.SaveChanges();

                return $"Specialty {specialtyName} has been deleted!";
            }
            else
            {
                return "Specialty with given name does not exists!";
            }
        }
    }
}
