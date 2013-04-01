namespace Capstone_20130302.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "StoreId", c => c.Int());
            AddForeignKey("dbo.Orders", "StoreId", "dbo.Stores", "StoreId");
            CreateIndex("dbo.Orders", "StoreId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Orders", new[] { "StoreId" });
            DropForeignKey("dbo.Orders", "StoreId", "dbo.Stores");
            DropColumn("dbo.Orders", "StoreId");
        }
    }
}
