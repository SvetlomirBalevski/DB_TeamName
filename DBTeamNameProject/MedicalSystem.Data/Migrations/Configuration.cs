namespace MedicalSystem.Data.Migrations
{
    using MedicalSystem.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MedicalSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MedicalSystemDbContext context)
        {
            context.Medicines.AddOrUpdate(
                m => m.Name,
                new Medicine
                {
                    Name = "Aspirin",
                    Description = "Universal analgesic",
                }
            );
            context.Specialty.AddOrUpdate(s => s.Name,
          new Specialty
          {
              Name = "Rakiolog"
          });
        }
    }
}
