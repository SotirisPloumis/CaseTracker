namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uniqueStringAA : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cases", "Aa", c => c.String(maxLength: 450));
            CreateIndex("dbo.Cases", "Aa", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cases", new[] { "Aa" });
            AlterColumn("dbo.Cases", "Aa", c => c.Int(nullable: false));
        }
    }
}
