namespace ProjectHall4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
           /* DropForeignKey("dbo.TotalPrices2", "UserDecorID", "dbo.UserDecors");
            DropPrimaryKey("dbo.UserDecors");
            DropPrimaryKey("dbo.UserCaterings");
            AddColumn("dbo.UserDecors", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.UserCaterings", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserDecors", "Id");
            AddPrimaryKey("dbo.UserCaterings", "Id");
            AddForeignKey("dbo.TotalPrices2", "UserDecorID", "dbo.UserDecors", "Id", cascadeDelete: true);
            DropColumn("dbo.UserDecors", "UserDecorId");
            DropColumn("dbo.UserCaterings", "UserCateringId");*/
        }
        
        public override void Down()
        {
           /* AddColumn("dbo.UserCaterings", "UserCateringId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.UserDecors", "UserDecorId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.TotalPrices2", "UserDecorID", "dbo.UserDecors");
            DropPrimaryKey("dbo.UserCaterings");
            DropPrimaryKey("dbo.UserDecors");
            DropColumn("dbo.UserCaterings", "Id");
            DropColumn("dbo.UserDecors", "Id");
            AddPrimaryKey("dbo.UserCaterings", "UserCateringId");
            AddPrimaryKey("dbo.UserDecors", "UserDecorId");
            AddForeignKey("dbo.TotalPrices2", "UserDecorID", "dbo.UserDecors", "UserDecorId", cascadeDelete: true);*/
        }
    }
}
