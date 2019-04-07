namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class caseparties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CaseParties",
                c => new
                    {
                        CaseId = c.Int(nullable: false),
                        PartyId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CaseId, t.PartyId })
                .ForeignKey("dbo.Cases", t => t.CaseId, cascadeDelete: true)
                .ForeignKey("dbo.CaseRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Parties", t => t.PartyId, cascadeDelete: true)
                .Index(t => t.CaseId)
                .Index(t => t.PartyId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CaseParties", "PartyId", "dbo.Parties");
            DropForeignKey("dbo.CaseParties", "RoleId", "dbo.CaseRoles");
            DropForeignKey("dbo.CaseParties", "CaseId", "dbo.Cases");
            DropIndex("dbo.CaseParties", new[] { "RoleId" });
            DropIndex("dbo.CaseParties", new[] { "PartyId" });
            DropIndex("dbo.CaseParties", new[] { "CaseId" });
            DropTable("dbo.CaseParties");
        }
    }
}
