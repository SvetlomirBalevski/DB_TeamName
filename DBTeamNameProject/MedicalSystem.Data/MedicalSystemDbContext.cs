namespace MedicalSystem.Data
{
    using MedicalSystem.Models;
    using System.Data.Entity;

    public class MedicalSystemDbContext : DbContext
    {
        public MedicalSystemDbContext()
            : base("MedicalSystemDb")
        {
        }

        protected override void OnModelCreating(
           DbModelBuilder modelBuilder)
        {
            this.OnGenreModelCreateing(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void OnGenreModelCreateing(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasKey<int>(genre => genre.Id);

            modelBuilder.Entity<Patient>()
                .Property(patient => patient.Name)
                .IsRequired()
                .HasMaxLength(40);
            
            modelBuilder.Entity<Specialty>()
                .HasKey<int>(speciality => speciality.Id);
                

            modelBuilder.Entity<Specialty>()
                .Property(speciality => speciality.Name)
                .IsRequired()
                .HasMaxLength(30);
                

            //modelBuilder.Entity<Genre>()
            //    .Property(genre => genre.Name)
            //    .IsRequired();


            //modelBuilder.Entity<Genre>()
            //    .Property(genre => genre.Name)
            //    .HasColumnAnnotation(
            //    "Index",
            //    new IndexAnnotation(
            //        new IndexAttribute("IX_Name")
            //        {
            //            IsUnique = true
            //        }
            //        ));
        }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Hospital> Hospitals { get; set; }

        public DbSet<Specialty> Specialty { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Disease> Diseases { get; set; }

        public DbSet<Medicine> Medicines { get; set; }
    }
}
