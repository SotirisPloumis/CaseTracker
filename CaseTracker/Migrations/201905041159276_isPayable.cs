namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isPayable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeedResults", "IsPayable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeedResults", "IsPayable");
        }
    }
}
