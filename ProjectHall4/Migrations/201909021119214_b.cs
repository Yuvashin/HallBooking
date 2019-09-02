namespace ProjectHall4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Venues", "MaxCapity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Venues", "MaxCapity");
        }
    }
}
