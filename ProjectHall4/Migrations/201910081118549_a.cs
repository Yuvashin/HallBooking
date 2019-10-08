namespace ProjectHall4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserDecors", "Booking2ID", "dbo.Booking2");
            DropForeignKey("dbo.UserCaterings", "Booking2ID", "dbo.Booking2");
            DropIndex("dbo.UserDecors", new[] { "Booking2ID" });
            DropIndex("dbo.UserCaterings", new[] { "Booking2ID" });
            CreateTable(
                "dbo.BookingStatus",
                c => new
                    {
                        BookingStatusId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Step1 = c.Boolean(nullable: false),
                        Step2 = c.Boolean(nullable: false),
                        Step3 = c.Boolean(nullable: false),
                        Step4 = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookingStatusId);
          
        }
        
        public override void Down()
        {
            
        }
    }
}
