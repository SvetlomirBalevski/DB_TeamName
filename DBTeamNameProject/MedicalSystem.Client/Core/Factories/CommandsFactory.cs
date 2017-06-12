using Bytes2you.Validation;
using MedicalSystem.Client.Commands.Adding;
using MedicalSystem.Client.Commands.Contracts;
using MedicalSystem.Client.Commands.Deleting;
using MedicalSystem.Client.Commands.Listing;
using MedicalSystem.Client.Commands.Updating;
using MedicalSystem.Client.Common.Exceptions;
using MedicalSystem.Data.Contracts;

namespace MedicalSystem.Client.Core.Factories
{
    public class CommandsFactory : ICommandsFactory
    {
        private readonly IMedicalSystemFactory medicalSystemFactory;
        private readonly IMedicalSystemDbContext dbContext;

        public CommandsFactory(IMedicalSystemFactory medicalSystemFactory, IMedicalSystemDbContext dbContext)
        {
            Guard.WhenArgument(medicalSystemFactory, "medicalSystemFactory cannot be null").IsNull().Throw();
            Guard.WhenArgument(dbContext, "dbContext cannot be null!").IsNull().Throw();

            this.medicalSystemFactory = medicalSystemFactory;
            this.dbContext = dbContext;
        }

        public ICommand CreateCommandFromString(string commandName)
        {
            var cmd = commandName.ToLower();

            switch (cmd)
            {
                case "addspecialty": return new CreateSpecialtyCommand(this.medicalSystemFactory, this.dbContext);
                case "readspecialty": return new ListSpecialtyCommand(this.medicalSystemFactory, this.dbContext);
                case "updatespecialty": return new UpdateSpecialtyCommand(this.medicalSystemFactory, this.dbContext);
                case "deletespecialty": return new DeleteSpecialtyCommand(this.medicalSystemFactory, this.dbContext);
                default: throw new UserValidationException("The passed command is not valid!");
            }
        }
    }
}
