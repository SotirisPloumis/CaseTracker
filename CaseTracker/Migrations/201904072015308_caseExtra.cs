namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class caseExtra : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cases", "CourtId", c => c.Int(nullable: false));
            AddColumn("dbo.Cases", "AttorneyId", c => c.Int(nullable: false));
            AddColumn("dbo.Cases", "DateOfAssignment", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cases", "DateOfSubmission", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cases", "DateOfEnd", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Cases", "CourtId");
            CreateIndex("dbo.Cases", "AttorneyId");
            AddForeignKey("dbo.Cases", "AttorneyId", "dbo.Attorneys", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cases", "CourtId", "dbo.Courts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cases", "CourtId", "dbo.Courts");
            DropForeignKey("dbo.Cases", "AttorneyId", "dbo.Attorneys");
            DropIndex("dbo.Cases", new[] { "AttorneyId" });
            DropIndex("dbo.Cases", new[] { "CourtId" });
            DropColumn("dbo.Cases", "DateOfEnd");
            DropColumn("dbo.Cases", "DateOfSubmission");
            DropColumn("dbo.Cases", "DateOfAssignment");
            DropColumn("dbo.Cases", "AttorneyId");
            DropColumn("dbo.Cases", "CourtId");
        }
    }
}
