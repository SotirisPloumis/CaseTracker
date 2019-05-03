namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roleToEnum : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Parties", "CaseRoleId", "dbo.CaseRoles");
            DropIndex("dbo.Parties", new[] { "CaseRoleId" });
            AddColumn("dbo.Parties", "Role", c => c.Int(nullable: false));
            DropColumn("dbo.Parties", "CaseRoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parties", "CaseRoleId", c => c.Int(nullable: false));
            DropColumn("dbo.Parties", "Role");
            CreateIndex("dbo.Parties", "CaseRoleId");
            AddForeignKey("dbo.Parties", "CaseRoleId", "dbo.CaseRoles", "Id", cascadeDelete: true);
        }
    }
}
