namespace Capstone_20130302.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Single(nullable: false),
                        TotalLikes = c.Int(nullable: false),
                        TotalComments = c.Int(nullable: false),
                        TotalBuy = c.Int(nullable: false),
                        SpecsInJson = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Status_StatusId = c.Int(),
                        Store_StoreId = c.Int(),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.ProductStatus", t => t.Status_StatusId)
                .ForeignKey("dbo.Stores", t => t.Store_StoreId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .Index(t => t.Status_StatusId)
                .Index(t => t.Store_StoreId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.ProductStatus",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Parent_CategoryId = c.Int(),
                        CoverImage_ImageId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Categories", t => t.Parent_CategoryId)
                .ForeignKey("dbo.Images", t => t.CoverImage_ImageId)
                .Index(t => t.Parent_CategoryId)
                .Index(t => t.CoverImage_ImageId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(),
                        Path = c.String(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.Templates",
                c => new
                    {
                        TemplateId = c.Int(nullable: false, identity: true),
                        ContentInJson = c.String(),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.TemplateId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        FollowId = c.Int(nullable: false, identity: true),
                        User_UserId = c.Int(),
                        FollowedUser_UserId = c.Int(),
                        Store_StoreId = c.Int(),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.FollowId)
                .ForeignKey("dbo.UserProfile", t => t.User_UserId)
                .ForeignKey("dbo.UserProfile", t => t.FollowedUser_UserId)
                .ForeignKey("dbo.Stores", t => t.Store_StoreId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .Index(t => t.User_UserId)
                .Index(t => t.FollowedUser_UserId)
                .Index(t => t.Store_StoreId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        StoreName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 50),
                        ContactNumber = c.String(nullable: false, maxLength: 25),
                        CreateDate = c.DateTime(nullable: false),
                        Slogan = c.String(maxLength: 150),
                        ShipFee = c.Single(nullable: false),
                        TotalFollowers = c.Int(nullable: false),
                        TotalFollowings = c.Int(nullable: false),
                        Owner_UserId = c.Int(),
                        Status_StatusId = c.Int(),
                        CoverImage_ImageId = c.Int(),
                        ProfileImage_ImageId = c.Int(),
                    })
                .PrimaryKey(t => t.StoreId)
                .ForeignKey("dbo.UserProfile", t => t.Owner_UserId)
                .ForeignKey("dbo.StoreStatus", t => t.Status_StatusId)
                .ForeignKey("dbo.Images", t => t.CoverImage_ImageId)
                .ForeignKey("dbo.Images", t => t.ProfileImage_ImageId)
                .Index(t => t.Owner_UserId)
                .Index(t => t.Status_StatusId)
                .Index(t => t.CoverImage_ImageId)
                .Index(t => t.ProfileImage_ImageId);
            
            CreateTable(
                "dbo.StoreStatus",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.Int(nullable: false),
                        IsSetAsDefault = c.Boolean(nullable: false),
                        Store_StoreId = c.Int(),
                        Buyer_BuyerId = c.Int(),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Stores", t => t.Store_StoreId)
                .ForeignKey("dbo.Buyers", t => t.Buyer_BuyerId)
                .Index(t => t.Store_StoreId)
                .Index(t => t.Buyer_BuyerId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        CommentContent = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        User_UserId = c.Int(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.UserProfile", t => t.User_UserId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.User_UserId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        SoldPrice = c.Single(nullable: false),
                        Product_ProductId = c.Int(),
                        Order_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId)
                .Index(t => t.Product_ProductId)
                .Index(t => t.Order_OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        TotalPayment = c.Single(nullable: false),
                        BillingAddress_AddressId = c.Int(),
                        ShippingAddress_AddressId = c.Int(),
                        OrderStatus_StatusId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Addresses", t => t.BillingAddress_AddressId)
                .ForeignKey("dbo.Addresses", t => t.ShippingAddress_AddressId)
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatus_StatusId)
                .Index(t => t.BillingAddress_AddressId)
                .Index(t => t.ShippingAddress_AddressId)
                .Index(t => t.OrderStatus_StatusId);
            
            CreateTable(
                "dbo.webpages_Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.webpages_Membership",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        ConfirmationToken = c.String(maxLength: 128),
                        IsConfirmed = c.Boolean(),
                        LastPasswordFailureDate = c.DateTime(),
                        PasswordFailuresSinceLastSuccess = c.Int(nullable: false),
                        Password = c.String(nullable: false, maxLength: 128),
                        PasswordChangedDate = c.DateTime(),
                        PasswordSalt = c.String(nullable: false, maxLength: 128),
                        PasswordVerificationToken = c.String(maxLength: 128),
                        PasswordVerificationTokenExpirationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.webpages_OAuthMembership",
                c => new
                    {
                        Provider = c.String(nullable: false, maxLength: 30),
                        ProviderUserId = c.String(nullable: false, maxLength: 100),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Provider, t.ProviderUserId });
            
            CreateTable(
                "dbo.Buyers",
                c => new
                    {
                        BuyerId = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                        Gender = c.Boolean(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        ContactNumber = c.String(),
                        TotalFollowers = c.Int(nullable: false),
                        TotalFollowings = c.Int(nullable: false),
                        User_UserId = c.Int(),
                        ProfileImage_ImageId = c.Int(),
                    })
                .PrimaryKey(t => t.BuyerId)
                .ForeignKey("dbo.UserProfile", t => t.User_UserId)
                .ForeignKey("dbo.Images", t => t.ProfileImage_ImageId)
                .Index(t => t.User_UserId)
                .Index(t => t.ProfileImage_ImageId);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.ProductUserProfiles",
                c => new
                    {
                        Product_ProductId = c.Int(nullable: false),
                        UserProfile_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.UserProfile_UserId })
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfile", t => t.UserProfile_UserId, cascadeDelete: true)
                .Index(t => t.Product_ProductId)
                .Index(t => t.UserProfile_UserId);
            
            CreateTable(
                "dbo.webpages_UsersInRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.UserProfile", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.webpages_Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.webpages_UsersInRoles", new[] { "RoleId" });
            DropIndex("dbo.webpages_UsersInRoles", new[] { "UserId" });
            DropIndex("dbo.ProductUserProfiles", new[] { "UserProfile_UserId" });
            DropIndex("dbo.ProductUserProfiles", new[] { "Product_ProductId" });
            DropIndex("dbo.Buyers", new[] { "ProfileImage_ImageId" });
            DropIndex("dbo.Buyers", new[] { "User_UserId" });
            DropIndex("dbo.Orders", new[] { "OrderStatus_StatusId" });
            DropIndex("dbo.Orders", new[] { "ShippingAddress_AddressId" });
            DropIndex("dbo.Orders", new[] { "BillingAddress_AddressId" });
            DropIndex("dbo.OrderDetails", new[] { "Order_OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "Product_ProductId" });
            DropIndex("dbo.Comments", new[] { "Product_ProductId" });
            DropIndex("dbo.Comments", new[] { "User_UserId" });
            DropIndex("dbo.Addresses", new[] { "Buyer_BuyerId" });
            DropIndex("dbo.Addresses", new[] { "Store_StoreId" });
            DropIndex("dbo.Stores", new[] { "ProfileImage_ImageId" });
            DropIndex("dbo.Stores", new[] { "CoverImage_ImageId" });
            DropIndex("dbo.Stores", new[] { "Status_StatusId" });
            DropIndex("dbo.Stores", new[] { "Owner_UserId" });
            DropIndex("dbo.Follows", new[] { "Category_CategoryId" });
            DropIndex("dbo.Follows", new[] { "Store_StoreId" });
            DropIndex("dbo.Follows", new[] { "FollowedUser_UserId" });
            DropIndex("dbo.Follows", new[] { "User_UserId" });
            DropIndex("dbo.Templates", new[] { "Category_CategoryId" });
            DropIndex("dbo.Images", new[] { "Product_ProductId" });
            DropIndex("dbo.Categories", new[] { "CoverImage_ImageId" });
            DropIndex("dbo.Categories", new[] { "Parent_CategoryId" });
            DropIndex("dbo.Products", new[] { "Category_CategoryId" });
            DropIndex("dbo.Products", new[] { "Store_StoreId" });
            DropIndex("dbo.Products", new[] { "Status_StatusId" });
            DropForeignKey("dbo.webpages_UsersInRoles", "RoleId", "dbo.webpages_Roles");
            DropForeignKey("dbo.webpages_UsersInRoles", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.ProductUserProfiles", "UserProfile_UserId", "dbo.UserProfile");
            DropForeignKey("dbo.ProductUserProfiles", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Buyers", "ProfileImage_ImageId", "dbo.Images");
            DropForeignKey("dbo.Buyers", "User_UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Orders", "OrderStatus_StatusId", "dbo.OrderStatus");
            DropForeignKey("dbo.Orders", "ShippingAddress_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Orders", "BillingAddress_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.OrderDetails", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Comments", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Comments", "User_UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Addresses", "Buyer_BuyerId", "dbo.Buyers");
            DropForeignKey("dbo.Addresses", "Store_StoreId", "dbo.Stores");
            DropForeignKey("dbo.Stores", "ProfileImage_ImageId", "dbo.Images");
            DropForeignKey("dbo.Stores", "CoverImage_ImageId", "dbo.Images");
            DropForeignKey("dbo.Stores", "Status_StatusId", "dbo.StoreStatus");
            DropForeignKey("dbo.Stores", "Owner_UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Follows", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Follows", "Store_StoreId", "dbo.Stores");
            DropForeignKey("dbo.Follows", "FollowedUser_UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Follows", "User_UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Templates", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Images", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Categories", "CoverImage_ImageId", "dbo.Images");
            DropForeignKey("dbo.Categories", "Parent_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "Store_StoreId", "dbo.Stores");
            DropForeignKey("dbo.Products", "Status_StatusId", "dbo.ProductStatus");
            DropTable("dbo.webpages_UsersInRoles");
            DropTable("dbo.ProductUserProfiles");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.Buyers");
            DropTable("dbo.webpages_OAuthMembership");
            DropTable("dbo.webpages_Membership");
            DropTable("dbo.webpages_Roles");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Comments");
            DropTable("dbo.Addresses");
            DropTable("dbo.StoreStatus");
            DropTable("dbo.Stores");
            DropTable("dbo.Follows");
            DropTable("dbo.Templates");
            DropTable("dbo.Images");
            DropTable("dbo.Categories");
            DropTable("dbo.ProductStatus");
            DropTable("dbo.Products");
            DropTable("dbo.UserProfile");
        }
    }
}
