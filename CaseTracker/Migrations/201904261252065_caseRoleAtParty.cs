namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class caseRoleAtParty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parties", "CaseRoleId", c => c.Int());
            CreateIndex("dbo.Parties", "CaseRoleId");
            AddForeignKey("dbo.Parties", "CaseRoleId", "dbo.CaseRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parties", "CaseRoleId", "dbo.CaseRoles");
            DropIndex("dbo.Parties", new[] { "CaseRoleId" });
            DropColumn("dbo.Parties", "CaseRoleId");
        }
    }
}
