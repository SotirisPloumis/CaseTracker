namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nonUniqueAA : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Cases", new[] { "Aa" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Cases", "Aa", unique: true);
        }
    }
}
