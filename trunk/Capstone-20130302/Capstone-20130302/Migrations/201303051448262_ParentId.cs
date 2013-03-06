namespace Capstone_20130302.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParentId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Parent_CategoryId", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "Parent_CategoryId" });
            AddColumn("dbo.Categories", "ParentId", c => c.Int(nullable: false));
            DropColumn("dbo.Categories", "Parent_CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Parent_CategoryId", c => c.Int());
            DropColumn("dbo.Categories", "ParentId");
            CreateIndex("dbo.Categories", "Parent_CategoryId");
            AddForeignKey("dbo.Categories", "Parent_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
