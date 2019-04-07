namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attorney : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attorneys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        AFM = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Attorneys");
        }
    }
}
