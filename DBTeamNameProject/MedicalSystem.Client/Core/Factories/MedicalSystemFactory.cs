using Bytes2you.Validation;
using MedicalSystem.Data.Contracts;
using MedicalSystem.Models;
using System.Linq;

namespace MedicalSystem.Client.Core.Factories
{
    public class MedicalSystemFactory : IMedicalSystemFactory
    {
        private readonly IMedicalSystemDbContext dbContext;

        public MedicalSystemFactory(IMedicalSystemDbContext dbContext)
        {
            Guard.WhenArgument(dbContext, "dbContext cannot be null!").IsNull().Throw();

            this.dbContext = dbContext;
        }

        public Specialty CreateSpecialty(string name)
        {
            var specialty = dbContext.Specialty
                .FirstOrDefault(s => s.Name.ToLower() == name.ToLower());

            if (specialty == null)
            {
                specialty = new Specialty
                {
                    Name = name
                };

                return specialty;
            }
            else
            {
                return null;
            }
        }
    }
}
