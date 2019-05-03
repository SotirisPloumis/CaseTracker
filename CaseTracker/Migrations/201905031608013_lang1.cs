namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lang1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Attorneys", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Attorneys", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Attorneys", "AFM", c => c.String(nullable: false));
            AlterColumn("dbo.Attorneys", "City", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Attorneys", "City", c => c.String());
            AlterColumn("dbo.Attorneys", "AFM", c => c.String());
            AlterColumn("dbo.Attorneys", "LastName", c => c.String());
            AlterColumn("dbo.Attorneys", "FirstName", c => c.String());
        }
    }
}
