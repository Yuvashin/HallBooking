namespace ProjectHall4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f1 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Adults");
            DropTable("dbo.Children");
        }
        
        public override void Down()
        {
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
                "dbo.Adults",
                c => new
                    {
                        AdultID = c.Int(nullable: false, identity: true),
                        CateringType = c.String(nullable: false),
                        CateringPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.AdultID);
            
        }
    }
}
