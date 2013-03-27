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
                new OrderStatus { StatusId = 1, Name = "Pending", Description = "The order is waiting for process." },
                new OrderStatus { StatusId = 2, Name = "Ready", Description = "The order is ready for shipping." },
                new OrderStatus { StatusId = 3, Name = "Shipped", Description = "The order is shipped." },
                new OrderStatus { StatusId = 4, Name = "Cancelled", Description = "The order is cancelled." },
                new OrderStatus { StatusId = 5, Name = "Hold", Description = "The order is on hold." });
            context.ProductStatuses.AddOrUpdate(
                new ProductStatus { StatusId = 1, Name = "Pending", Description = "The product is waiting for administrator's approval." },
                new ProductStatus { StatusId = 2, Name = "Active", Description = "The product is currently active and public." },
                new ProductStatus { StatusId = 3, Name = "Inactive", Description = "The product is currently inactive." },
                new ProductStatus { StatusId = 4, Name = "Rejected", Description = "The product is rejected and need modification." },
                new ProductStatus { StatusId = 5, Name = "Banned", Description = "The product is banned due to violation." });
            context.StoreStatuses.AddOrUpdate(
                new StoreStatus { StatusId = 1, Name = "Pending", Description = "The store is waiting for administrator's approval." },
                new StoreStatus { StatusId = 2, Name = "Active", Description = "The store is currently active and public." },
                new StoreStatus { StatusId = 3, Name = "Inactive", Description = "The store is currently inactive." },
                new StoreStatus { StatusId = 4, Name = "Rejected", Description = "The store is rejected and need modification." },
                new StoreStatus { StatusId = 5, Name = "Banned", Description = "The store is banned due to violation." });
            // Seed Images
            context.Images.AddOrUpdate(
                new Image { ImageId = 1, Path = "no_img.jpg" },
                new Image { ImageId = 2, Path = "mens.jpg" },
                new Image { ImageId = 3, Path = "womens.jpg" },
                new Image { ImageId = 4, Path = "men_shoes.jpg" },
                new Image { ImageId = 5, Path = "men_shoes_1_1.jpg" },
                new Image { ImageId = 6, Path = "men_shoes_1_2.jpg" },
                new Image { ImageId = 7, Path = "men_shoes_1_3.jpg" }
            );

            context.Profiles.AddOrUpdate(
             
              new Profile { ProfileId = 1, DisplayName = "Chip",DateOfBirth = DateTime.Now,Email = "a@yahoo.com",ContactNumber = "111-11111-1111",TotalFollowers=0,TotalFollowings=0,ProfileImageId =1,AddressId=1 }


          );
            context.ProductLikes.AddOrUpdate(
               new ProductLike { ProductId = 1, UserId = 1 },
               new ProductLike { ProductId = 2, UserId = 1 }

           );
            // Seed Category
            context.Categories.AddOrUpdate(
                new Category { CategoryId = 1, Name = "Root", CoverImageId = 1 },
                new Category { CategoryId = 2, Name = "Men's", CoverImageId = 2, ParentId = 1 },
                new Category { CategoryId = 3, Name = "Women's", CoverImageId = 3, ParentId = 1 },
                new Category
                {
                    CategoryId = 4,
                    Name = "Shoes",
                    CoverImageId = 4,
                    ParentId = 2,
                    Template = new Template { TemplateId = 1, ContentInJson = "[{name: 'Color', content: 'Red'}, {name: 'Size', content: '42, 43'}]" }
                });
            context.Stores.AddOrUpdate(
                new Store
                {
                    StoreId = 1,
                    StoreName = "Casual Shoes Lovers",
                    ContactNumber = "023-432-5234",
                    Description = "A shop for shoes lovers with thousand pairs of shoes",
                    OwnerId = WebSecurity.GetUserId("shoes_lovers"),
                    ShipFee = 9.99F,
                    StatusId = 1,
                    CoverImageId = 1,
                    Slogan = "Find the best shoes in town here.",
                    ProfileImageId = 1,
                    Address = new Address { AddressId = 1, Number = "123", Street = "Shoes' Street", City = "Saigon", Country = "Vietnam", Zipcode = "70100", State = "" }
                });

            // Seed Product;
            context.Products.AddOrUpdate(
                new Product
                {
                    ProductId = 1,
                    Name = "Joe Dark Blue Yellow Casual Shoes",
                    Description = "A pair of beautiful shoes for your daily activities",
                    CategoryId = 4,
                    Price = 35.7F,
                    StatusId = 1,
                    SpecsInJson = @"[{ key: 'Color', value: 'Dark Blue'}, { key: 'Size', value: '42, 43, 44'}]",
                    ProductImages = new List<Image> { context.Images.Find(5), context.Images.Find(6), context.Images.Find(7) },
                    StoreId = 1
                },
                 new Product
                 {
                     ProductId = 2,
                     Name = "Joe Dark Blue Yellow Casual Shoes 2",
                     Description = "A pair of beautiful shoes for your daily activities 2",
                     CategoryId = 4,
                     Price = 35.7F,
                     StatusId = 1,
                     SpecsInJson = @"[{ key: 'Color', value: 'Dark Blue'}, { key: 'Size', value: '42, 43, 44'}]",
                     ProductImages = new List<Image> { context.Images.Find(5), context.Images.Find(6), context.Images.Find(7) },
                     StoreId = 1
                 });


        }
    }
}
