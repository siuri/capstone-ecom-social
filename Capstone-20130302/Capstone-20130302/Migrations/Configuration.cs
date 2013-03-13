namespace Capstone_20130302.Migrations
{
    using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Security;
using Capstone_20130302.Models;
using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<Capstone_20130302.Models.SocialBuyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Capstone_20130302.Models.SocialBuyContext context)
        {
            WebSecurity.InitializeDatabaseConnection(
                "DefaultConnection",
                "UserProfile",
                "UserId",
                "UserName", autoCreateTables: true);

            if (!Roles.RoleExists("admin"))
                Roles.CreateRole("admin");
            if (!Roles.RoleExists("seller"))
                Roles.CreateRole("seller");
            if (!Roles.RoleExists("buyer"))
                Roles.CreateRole("buyer");
            if (!WebSecurity.UserExists("admin001"))
                WebSecurity.CreateUserAndAccount(
                    "admin001",
                    "123456");
            if (!WebSecurity.UserExists("shoes_lovers"))
                WebSecurity.CreateUserAndAccount(
                    "shoes_lovers",
                    "123456");

            if (!Roles.GetRolesForUser("admin001").Contains("admin"))
                Roles.AddUsersToRoles(new[] { "admin001" }, new[] { "admin" });
            // Seed Status
            context.OrderStatuses.AddOrUpdate(
                new OrderStatus { StatusId = 0, Name = "Pending", Description = "The order is waiting for process." },
                new OrderStatus { StatusId = 1, Name = "Ready", Description = "The order is ready for shipping." },
                new OrderStatus { StatusId = 2, Name = "Shipped", Description = "The order is shipped." },
                new OrderStatus { StatusId = 3, Name = "Cancelled", Description = "The order is cancelled." },
                new OrderStatus { StatusId = 4, Name = "Hold", Description = "The order is on hold." });
            context.ProductStatuses.AddOrUpdate(
                new ProductStatus { StatusId = 0, Name = "Pending", Description = "The product is waiting for administrator's approval." },
                new ProductStatus { StatusId = 1, Name = "Active", Description = "The product is currently active and public." },
                new ProductStatus { StatusId = 2, Name = "Inactive", Description = "The product is currently inactive." },
                new ProductStatus { StatusId = 3, Name = "Rejected", Description = "The product is rejected and need modification." },
                new ProductStatus { StatusId = 4, Name = "Banned", Description = "The product is banned due to violation." });
            context.StoreStatuses.AddOrUpdate(
                new StoreStatus { StatusId = 0, Name = "Pending", Description = "The store is waiting for administrator's approval." },
                new StoreStatus { StatusId = 1, Name = "Active", Description = "The store is currently active and public." },
                new StoreStatus { StatusId = 2, Name = "Inactive", Description = "The store is currently inactive." },
                new StoreStatus { StatusId = 3, Name = "Rejected", Description = "The store is rejected and need modification." },
                new StoreStatus { StatusId = 4, Name = "Banned", Description = "The store is banned due to violation." });
            // Seed Images
            context.Images.AddOrUpdate(
                new Image { ImageId = 0, Path = "no_img.jpg" },
                new Image { ImageId = 1, Path = "mens.jpg" },
                new Image { ImageId = 2, Path = "womens.jpg" },
                new Image { ImageId = 3, Path = "men_shoes.jpg"},
                new Image { ImageId = 4, Path = "men_shoes_1_1.jpg"},
                new Image { ImageId = 5, Path = "men_shoes_1_2.jpg"},
                new Image { ImageId = 6, Path = "men_shoes_1_3.jpg"}
            );
            
            // Seed Category
            context.Categories.AddOrUpdate(
                new Category { CategoryId = 0, Name = "Root", CoverImage = context.Images.Find(0) },
                new Category { CategoryId = 1, Name = "Men's", CoverImage = context.Images.Find(1), Parent = context.Categories.Find(0) },
                new Category { CategoryId = 2, Name = "Women's", CoverImage = context.Images.Find(2), Parent = context.Categories.Find(0) },
                new Category { CategoryId = 3, Name = "Shoes", CoverImage = context.Images.Find(3), Parent = context.Categories.Find(1)});
            context.Stores.AddOrUpdate(
                new Store
                {
                    StoreId = 0,
                    StoreName = "Casual Shoes Lovers",
                    ContactNumber = "023-432-5234",
                    Description = "A shop for shoes lovers with thousand pairs of shoes",
                    Owner = context.UserProfiles.Find(WebSecurity.GetUserId("shoes_lovers")),
                    ShipFee = 9.99F,
                    Status = context.StoreStatuses.Find(0),
                    CoverImage = context.Images.Find(0),
                    Slogan = "Find the best shoes in town here.",
                    ProfileImage = context.Images.Find(0),
                    Addresses = new List<Address> { new Address { AddressId = 0, Number = "123", Street = "Shoes' Street", City = "Saigon", Country = "Vietnam", Zipcode = "70100", State = "" } }
                });

            // Seed Product;
            context.Products.AddOrUpdate(
                new Product
                {
                    ProductId = 0,
                    Name = "Joe Dark Blue Yellow Casual Shoes",
                    Description = "A pair of beautiful shoes for your daily activities",
                    Category = context.Categories.Find(3),
                    Price = 35.7F,
                    Status = context.ProductStatuses.Find(0),
                    SpecsInJson = @"[{ key: 'Color', value: 'Dark Blue'}, { key: 'Size', value: '42, 43, 44'}]",
                    ProductImages = new List<Image> { context.Images.Find(4), context.Images.Find(5), context.Images.Find(6) },
                    Store = context.Stores.Find(0)
                });
            
        }
    }
}
