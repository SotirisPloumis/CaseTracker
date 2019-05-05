namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isFinished : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cases", "UserId", c => c.String());
            AddColumn("dbo.Cases", "IsFinished", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cases", "IsFinished");
            DropColumn("dbo.Cases", "UserId");
        }
    }
}
