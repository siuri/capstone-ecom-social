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
                        ProfileId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Profiles", t => t.ProfileId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Single(nullable: false),
                        TotalLikes = c.Int(nullable: false),
                        TotalComments = c.Int(nullable: false),
                        TotalBuy = c.Int(nullable: false),
                        SpecsInJson = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        StatusId = c.Int(),
                        CategoryId = c.Int(),
                        StoreId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.ProductStatus", t => t.StatusId)
                .ForeignKey("dbo.Stores", t => t.StoreId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.StatusId)
                .Index(t => t.StoreId)
                .Index(t => t.CategoryId);
            
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
                        ParentId = c.Int(),
                        CoverImageId = c.Int(),
                        TemplateId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Categories", t => t.ParentId)
                .ForeignKey("dbo.Images", t => t.CoverImageId)
                .ForeignKey("dbo.Templates", t => t.TemplateId)
                .Index(t => t.ParentId)
                .Index(t => t.CoverImageId)
                .Index(t => t.TemplateId);
            
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
                    })
                .PrimaryKey(t => t.TemplateId);
            
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        FollowId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        FollowedUserId = c.Int(),
                        StoreId = c.Int(),
                        CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.FollowId)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .ForeignKey("dbo.UserProfile", t => t.FollowedUserId)
                .ForeignKey("dbo.Stores", t => t.StoreId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.UserId)
                .Index(t => t.FollowedUserId)
                .Index(t => t.StoreId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        StoreName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                        ContactNumber = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Slogan = c.String(maxLength: 150),
                        ShipFee = c.Single(nullable: false),
                        TotalFollowers = c.Int(nullable: false),
                        TotalFollowings = c.Int(nullable: false),
                        OwnerId = c.Int(),
                        StatusId = c.Int(),
                        CoverImageId = c.Int(),
                        ProfileImageId = c.Int(),
                        AddressId = c.Int(),
                    })
                .PrimaryKey(t => t.StoreId)
                .ForeignKey("dbo.UserProfile", t => t.OwnerId)
                .ForeignKey("dbo.StoreStatus", t => t.StatusId)
                .ForeignKey("dbo.Images", t => t.CoverImageId)
                .ForeignKey("dbo.Images", t => t.ProfileImageId)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.OwnerId)
                .Index(t => t.StatusId)
                .Index(t => t.CoverImageId)
                .Index(t => t.ProfileImageId)
                .Index(t => t.AddressId);
            
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
                        Zipcode = c.String(),
                        Country = c.String(),
                        IsSetAsDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(),
                        Title = c.String(),
                        Body = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.UserProfile", t => t.User_UserId)
                .ForeignKey("dbo.Stores", t => t.StoreId)
                .Index(t => t.User_UserId)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        CommentContent = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UserId = c.Int(),
                        ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        SoldPrice = c.Single(nullable: false),
                        ProductId = c.Int(),
                        OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .Index(t => t.ProductId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        TotalPayment = c.Single(nullable: false),
                        BillingName = c.String(nullable: false),
                        BillingAddressId = c.Int(nullable: false),
                        IsUsedAsShipping = c.Boolean(nullable: false),
                        ShippingName = c.String(),
                        ShippingAddressId = c.Int(),
                        StatusId = c.Int(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Addresses", t => t.BillingAddressId, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.ShippingAddressId)
                .ForeignKey("dbo.OrderStatus", t => t.StatusId)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.BillingAddressId)
                .Index(t => t.ShippingAddressId)
                .Index(t => t.StatusId)
                .Index(t => t.UserId);
            
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
                "dbo.Profiles",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        ContactNumber = c.String(),
                        TotalFollowers = c.Int(nullable: false),
                        TotalFollowings = c.Int(nullable: false),
                        ProfileImageId = c.Int(),
                        AddressId = c.Int(),
                    })
                .PrimaryKey(t => t.ProfileId)
                .ForeignKey("dbo.Images", t => t.ProfileImageId)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.ProfileImageId)
                .Index(t => t.AddressId);
            
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
            DropIndex("dbo.ProductLikes", new[] { "ProductId" });
            DropIndex("dbo.ProductLikes", new[] { "UserId" });
            DropIndex("dbo.Profiles", new[] { "AddressId" });
            DropIndex("dbo.Profiles", new[] { "ProfileImageId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "StatusId" });
            DropIndex("dbo.Orders", new[] { "ShippingAddressId" });
            DropIndex("dbo.Orders", new[] { "BillingAddressId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.Comments", new[] { "ProductId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Messages", new[] { "StoreId" });
            DropIndex("dbo.Messages", new[] { "User_UserId" });
            DropIndex("dbo.Stores", new[] { "AddressId" });
            DropIndex("dbo.Stores", new[] { "ProfileImageId" });
            DropIndex("dbo.Stores", new[] { "CoverImageId" });
            DropIndex("dbo.Stores", new[] { "StatusId" });
            DropIndex("dbo.Stores", new[] { "OwnerId" });
            DropIndex("dbo.Follows", new[] { "CategoryId" });
            DropIndex("dbo.Follows", new[] { "StoreId" });
            DropIndex("dbo.Follows", new[] { "FollowedUserId" });
            DropIndex("dbo.Follows", new[] { "UserId" });
            DropIndex("dbo.Images", new[] { "Product_ProductId" });
            DropIndex("dbo.Categories", new[] { "TemplateId" });
            DropIndex("dbo.Categories", new[] { "CoverImageId" });
            DropIndex("dbo.Categories", new[] { "ParentId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "StoreId" });
            DropIndex("dbo.Products", new[] { "StatusId" });
            DropIndex("dbo.UserProfile", new[] { "ProfileId" });
            DropForeignKey("dbo.webpages_UsersInRoles", "RoleId", "dbo.webpages_Roles");
            DropForeignKey("dbo.webpages_UsersInRoles", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.ProductUserProfiles", "UserProfile_UserId", "dbo.UserProfile");
            DropForeignKey("dbo.ProductUserProfiles", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductLikes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductLikes", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Profiles", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Profiles", "ProfileImageId", "dbo.Images");
            DropForeignKey("dbo.Orders", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Orders", "StatusId", "dbo.OrderStatus");
            DropForeignKey("dbo.Orders", "ShippingAddressId", "dbo.Addresses");
            DropForeignKey("dbo.Orders", "BillingAddressId", "dbo.Addresses");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Comments", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Comments", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Messages", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Messages", "User_UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Stores", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Stores", "ProfileImageId", "dbo.Images");
            DropForeignKey("dbo.Stores", "CoverImageId", "dbo.Images");
            DropForeignKey("dbo.Stores", "StatusId", "dbo.StoreStatus");
            DropForeignKey("dbo.Stores", "OwnerId", "dbo.UserProfile");
            DropForeignKey("dbo.Follows", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Follows", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Follows", "FollowedUserId", "dbo.UserProfile");
            DropForeignKey("dbo.Follows", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Images", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Categories", "TemplateId", "dbo.Templates");
            DropForeignKey("dbo.Categories", "CoverImageId", "dbo.Images");
            DropForeignKey("dbo.Categories", "ParentId", "dbo.Categories");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Products", "StatusId", "dbo.ProductStatus");
            DropForeignKey("dbo.UserProfile", "ProfileId", "dbo.Profiles");
            DropTable("dbo.webpages_UsersInRoles");
            DropTable("dbo.ProductUserProfiles");
            DropTable("dbo.ProductLikes");
            DropTable("dbo.webpages_OAuthMembership");
            DropTable("dbo.webpages_Membership");
            DropTable("dbo.webpages_Roles");
            DropTable("dbo.Profiles");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Comments");
            DropTable("dbo.Messages");
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
