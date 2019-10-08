namespace ProjectHall4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b : DbMigration
    {
        public override void Up()
        {
           /*AddColumn("dbo.UserCaterings", "BookingStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserCaterings", "BookingStatusId");
            AddForeignKey("dbo.UserCaterings", "BookingStatusId", "dbo.BookingStatus", "BookingStatusId", cascadeDelete: true);
            DropColumn("dbo.UserCaterings", "Email");*/
        }
        
        public override void Down()
        {
           /* AddColumn("dbo.UserCaterings", "Email", c => c.String());
            DropForeignKey("dbo.UserCaterings", "BookingStatusId", "dbo.BookingStatus");
            DropIndex("dbo.UserCaterings", new[] { "BookingStatusId" });
            DropColumn("dbo.UserCaterings", "BookingStatusId");*/
        }
    }
}
