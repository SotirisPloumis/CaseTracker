namespace CaseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class decimalAmountsAtZone : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Zones", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Zones", "Tax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Zones", "Tax", c => c.Int(nullable: false));
            AlterColumn("dbo.Zones", "Cost", c => c.Int(nullable: false));
        }
    }
}
