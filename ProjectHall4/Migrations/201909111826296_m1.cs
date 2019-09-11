namespace ProjectHall4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Caters",
                c => new
                    {
                        CateringID = c.Int(nullable: false, identity: true),
                        CateringPackage = c.String(nullable: false),
                        CateringPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CateringID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Caters");
        }
    }
}
