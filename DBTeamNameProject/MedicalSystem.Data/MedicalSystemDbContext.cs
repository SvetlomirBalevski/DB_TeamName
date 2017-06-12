namespace MedicalSystem.Data
{
    using MedicalSystem.Data.Contracts;
    using MedicalSystem.Models;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;

    public class MedicalSystemDbContext : DbContext, IMedicalSystemDbContext
    {
        public MedicalSystemDbContext()
            : base("MedicalSystemDb")
        {
        }

        protected override void OnModelCreating(
           DbModelBuilder modelBuilder)
        {
            this.OnPatientModelCreateing(modelBuilder);
            this.OnSpecialtyModelCreateing(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void OnSpecialtyModelCreateing(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialty>()
                .HasKey<int>(speciality => speciality.Id);


            modelBuilder.Entity<Specialty>()
                .Property(speciality => speciality.Name)
                .IsRequired()
                .HasMaxLength(30);
        }

        private void OnPatientModelCreateing(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasKey<int>(patient => patient.Id);

            modelBuilder.Entity<Patient>()
                .Property(patient => patient.Name)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Patient>()
                .Property(patient => patient.Name)
                .HasColumnAnnotation(
                "Index",
                new IndexAnnotation(
                    new IndexAttribute("IX_Name")
                    {
                        IsUnique = false
                    }
                    ));
        }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Hospital> Hospitals { get; set; }

        public DbSet<Specialty> Specialty { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Disease> Diseases { get; set; }

        public DbSet<Medicine> Medicines { get; set; }
    }
}
