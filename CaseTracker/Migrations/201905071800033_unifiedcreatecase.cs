namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unifiedcreatecase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cases", "AttorneyId", "dbo.Attorneys");
            DropForeignKey("dbo.Cases", "CourtId", "dbo.Courts");
            DropIndex("dbo.Cases", new[] { "CourtId" });
            DropIndex("dbo.Cases", new[] { "AttorneyId" });
            AlterColumn("dbo.Cases", "CourtId", c => c.Int());
            AlterColumn("dbo.Cases", "AttorneyId", c => c.Int());
            CreateIndex("dbo.Cases", "CourtId");
            CreateIndex("dbo.Cases", "AttorneyId");
            AddForeignKey("dbo.Cases", "AttorneyId", "dbo.Attorneys", "Id");
            AddForeignKey("dbo.Cases", "CourtId", "dbo.Courts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cases", "CourtId", "dbo.Courts");
            DropForeignKey("dbo.Cases", "AttorneyId", "dbo.Attorneys");
            DropIndex("dbo.Cases", new[] { "AttorneyId" });
            DropIndex("dbo.Cases", new[] { "CourtId" });
            AlterColumn("dbo.Cases", "AttorneyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Cases", "CourtId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cases", "AttorneyId");
            CreateIndex("dbo.Cases", "CourtId");
            AddForeignKey("dbo.Cases", "CourtId", "dbo.Courts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cases", "AttorneyId", "dbo.Attorneys", "Id", cascadeDelete: true);
        }
    }
}
