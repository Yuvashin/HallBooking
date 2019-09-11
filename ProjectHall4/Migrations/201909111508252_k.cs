namespace ProjectHall4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class k : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Booking2",
                    c => new
                    {
                        Booking2ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        //  time = c.DateTime(nullable: false),
                        TotalNumberOfGuests = c.Int(nullable: false),
                        // numbOfChildren = c.Int(nullable: false),
                        VenueID = c.Int(nullable: false),
                        // cateringPackage = c.Boolean(nullable: false),
                        // decorpackage = c.Boolean(nullable: false),
                        Total_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        // DecorID = c.Int(nullable: false),
                        //   AdultID = c.Int(nullable: false),
                        //  ChildrenID = c.Int(nullable: false),
                        baseVenuePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        // Catering_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        // ChildrenFood_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        //  Venue_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Booking2ID)
                .ForeignKey("dbo.Venues", t => t.VenueID, cascadeDelete: true)
                .Index(t => t.VenueID);


        }

        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "VenueID", "dbo.Venues");

        }
    }
}
