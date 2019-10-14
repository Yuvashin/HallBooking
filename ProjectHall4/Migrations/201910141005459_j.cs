namespace ProjectHall4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingStatus", "ReferenceNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookingStatus", "ReferenceNumber");
        }
    }
}
