namespace MedicalSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtributesAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "Specialty_Id", "dbo.Specialties");
            DropIndex("dbo.Doctors", new[] { "Specialty_Id" });
            AlterColumn("dbo.Diseases", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Diseases", "Description", c => c.String(storeType: "ntext"));
            AlterColumn("dbo.Doctors", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Doctors", "Specialty_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Hospitals", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Medicines", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Medicines", "Description", c => c.String(nullable: false, maxLength: 40));
            CreateIndex("dbo.Doctors", "Specialty_Id");
            AddForeignKey("dbo.Doctors", "Specialty_Id", "dbo.Specialties", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "Specialty_Id", "dbo.Specialties");
            DropIndex("dbo.Doctors", new[] { "Specialty_Id" });
            AlterColumn("dbo.Medicines", "Description", c => c.String());
            AlterColumn("dbo.Medicines", "Name", c => c.String());
            AlterColumn("dbo.Hospitals", "Name", c => c.String());
            AlterColumn("dbo.Doctors", "Specialty_Id", c => c.Int());
            AlterColumn("dbo.Doctors", "Name", c => c.String());
            AlterColumn("dbo.Diseases", "Description", c => c.String());
            AlterColumn("dbo.Diseases", "Name", c => c.String());
            CreateIndex("dbo.Doctors", "Specialty_Id");
            AddForeignKey("dbo.Doctors", "Specialty_Id", "dbo.Specialties", "Id");
        }
    }
}
