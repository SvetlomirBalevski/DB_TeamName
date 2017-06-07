namespace MedicalSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatethroughfluentAPI : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Status", c => c.String());
            AlterColumn("dbo.Patients", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Specialties", "Name", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Patients", "Satus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "Satus", c => c.String());
            AlterColumn("dbo.Specialties", "Name", c => c.String());
            AlterColumn("dbo.Patients", "Name", c => c.String());
            DropColumn("dbo.Patients", "Status");
        }
    }
}
