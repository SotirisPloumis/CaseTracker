namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attorneys", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Courts", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.DeedResults", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Parties", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Cases", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Attorneys", "UserId");
            CreateIndex("dbo.Cases", "UserId");
            CreateIndex("dbo.Courts", "UserId");
            CreateIndex("dbo.DeedResults", "UserId");
            CreateIndex("dbo.Parties", "UserId");
            AddForeignKey("dbo.Attorneys", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Courts", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.DeedResults", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Parties", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Cases", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cases", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Parties", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DeedResults", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Attorneys", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Parties", new[] { "UserId" });
            DropIndex("dbo.DeedResults", new[] { "UserId" });
            DropIndex("dbo.Courts", new[] { "UserId" });
            DropIndex("dbo.Cases", new[] { "UserId" });
            DropIndex("dbo.Attorneys", new[] { "UserId" });
            AlterColumn("dbo.Cases", "UserId", c => c.String());
            DropColumn("dbo.Parties", "UserId");
            DropColumn("dbo.DeedResults", "UserId");
            DropColumn("dbo.Courts", "UserId");
            DropColumn("dbo.Attorneys", "UserId");
        }
    }
}
