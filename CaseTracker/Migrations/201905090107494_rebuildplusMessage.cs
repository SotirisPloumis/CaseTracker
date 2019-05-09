namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rebuildplusMessage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attorneys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        AFM = c.String(nullable: false),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.CaseRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Aa = c.String(maxLength: 450),
                        IsFinished = c.Boolean(nullable: false),
                        DocumentTypeId = c.Int(nullable: false),
                        CourtId = c.Int(nullable: false),
                        AttorneyId = c.Int(nullable: false),
                        DateOfAssignment = c.DateTime(nullable: false),
                        DateOfSubmission = c.DateTime(nullable: false),
                        DateOfEnd = c.DateTime(nullable: false),
                        Notes = c.String(),
                        ProsecutionId = c.Int(),
                        DefenseId = c.Int(),
                        RecipientId = c.Int(),
                        DeedResultId = c.Int(nullable: false),
                        DateOfDeed = c.DateTime(nullable: false),
                        ZoneId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attorneys", t => t.AttorneyId, cascadeDelete: true)
                .ForeignKey("dbo.Courts", t => t.CourtId, cascadeDelete: true)
                .ForeignKey("dbo.DeedResults", t => t.DeedResultId, cascadeDelete: true)
                .ForeignKey("dbo.Parties", t => t.DefenseId)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Parties", t => t.ProsecutionId)
                .ForeignKey("dbo.Parties", t => t.RecipientId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Zones", t => t.ZoneId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.DocumentTypeId)
                .Index(t => t.CourtId)
                .Index(t => t.AttorneyId)
                .Index(t => t.ProsecutionId)
                .Index(t => t.DefenseId)
                .Index(t => t.RecipientId)
                .Index(t => t.DeedResultId)
                .Index(t => t.ZoneId);
            
            CreateTable(
                "dbo.Courts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DeedResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Result = c.String(),
                        IsPayable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Parties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        FathersName = c.String(),
                        CaseRoleId = c.Int(nullable: false),
                        Street = c.String(),
                        City = c.String(),
                        Municipality = c.String(),
                        PostCode = c.String(),
                        WorkPhone = c.String(),
                        HomePhone = c.String(),
                        MobilePhone = c.String(),
                        FAX = c.String(),
                        AFM = c.String(),
                        IDCard = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CaseRoles", t => t.CaseRoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CaseRoleId);
            
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Zones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CostFull = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostClean = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Cases", "ZoneId", "dbo.Zones");
            DropForeignKey("dbo.Cases", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cases", "RecipientId", "dbo.Parties");
            DropForeignKey("dbo.Cases", "ProsecutionId", "dbo.Parties");
            DropForeignKey("dbo.Cases", "DocumentTypeId", "dbo.DocumentTypes");
            DropForeignKey("dbo.Cases", "DefenseId", "dbo.Parties");
            DropForeignKey("dbo.Parties", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Parties", "CaseRoleId", "dbo.CaseRoles");
            DropForeignKey("dbo.Cases", "DeedResultId", "dbo.DeedResults");
            DropForeignKey("dbo.Cases", "CourtId", "dbo.Courts");
            DropForeignKey("dbo.Courts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cases", "AttorneyId", "dbo.Attorneys");
            DropForeignKey("dbo.Attorneys", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Parties", new[] { "CaseRoleId" });
            DropIndex("dbo.Parties", new[] { "UserId" });
            DropIndex("dbo.Courts", new[] { "UserId" });
            DropIndex("dbo.Cases", new[] { "ZoneId" });
            DropIndex("dbo.Cases", new[] { "DeedResultId" });
            DropIndex("dbo.Cases", new[] { "RecipientId" });
            DropIndex("dbo.Cases", new[] { "DefenseId" });
            DropIndex("dbo.Cases", new[] { "ProsecutionId" });
            DropIndex("dbo.Cases", new[] { "AttorneyId" });
            DropIndex("dbo.Cases", new[] { "CourtId" });
            DropIndex("dbo.Cases", new[] { "DocumentTypeId" });
            DropIndex("dbo.Cases", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Attorneys", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Zones");
            DropTable("dbo.DocumentTypes");
            DropTable("dbo.Parties");
            DropTable("dbo.DeedResults");
            DropTable("dbo.Courts");
            DropTable("dbo.Cases");
            DropTable("dbo.CaseRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Attorneys");
        }
    }
}
