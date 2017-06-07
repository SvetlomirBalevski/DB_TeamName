namespace MedicalSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diseases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Hospital_Id = c.Int(),
                        Specialty_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hospitals", t => t.Hospital_Id)
                .ForeignKey("dbo.Specialties", t => t.Specialty_Id)
                .Index(t => t.Hospital_Id)
                .Index(t => t.Specialty_Id);
            
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Satus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Specialties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DoctorDiseases",
                c => new
                    {
                        Doctor_Id = c.Int(nullable: false),
                        Disease_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Doctor_Id, t.Disease_Id })
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Diseases", t => t.Disease_Id, cascadeDelete: true)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Disease_Id);
            
            CreateTable(
                "dbo.PatientDiseases",
                c => new
                    {
                        Patient_Id = c.Int(nullable: false),
                        Disease_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Patient_Id, t.Disease_Id })
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .ForeignKey("dbo.Diseases", t => t.Disease_Id, cascadeDelete: true)
                .Index(t => t.Patient_Id)
                .Index(t => t.Disease_Id);
            
            CreateTable(
                "dbo.PatientDoctors",
                c => new
                    {
                        Patient_Id = c.Int(nullable: false),
                        Doctor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Patient_Id, t.Doctor_Id })
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id, cascadeDelete: true)
                .Index(t => t.Patient_Id)
                .Index(t => t.Doctor_Id);
            
            CreateTable(
                "dbo.MedicineDiseases",
                c => new
                    {
                        Medicine_Id = c.Int(nullable: false),
                        Disease_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Medicine_Id, t.Disease_Id })
                .ForeignKey("dbo.Medicines", t => t.Medicine_Id, cascadeDelete: true)
                .ForeignKey("dbo.Diseases", t => t.Disease_Id, cascadeDelete: true)
                .Index(t => t.Medicine_Id)
                .Index(t => t.Disease_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicineDiseases", "Disease_Id", "dbo.Diseases");
            DropForeignKey("dbo.MedicineDiseases", "Medicine_Id", "dbo.Medicines");
            DropForeignKey("dbo.Doctors", "Specialty_Id", "dbo.Specialties");
            DropForeignKey("dbo.PatientDoctors", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.PatientDoctors", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.PatientDiseases", "Disease_Id", "dbo.Diseases");
            DropForeignKey("dbo.PatientDiseases", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Doctors", "Hospital_Id", "dbo.Hospitals");
            DropForeignKey("dbo.DoctorDiseases", "Disease_Id", "dbo.Diseases");
            DropForeignKey("dbo.DoctorDiseases", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.MedicineDiseases", new[] { "Disease_Id" });
            DropIndex("dbo.MedicineDiseases", new[] { "Medicine_Id" });
            DropIndex("dbo.PatientDoctors", new[] { "Doctor_Id" });
            DropIndex("dbo.PatientDoctors", new[] { "Patient_Id" });
            DropIndex("dbo.PatientDiseases", new[] { "Disease_Id" });
            DropIndex("dbo.PatientDiseases", new[] { "Patient_Id" });
            DropIndex("dbo.DoctorDiseases", new[] { "Disease_Id" });
            DropIndex("dbo.DoctorDiseases", new[] { "Doctor_Id" });
            DropIndex("dbo.Doctors", new[] { "Specialty_Id" });
            DropIndex("dbo.Doctors", new[] { "Hospital_Id" });
            DropTable("dbo.MedicineDiseases");
            DropTable("dbo.PatientDoctors");
            DropTable("dbo.PatientDiseases");
            DropTable("dbo.DoctorDiseases");
            DropTable("dbo.Medicines");
            DropTable("dbo.Specialties");
            DropTable("dbo.Patients");
            DropTable("dbo.Hospitals");
            DropTable("dbo.Doctors");
            DropTable("dbo.Diseases");
        }
    }
}
