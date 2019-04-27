namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Zones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Cost = c.Int(nullable: false),
                        Tax = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cases", "DateOfDeed", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cases", "ZoneId", c => c.Int());
            CreateIndex("dbo.Cases", "ZoneId");
            AddForeignKey("dbo.Cases", "ZoneId", "dbo.Zones", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cases", "ZoneId", "dbo.Zones");
            DropIndex("dbo.Cases", new[] { "ZoneId" });
            DropColumn("dbo.Cases", "ZoneId");
            DropColumn("dbo.Cases", "DateOfDeed");
            DropTable("dbo.Zones");
        }
    }
}
