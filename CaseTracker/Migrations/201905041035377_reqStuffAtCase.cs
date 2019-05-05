namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reqStuffAtCase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cases", "DeedResultId", "dbo.DeedResults");
            DropForeignKey("dbo.Cases", "ZoneId", "dbo.Zones");
            DropIndex("dbo.Cases", new[] { "DeedResultId" });
            DropIndex("dbo.Cases", new[] { "ZoneId" });
            AlterColumn("dbo.Cases", "DeedResultId", c => c.Int(nullable: false));
            AlterColumn("dbo.Cases", "ZoneId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cases", "DeedResultId");
            CreateIndex("dbo.Cases", "ZoneId");
            AddForeignKey("dbo.Cases", "DeedResultId", "dbo.DeedResults", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cases", "ZoneId", "dbo.Zones", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cases", "ZoneId", "dbo.Zones");
            DropForeignKey("dbo.Cases", "DeedResultId", "dbo.DeedResults");
            DropIndex("dbo.Cases", new[] { "ZoneId" });
            DropIndex("dbo.Cases", new[] { "DeedResultId" });
            AlterColumn("dbo.Cases", "ZoneId", c => c.Int());
            AlterColumn("dbo.Cases", "DeedResultId", c => c.Int());
            CreateIndex("dbo.Cases", "ZoneId");
            CreateIndex("dbo.Cases", "DeedResultId");
            AddForeignKey("dbo.Cases", "ZoneId", "dbo.Zones", "Id");
            AddForeignKey("dbo.Cases", "DeedResultId", "dbo.DeedResults", "Id");
        }
    }
}
