namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reqCourtName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courts", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courts", "Name", c => c.String());
        }
    }
}
