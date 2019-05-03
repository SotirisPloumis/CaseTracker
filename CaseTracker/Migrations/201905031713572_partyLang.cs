namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class partyLang : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Parties", "CaseRoleId", "dbo.CaseRoles");
            DropIndex("dbo.Parties", new[] { "CaseRoleId" });
            AlterColumn("dbo.Parties", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Parties", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Parties", "FathersName", c => c.String(nullable: false));
            AlterColumn("dbo.Parties", "CaseRoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Parties", "CaseRoleId");
            AddForeignKey("dbo.Parties", "CaseRoleId", "dbo.CaseRoles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parties", "CaseRoleId", "dbo.CaseRoles");
            DropIndex("dbo.Parties", new[] { "CaseRoleId" });
            AlterColumn("dbo.Parties", "CaseRoleId", c => c.Int());
            AlterColumn("dbo.Parties", "FathersName", c => c.String());
            AlterColumn("dbo.Parties", "LastName", c => c.String());
            AlterColumn("dbo.Parties", "FirstName", c => c.String());
            CreateIndex("dbo.Parties", "CaseRoleId");
            AddForeignKey("dbo.Parties", "CaseRoleId", "dbo.CaseRoles", "Id");
        }
    }
}
