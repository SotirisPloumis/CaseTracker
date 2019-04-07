namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCaseFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cases", "DateOfSubmission", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cases", "DateOfEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cases", "DateOfAssigmnent", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cases", "Attorney", c => c.String());
            AddColumn("dbo.Cases", "Court", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cases", "Court");
            DropColumn("dbo.Cases", "Attorney");
            DropColumn("dbo.Cases", "DateOfAssigmnent");
            DropColumn("dbo.Cases", "DateOfEnd");
            DropColumn("dbo.Cases", "DateOfSubmission");
        }
    }
}
