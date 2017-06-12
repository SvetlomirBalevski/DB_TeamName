using MedicalSystem.DataSQLite.Migrations;
using MedicalSystem.Models.SQLiteModels;
using System.Data.Entity;

namespace MedicalSystem.DataSQLite
{
    public class MedicalSystemSQLiteDbContext : DbContext
    {
        public MedicalSystemSQLiteDbContext()
            : base("MedicalSystemSQLiteDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MedicalSystemSQLiteDbContext, ConfigurationSQLite>(true));
        }

        public DbSet<Continent> Continents { get; set; }
    }
}
