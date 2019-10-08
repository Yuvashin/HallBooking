namespace ProjectHall4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c : DbMigration
    {
        public override void Up()
        {
           /* AddColumn("dbo.UserDecors", "BookingStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserDecors", "BookingStatusId");
            AddForeignKey("dbo.UserDecors", "BookingStatusId", "dbo.BookingStatus", "BookingStatusId", cascadeDelete: true);
            DropColumn("dbo.UserDecors", "Email");*/
        }
        
        public override void Down()
        {
          /*  AddColumn("dbo.UserDecors", "Email", c => c.String());
            DropForeignKey("dbo.UserDecors", "BookingStatusId", "dbo.BookingStatus");
            DropIndex("dbo.UserDecors", new[] { "BookingStatusId" });
            DropColumn("dbo.UserDecors", "BookingStatusId");*/
        }
    }
}
