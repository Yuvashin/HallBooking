namespace ProjectHall4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TotalPrices2",
                c => new
                    {
                        TotalPrices2ID = c.Int(nullable: false, identity: true),
                        UserDecorID = c.Int(nullable: false),
                        VenueID = c.Int(nullable: false),
                        TotalBookingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalVenuePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalDecorPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalCateringPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TotalPrices2ID)
                .ForeignKey("dbo.UserDecors", t => t.UserDecorID, cascadeDelete: true)
                .ForeignKey("dbo.Venues", t => t.VenueID, cascadeDelete: true)
                .Index(t => t.UserDecorID)
                .Index(t => t.VenueID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TotalPrices2", "VenueID", "dbo.Venues");
            DropForeignKey("dbo.TotalPrices2", "UserDecorID", "dbo.UserDecors");
            DropIndex("dbo.TotalPrices2", new[] { "VenueID" });
            DropIndex("dbo.TotalPrices2", new[] { "UserDecorID" });
            DropTable("dbo.TotalPrices2");
        }
    }
}
