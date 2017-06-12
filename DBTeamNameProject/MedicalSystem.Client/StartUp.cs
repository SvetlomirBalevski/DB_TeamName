using MedicalSystem.Client.Core;
using MedicalSystem.Client.Core.Factories;
using MedicalSystem.Client.Core.Providers;
using MedicalSystem.Data;

namespace MedicalSystem.Client
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbContext = new MedicalSystemDbContext();
            var medicalSystemFactory = new MedicalSystemFactory(dbContext);
            var commandsFactory = new CommandsFactory(medicalSystemFactory, dbContext);

            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var parser = new CommandParser(commandsFactory);
            var generator = new pdfReportGenerator();

            var engine = new Engine(reader, writer, parser, generator);
            engine.Start();
        }
    }
}
