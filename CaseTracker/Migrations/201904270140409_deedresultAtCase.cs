namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deedresultAtCase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cases", "DeedResultId", c => c.Int());
            CreateIndex("dbo.Cases", "DeedResultId");
            AddForeignKey("dbo.Cases", "DeedResultId", "dbo.DeedResults", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cases", "DeedResultId", "dbo.DeedResults");
            DropIndex("dbo.Cases", new[] { "DeedResultId" });
            DropColumn("dbo.Cases", "DeedResultId");
        }
    }
}
