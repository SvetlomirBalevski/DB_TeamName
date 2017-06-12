using MedicalSystem.Models;
using System.Data.Entity;

namespace MedicalSystem.Data.Contracts
{
    public interface IMedicalSystemDbContext
    {
        DbSet<Doctor> Doctors { get; }

        DbSet<Hospital> Hospitals { get;}

        DbSet<Specialty> Specialty { get;}

        DbSet<Patient> Patients { get; }

        DbSet<Disease> Diseases { get; }

        DbSet<Medicine> Medicines { get; }

        int SaveChanges();
    }
}
