namespace ProjectHall4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class h : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ViewBookings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        VenueName = c.String(),
                        Capacity = c.Int(nullable: false),
                        eventType = c.String(),
                        CateringType = c.String(),
                        cateringCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DecorType = c.String(),
                        decorCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        totalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ViewBookings");
        }
    }
}
