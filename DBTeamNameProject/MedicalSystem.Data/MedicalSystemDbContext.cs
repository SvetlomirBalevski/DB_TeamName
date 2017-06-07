﻿namespace MedicalSystem.Data
{
    using MedicalSystem.Models;
    using System.Data.Entity;

    public class MedicalSystemDbContext : DbContext
    {
        public MedicalSystemDbContext()
            : base("MedicalSystemDb")
        {
        }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Hospital> Hospitals { get; set; }

        public DbSet<Specialty> Specialty { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Disease> Diseases { get; set; }

        public DbSet<Medicine> Medicines { get; set; }
    }
}