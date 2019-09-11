namespace ProjectHall4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class e : DbMigration
    {
        public override void Up()
        {
           /* CreateTable(
                "dbo.TotalPrices2",
                c => new
                    {
                        TotalPrices2ID = c.Int(nullable: false, identity: true),
                        UserDecorID = c.Int(nullable: false),
                        VenueID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TotalPrices2ID)
                .ForeignKey("dbo.UserDecors", t => t.UserDecorID, cascadeDelete: true)
                .ForeignKey("dbo.Venues", t => t.VenueID, cascadeDelete: true)
                .Index(t => t.UserDecorID)
                .Index(t => t.VenueID);
            
            DropColumn("dbo.UserDecors", "ExternalLoginConfirmationViewModel_Email");*/
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserDecors", "ExternalLoginConfirmationViewModel_Email", c => c.String(nullable: false));
            DropForeignKey("dbo.TotalPrices2", "VenueID", "dbo.Venues");
            DropForeignKey("dbo.TotalPrices2", "UserDecorID", "dbo.UserDecors");
            DropIndex("dbo.TotalPrices2", new[] { "VenueID" });
            DropIndex("dbo.TotalPrices2", new[] { "UserDecorID" });
            DropTable("dbo.TotalPrices2");
        }
    }
}
