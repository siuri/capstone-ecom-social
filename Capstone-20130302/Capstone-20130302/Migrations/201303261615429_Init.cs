namespace Capstone_20130302.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductLikes",
                c => new
                    {
                        ProductLikeId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductLikeId)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProductLikes", new[] { "ProductId" });
            DropIndex("dbo.ProductLikes", new[] { "UserId" });
            DropForeignKey("dbo.ProductLikes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductLikes", "UserId", "dbo.UserProfile");
            DropTable("dbo.ProductLikes");
        }
    }
}
