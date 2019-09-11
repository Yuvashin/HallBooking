namespace ProjectHall4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class n : DbMigration
    {
        public override void Up()
        {
          //  DropTable("dbo.Caterings");
        }
        
        public override void Down()
        {
            /*CreateTable(
                "dbo.Caterings",
                c => new
                    {
                        CateringID = c.Int(nullable: false, identity: true),
                        CateringPackage = c.String(nullable: false),
                        CateringPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CateringID);
            */
        }
    }
}
