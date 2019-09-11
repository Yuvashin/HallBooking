namespace ProjectHall4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class g : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "AdultID", "dbo.Adults");
            DropForeignKey("dbo.Bookings", "ChildrenID", "dbo.Children");
            DropForeignKey("dbo.Bookings", "DecorID", "dbo.Decors");
            DropForeignKey("dbo.Bookings", "VenueID", "dbo.Venues");
            DropIndex("dbo.Bookings", new[] { "VenueID" });
            DropIndex("dbo.Bookings", new[] { "DecorID" });
            DropIndex("dbo.Bookings", new[] { "AdultID" });
            DropIndex("dbo.Bookings", new[] { "ChildrenID" });
            DropTable("dbo.Bookings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        time = c.DateTime(nullable: false),
                        numbOfGuests = c.Int(nullable: false),
                        numbOfChildren = c.Int(nullable: false),
                        VenueID = c.Int(nullable: false),
                        cateringPackage = c.Boolean(nullable: false),
                        decorpackage = c.Boolean(nullable: false),
                        Total_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DecorID = c.Int(nullable: false),
                        AdultID = c.Int(nullable: false),
                        ChildrenID = c.Int(nullable: false),
                        Decor_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Catering_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChildrenFood_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Venue_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BookingID);
            
            CreateIndex("dbo.Bookings", "ChildrenID");
            CreateIndex("dbo.Bookings", "AdultID");
            CreateIndex("dbo.Bookings", "DecorID");
            CreateIndex("dbo.Bookings", "VenueID");
            AddForeignKey("dbo.Bookings", "VenueID", "dbo.Venues", "VenueID", cascadeDelete: true);
            AddForeignKey("dbo.Bookings", "DecorID", "dbo.Decors", "DecorID", cascadeDelete: true);
            AddForeignKey("dbo.Bookings", "ChildrenID", "dbo.Children", "ChildrenID", cascadeDelete: true);
            AddForeignKey("dbo.Bookings", "AdultID", "dbo.Adults", "AdultID", cascadeDelete: true);
        }
    }
}
