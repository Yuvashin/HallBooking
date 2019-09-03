namespace ProjectHall4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileUploadModels",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        File = c.Binary(),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.FileId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FileUploadModels");
        }
    }
}
