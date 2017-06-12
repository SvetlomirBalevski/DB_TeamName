namespace MedicalSystem.DataSQLite.Migrations
{
    using MedicalSystem.Models.SQLiteModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.SQLite.EF6.Migrations;
    using System.Linq;

    internal sealed class ConfigurationSQLite : DbMigrationsConfiguration<MedicalSystemSQLiteDbContext>
    {
        public ConfigurationSQLite()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
        }

        protected override void Seed(MedicalSystemSQLiteDbContext context)
        {
            context.Continents.AddOrUpdate(
                c => c.Name,
                new Continent
                {
                    Name = "Europe"
                },
                new Continent
                {
                    Name = "Asia"
                });
        }
    }
}
