namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attorneyRepo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Attorneys", "City", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Attorneys", "City", c => c.String(nullable: false));
        }
    }
}
