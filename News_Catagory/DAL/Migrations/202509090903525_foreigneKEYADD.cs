namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreigneKEYADD : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.News", "ctg_Id", "dbo.Catagories");
            DropIndex("dbo.News", new[] { "ctg_Id" });
            DropColumn("dbo.News", "CId");
            RenameColumn(table: "dbo.News", name: "ctg_Id", newName: "CId");
            AlterColumn("dbo.News", "CId", c => c.Int(nullable: false));
            CreateIndex("dbo.News", "CId");
            AddForeignKey("dbo.News", "CId", "dbo.Catagories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "CId", "dbo.Catagories");
            DropIndex("dbo.News", new[] { "CId" });
            AlterColumn("dbo.News", "CId", c => c.Int());
            RenameColumn(table: "dbo.News", name: "CId", newName: "ctg_Id");
            AddColumn("dbo.News", "CId", c => c.Int(nullable: false));
            CreateIndex("dbo.News", "ctg_Id");
            AddForeignKey("dbo.News", "ctg_Id", "dbo.Catagories", "Id");
        }
    }
}
