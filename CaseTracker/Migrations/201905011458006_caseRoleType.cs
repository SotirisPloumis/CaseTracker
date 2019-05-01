namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class caseRoleType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CaseRoles", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CaseRoles", "Type");
        }
    }
}
