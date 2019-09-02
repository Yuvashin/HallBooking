namespace ProjectHall4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adults",
                c => new
                    {
                        AdultID = c.Int(nullable: false, identity: true),
                        CateringType = c.String(nullable: false),
                        CateringPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.AdultID);
            
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
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Adults", t => t.AdultID, cascadeDelete: true)
                .ForeignKey("dbo.Children", t => t.ChildrenID, cascadeDelete: true)
                .ForeignKey("dbo.Decors", t => t.DecorID, cascadeDelete: true)
                .ForeignKey("dbo.Venues", t => t.VenueID, cascadeDelete: true)
                .Index(t => t.VenueID)
                .Index(t => t.DecorID)
                .Index(t => t.AdultID)
                .Index(t => t.ChildrenID);
            
            CreateTable(
                "dbo.Children",
                c => new
                    {
                        ChildrenID = c.Int(nullable: false, identity: true),
                        ChildrenFood = c.String(nullable: false),
                        ChildrenFoodPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ChildrenID);
            
            CreateTable(
                "dbo.Decors",
                c => new
                    {
                        DecorID = c.Int(nullable: false, identity: true),
                        DecorColourOne = c.String(nullable: false),
                        DecorPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DecorID);
            
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        VenueID = c.Int(nullable: false, identity: true),
                        VenueName = c.String(nullable: false),
                        VenuePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.VenueID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Bookings", "VenueID", "dbo.Venues");
            DropForeignKey("dbo.Bookings", "DecorID", "dbo.Decors");
            DropForeignKey("dbo.Bookings", "ChildrenID", "dbo.Children");
            DropForeignKey("dbo.Bookings", "AdultID", "dbo.Adults");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Bookings", new[] { "ChildrenID" });
            DropIndex("dbo.Bookings", new[] { "AdultID" });
            DropIndex("dbo.Bookings", new[] { "DecorID" });
            DropIndex("dbo.Bookings", new[] { "VenueID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Venues");
            DropTable("dbo.Decors");
            DropTable("dbo.Children");
            DropTable("dbo.Bookings");
            DropTable("dbo.Adults");
        }
    }
}
