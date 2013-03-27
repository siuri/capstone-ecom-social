namespace Capstone_20130302.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.Comments", new[] { "Product_ProductId" });
            AddColumn("dbo.Comments", "ProductId", c => c.Int());
            AddForeignKey("dbo.Comments", "ProductId", "dbo.Products", "ProductId");
            CreateIndex("dbo.Comments", "ProductId");
            DropColumn("dbo.Comments", "Product_ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Product_ProductId", c => c.Int());
            DropIndex("dbo.Comments", new[] { "ProductId" });
            DropForeignKey("dbo.Comments", "ProductId", "dbo.Products");
            DropColumn("dbo.Comments", "ProductId");
            CreateIndex("dbo.Comments", "Product_ProductId");
            AddForeignKey("dbo.Comments", "Product_ProductId", "dbo.Products", "ProductId");
        }
    }
}
