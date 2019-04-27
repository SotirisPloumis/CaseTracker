namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moveKeyToAa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CaseParties", "CaseId", "dbo.Cases");
            DropForeignKey("dbo.CaseParties", "RoleId", "dbo.CaseRoles");
            DropForeignKey("dbo.CaseParties", "PartyId", "dbo.Parties");
            DropIndex("dbo.CaseParties", new[] { "CaseId" });
            DropIndex("dbo.CaseParties", new[] { "PartyId" });
            DropIndex("dbo.CaseParties", new[] { "RoleId" });
            DropIndex("dbo.Cases", new[] { "Aa" });
            DropPrimaryKey("dbo.Cases");
            AlterColumn("dbo.Cases", "Aa", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Cases", "Aa");
            DropColumn("dbo.Cases", "Id");
            DropTable("dbo.CaseParties");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CaseParties",
                c => new
                    {
                        CaseId = c.Int(nullable: false),
                        PartyId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CaseId, t.PartyId });
            
            AddColumn("dbo.Cases", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Cases");
            AlterColumn("dbo.Cases", "Aa", c => c.String(maxLength: 450));
            AddPrimaryKey("dbo.Cases", "Id");
            CreateIndex("dbo.Cases", "Aa", unique: true);
            CreateIndex("dbo.CaseParties", "RoleId");
            CreateIndex("dbo.CaseParties", "PartyId");
            CreateIndex("dbo.CaseParties", "CaseId");
            AddForeignKey("dbo.CaseParties", "PartyId", "dbo.Parties", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CaseParties", "RoleId", "dbo.CaseRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CaseParties", "CaseId", "dbo.Cases", "Id", cascadeDelete: true);
        }
    }
}
