namespace MedicalSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FluentApiconfigurationrefactoring : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "Hospital_Id", "dbo.Hospitals");
            DropIndex("dbo.Doctors", new[] { "Hospital_Id" });
            AlterColumn("dbo.Doctors", "Hospital_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "Status", c => c.Int(nullable: false));
            CreateIndex("dbo.Doctors", "Hospital_Id");
            CreateIndex("dbo.Patients", "Name");
            AddForeignKey("dbo.Doctors", "Hospital_Id", "dbo.Hospitals", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "Hospital_Id", "dbo.Hospitals");
            DropIndex("dbo.Patients", new[] { "Name" });
            DropIndex("dbo.Doctors", new[] { "Hospital_Id" });
            AlterColumn("dbo.Patients", "Status", c => c.String());
            AlterColumn("dbo.Doctors", "Hospital_Id", c => c.Int());
            CreateIndex("dbo.Doctors", "Hospital_Id");
            AddForeignKey("dbo.Doctors", "Hospital_Id", "dbo.Hospitals", "Id");
        }
    }
}
