namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revertEnumRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parties", "CaseRoleId", c => c.Int());
            CreateIndex("dbo.Parties", "CaseRoleId");
            AddForeignKey("dbo.Parties", "CaseRoleId", "dbo.CaseRoles", "Id");
            DropColumn("dbo.Parties", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parties", "Role", c => c.Int(nullable: false));
            DropForeignKey("dbo.Parties", "CaseRoleId", "dbo.CaseRoles");
            DropIndex("dbo.Parties", new[] { "CaseRoleId" });
            DropColumn("dbo.Parties", "CaseRoleId");
        }
    }
}
