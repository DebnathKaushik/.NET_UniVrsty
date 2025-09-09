namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CName = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 8000, unicode: false),
                        Date = c.DateTime(nullable: false),
                        CId = c.Int(nullable: false),
                        ctg_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Catagories", t => t.ctg_Id)
                .Index(t => t.ctg_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "ctg_Id", "dbo.Catagories");
            DropIndex("dbo.News", new[] { "ctg_Id" });
            DropTable("dbo.News");
            DropTable("dbo.Catagories");
        }
    }
}
