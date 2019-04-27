namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bringBackId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Cases");
            AddColumn("dbo.Cases", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Cases", "Aa", c => c.String(maxLength: 450));
            AddPrimaryKey("dbo.Cases", "Id");
            CreateIndex("dbo.Cases", "Aa", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cases", new[] { "Aa" });
            DropPrimaryKey("dbo.Cases");
            AlterColumn("dbo.Cases", "Aa", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Cases", "Id");
            AddPrimaryKey("dbo.Cases", "Aa");
        }
    }
}
