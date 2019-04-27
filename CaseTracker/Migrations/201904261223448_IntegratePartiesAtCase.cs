namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntegratePartiesAtCase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cases", "ProsecutionId", c => c.Int());
            AddColumn("dbo.Cases", "DefenseId", c => c.Int());
            AddColumn("dbo.Cases", "RecipientId", c => c.Int());
            AddColumn("dbo.Parties", "FathersName", c => c.String());
            AddColumn("dbo.Parties", "Street", c => c.String());
            AddColumn("dbo.Parties", "City", c => c.String());
            AddColumn("dbo.Parties", "Municipality", c => c.String());
            AddColumn("dbo.Parties", "PostCode", c => c.String());
            AddColumn("dbo.Parties", "WorkPhone", c => c.String());
            AddColumn("dbo.Parties", "HomePhone", c => c.String());
            AddColumn("dbo.Parties", "MobilePhone", c => c.String());
            AddColumn("dbo.Parties", "FAX", c => c.String());
            CreateIndex("dbo.Cases", "ProsecutionId");
            CreateIndex("dbo.Cases", "DefenseId");
            CreateIndex("dbo.Cases", "RecipientId");
            AddForeignKey("dbo.Cases", "DefenseId", "dbo.Parties", "Id");
            AddForeignKey("dbo.Cases", "ProsecutionId", "dbo.Parties", "Id");
            AddForeignKey("dbo.Cases", "RecipientId", "dbo.Parties", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cases", "RecipientId", "dbo.Parties");
            DropForeignKey("dbo.Cases", "ProsecutionId", "dbo.Parties");
            DropForeignKey("dbo.Cases", "DefenseId", "dbo.Parties");
            DropIndex("dbo.Cases", new[] { "RecipientId" });
            DropIndex("dbo.Cases", new[] { "DefenseId" });
            DropIndex("dbo.Cases", new[] { "ProsecutionId" });
            DropColumn("dbo.Parties", "FAX");
            DropColumn("dbo.Parties", "MobilePhone");
            DropColumn("dbo.Parties", "HomePhone");
            DropColumn("dbo.Parties", "WorkPhone");
            DropColumn("dbo.Parties", "PostCode");
            DropColumn("dbo.Parties", "Municipality");
            DropColumn("dbo.Parties", "City");
            DropColumn("dbo.Parties", "Street");
            DropColumn("dbo.Parties", "FathersName");
            DropColumn("dbo.Cases", "RecipientId");
            DropColumn("dbo.Cases", "DefenseId");
            DropColumn("dbo.Cases", "ProsecutionId");
        }
    }
}
