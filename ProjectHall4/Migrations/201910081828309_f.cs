namespace ProjectHall4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentsId = c.Int(nullable: false, identity: true),
                        BookingStatusId = c.Int(nullable: false),
                        TotalCost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentsId)
                .ForeignKey("dbo.BookingStatus", t => t.BookingStatusId, cascadeDelete: true)
                .Index(t => t.BookingStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "BookingStatusId", "dbo.BookingStatus");
            DropIndex("dbo.Payments", new[] { "BookingStatusId" });
            DropTable("dbo.Payments");
        }
    }
}
