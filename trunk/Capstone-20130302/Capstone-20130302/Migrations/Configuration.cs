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
    using System.Data;

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
            if (!WebSecurity.UserExists("hongdc"))
                WebSecurity.CreateUserAndAccount(
                    "hongdc",
                    "123456");

            if (!Roles.GetRolesForUser("admin001").Contains("admin"))
                Roles.AddUsersToRoles(new[] { "admin001" }, new[] { "admin" });
            if (!Roles.GetRolesForUser("shoes_lovers").Contains("seller"))
                Roles.AddUsersToRoles(new[] { "shoes_lovers" }, new[] { "seller" });
            if (!Roles.GetRolesForUser("hongdc").Contains("seller"))
                Roles.AddUsersToRoles(new[] { "hongdc" }, new[] { "seller" });
            // Seed Status
            context.OrderStatuses.AddOrUpdate(
                new OrderStatus { StatusId = 1, Name = "Pending", Description = "The order is waiting for process." },
                new OrderStatus { StatusId = 2, Name = "Ready", Description = "The order is ready for shipping." },
                new OrderStatus { StatusId = 3, Name = "Shipped", Description = "The order is shipped." },
                new OrderStatus { StatusId = 4, Name = "Cancelled", Description = "The order is cancelled." },
                new OrderStatus { StatusId = 5, Name = "Hold", Description = "The order is on hold." });
            context.ProductStatuses.AddOrUpdate(
                new ProductStatus { StatusId = 1, Name = "Inactive", Description = "The product is currently not public." },
                new ProductStatus { StatusId = 2, Name = "Active", Description = "The product is currently active and public." },
                new ProductStatus { StatusId = 3, Name = "Banned", Description = "The product is banned by moderators due to violation." });
            context.StoreStatuses.AddOrUpdate(
                new StoreStatus { StatusId = 1, Name = "Inactive", Description = "The store is currently not inactive." },
                new StoreStatus { StatusId = 2, Name = "Active", Description = "The store is currently active and public." },
                new StoreStatus { StatusId = 3, Name = "Banned", Description = "The store is banned by moderators due to violation." });
            // Seed Images
            context.Images.AddOrUpdate(
                new Image { ImageId = 1, Path = "no_img.jpg" },
                new Image { ImageId = 2, Path = "mens.jpg" },
                new Image { ImageId = 3, Path = "womens.jpg" },
                new Image { ImageId = 4, Path = "men_shoes.jpg" },
                new Image { ImageId = 5, Path = "men_shoes_1_1.jpg" },
                new Image { ImageId = 6, Path = "men_shoes_1_2.jpg" },
                new Image { ImageId = 7, Path = "men_shoes_1_3.jpg" },
                new Image { ImageId = 8, Path = "foods.jpg" },
                new Image { ImageId = 9, Path = "cakes.jpg" },
                new Image { ImageId = 10, Path = "alcohol.jpg" },
                new Image { ImageId = 11, Path = "kame.jpg" },
                new Image { ImageId = 12, Path = "kame1.jpg" },
                new Image { ImageId = 13, Path = "kame2.jpg" },
                new Image { ImageId = 14, Path = "alcohol.jpg" },
                new Image { ImageId = 15, Path = "sacra1.jpg" },
                new Image { ImageId = 16, Path = "sacra2.jpg" },
                new Image { ImageId = 17, Path = "sacra3.jpg" },
                new Image { ImageId = 18, Path = "avt.jpg" },
                new Image { ImageId = 19, Path = "cover.jpg" }
            );
            context.Addresses.AddOrUpdate(
                new Address { AddressId = 1, Number = "123", City = "Saigon", Country = "Vietnam", State = "Ho Chi Minh", Street = "Street Road", Zipcode = "70100" },
                new Address { AddressId = 2, Number = "234", City = "Hanoi", Country = "Vietnam", State = "Hanoi", Street = "Phan Boi Chau", Zipcode = "70110" },
                new Address { AddressId = 3, Number = "563", City = "Saigon", Country = "Vietnam", State = "Ho Chi Minh", Street = "Ba Thang Hai Road", Zipcode = "70400" });
            context.Profiles.AddOrUpdate(
               new Profile { ProfileId = 1, DisplayName = "Admin", DateOfBirth = DateTime.Now, Email = "admin@socialbuy.vn", ContactNumber = "111-11111-1111", TotalFollowers = 0, TotalFollowings = 0, ProfileImageId = 1, AddressId = 1 },
               new Profile { ProfileId = 2, DisplayName = "Shoes Lover", DateOfBirth = DateTime.Now, Email = "shoes@socialbuy.vn", ContactNumber = "111-11111-1111", TotalFollowers = 0, TotalFollowings = 0, ProfileImageId = 1, AddressId = 2 },
               new Profile { ProfileId = 3, DisplayName = "HongDC", DateOfBirth = DateTime.Now, Email = "hongdc@gmail.com", ContactNumber = "111-23423-1111", TotalFollowers = 0, TotalFollowings = 0, ProfileImageId = 18, AddressId = 3 }
            );

            // Connect Profile with User
            var user1 = context.UserProfiles.Find(1);
            user1.ProfileId = 1;
            context.Entry(user1).State = EntityState.Modified;

            var user2 = context.UserProfiles.Find(2);
            user2.ProfileId = 2;
            context.Entry(user2).State = EntityState.Modified;

            var user3 = context.UserProfiles.Find(3);
            user3.ProfileId = 3;
            context.Entry(user3).State = EntityState.Modified;
            context.SaveChanges();


            context.ProductLikes.AddOrUpdate(
               new ProductLike { ProductLikeId = 1, ProductId = 1, UserId = 1 },
               new ProductLike { ProductLikeId = 2, ProductId = 2, UserId = 1 },
               new ProductLike { ProductLikeId = 3, ProductId = 3, UserId = 1 },
               new ProductLike { ProductLikeId = 4, ProductId = 1, UserId = 2 },
               new ProductLike { ProductLikeId = 5, ProductId = 2, UserId = 2 },
               new ProductLike { ProductLikeId = 6, ProductId = 3, UserId = 1 },
               new ProductLike { ProductLikeId = 7, ProductId = 1, UserId = 3 },
               new ProductLike { ProductLikeId = 8, ProductId = 2, UserId = 3 },
               new ProductLike { ProductLikeId = 29, ProductId = 3, UserId = 1 }
            );

            // Seed Category
            context.Templates.AddOrUpdate(
                new Template { TemplateId = 1, ContentInJson = "[{name: 'Color', content: 'Red'}, {name: 'Size', content: '42, 43'}]" });
            context.Templates.AddOrUpdate(
                new Template { TemplateId = 2, ContentInJson = "[{name: 'Material', content: 'Wheat, sugar'}, {name: 'Energy', content: '250kcal'}, {name: 'Package', content: '3 packs'}]" });
            context.Templates.AddOrUpdate(
                new Template { TemplateId = 3, ContentInJson = "[{name: 'Type', content: 'Isopropyl Alcohol'}, {name: 'Percentage', content: '90%'}, {name: 'Color', content: 'Red'}, {name: 'Materials', content: 'Grapes'}, ]" });
            context.Categories.AddOrUpdate(
                new Category { CategoryId = 1, Name = "Root", CoverImageId = 1 },
                new Category { CategoryId = 2, Name = "Men's", CoverImageId = 2, ParentId = 1 },
                new Category { CategoryId = 3, Name = "Women's", CoverImageId = 3, ParentId = 1 },
                new Category { CategoryId = 4, Name = "Shoes", CoverImageId = 4, ParentId = 2, TemplateId = 1 },
                new Category { CategoryId = 5, Name = "Food & Beverages", CoverImageId = 8, ParentId = 1 },
                new Category { CategoryId = 6, Name = "Breads & Cakes", CoverImageId = 9, ParentId = 5, TemplateId = 2 },
                new Category { CategoryId = 7, Name = "Wine & Alcohol", CoverImageId = 10, ParentId = 5, TemplateId = 3 }
            );
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
                },
                new Store
                {
                    StoreId = 2,
                    StoreName = "Drink & Cake Lovers",
                    ContactNumber = "012-462-5934",
                    Description = "A greate place for cake lovers with thousands kinds of cakes.",
                    OwnerId = WebSecurity.GetUserId("shoes_lovers"),
                    ShipFee = 9.99F,
                    StatusId = 2,
                    CoverImageId = 19,
                    Slogan = "Find the best shoes in town here.",
                    ProfileImageId = 1,
                    Address = new Address { AddressId = 2, Number = "123", Street = "Cakes' Street", City = "Saigon", Country = "Vietnam", Zipcode = "70100", State = "" }
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
                    SpecsInJson = @"[{ 'name': 'Color', 'content': 'Dark Blue'}, { 'name': 'Size', 'content': '42, 43, 44'}]",
                    ProductImages = new List<Image> { context.Images.Find(5), context.Images.Find(6), context.Images.Find(7) },
                    StoreId = 1
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Sacramentalia",
                    Description = "A 'How-to' Ward off Evil Spirits package design that comes with nine (really ten) things to help you ward off evil spirits. Most are spices and household ingredients, but the idea is that they are blessed by popes of the past and become something that is 'holy'. Hierarchy is based off the numbered steps than the items/ingredients itself.",
                    CategoryId = 4,
                    Price = 35.7F,
                    StatusId = 2,
                    SpecsInJson = @"[{ 'name': 'Taste', 'content': 'Spicy'}, { 'name': 'Size', 'content': 'S, M, L'}, { 'name': 'Packing', 'content': '3 bottles / pack'}]",
                    ProductImages = new List<Image> { context.Images.Find(15), context.Images.Find(16), context.Images.Find(17) },
                    StoreId = 2,
                    Comments = new List<Comment> { new Comment { CommentId = 1, CommentContent = "Good", CreateDate = DateTime.Now, ProductId = 2, UserId = WebSecurity.GetUserId("shoes_lovers") } }
                },
                new Product
                {
                    ProductId = 3,
                    Name = "KAME Wine",
                    Description = "KAME is the BODEGAS EGURENUGARTE brand for their wines in Tierra de Castilla. KAME is the conjuction of the initial letters of the names of the brothers owners of the winery. This wines are oriented to the modern consumer. The minimalistic and elegant treatment of the K letter shows the spirit of the brand.",
                    CategoryId = 7,
                    Price = 135.99F,
                    StatusId = 2,
                    SpecsInJson = @"[{ 'name': 'Color', 'content': 'Yellow, Red'}, { 'name': 'Percentage', 'content': '70%'}]",
                    ProductImages = new List<Image> { context.Images.Find(11), context.Images.Find(12), context.Images.Find(13) },
                    StoreId = 2,
                    Comments = new List<Comment> { new Comment { CommentId = 2, CommentContent = "Worse", CreateDate = DateTime.Now, ProductId = 2, UserId = WebSecurity.GetUserId("shoes_lovers") } }
                });
        }
    }
}