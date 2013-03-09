namespace Capstone_20130302.Migrations
{
    using System;
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

            if (!Roles.GetRolesForUser("admin001").Contains("admin"))
                Roles.AddUsersToRoles(new[] { "admin001" }, new[] { "admin" });

            context.OrderStatuses.AddOrUpdate(
                new OrderStatus { Name = "Pending", Description = "The order is waiting for process." },
                new OrderStatus { Name = "Ready", Description = "The order is ready for shipping." },
                new OrderStatus { Name = "Shipped", Description = "The order is shipped." },
                new OrderStatus { Name = "Cancelled", Description = "The order is cancelled." },
                new OrderStatus { Name = "Hold", Description = "The order is on hold." });
            context.ProductStatuses.AddOrUpdate(
                new ProductStatus { Name = "Pending", Description = "The product is waiting for administrator's approval." },
                new ProductStatus { Name = "Active", Description = "The product is currently active and public." },
                new ProductStatus { Name = "Inactive", Description = "The product is currently inactive." },
                new ProductStatus { Name = "Rejected", Description = "The product is rejected and need modification." },
                new ProductStatus { Name = "Banned", Description = "The product is banned due to violation." });
            context.StoreStatuses.AddOrUpdate(
                new StoreStatus { Name = "Pending", Description = "The store is waiting for administrator's approval." },
                new StoreStatus { Name = "Active", Description = "The store is currently active and public." },
                new StoreStatus { Name = "Inactive", Description = "The store is currently inactive." },
                new StoreStatus { Name = "Rejected", Description = "The store is rejected and need modification." },
                new StoreStatus { Name = "Banned", Description = "The store is banned due to violation." });
            context.Images.AddOrUpdate(
                new Image { ImageId = 0, Path = "no_img.jpg" },
                new Image { ImageId = 1, Path = "mens.jpg" },
                new Image { ImageId = 2, Path = "womens.jpg" },
                new Image { ImageId = 3, Path = "men_shoes.jpg"}
            );
            context.Categories.AddOrUpdate(
                new Category { CategoryId = 0, Name = "Root", CoverImage = context.Images.Find(0) },
                new Category { CategoryId = 1, Name = "Men's", CoverImage = context.Images.Find(1), Parent = context.Categories.Find(0) },
                new Category { CategoryId = 2, Name = "Women's", CoverImage = context.Images.Find(2), Parent = context.Categories.Find(0) },
                new Category { CategoryId = 3, Name = "Shoes", CoverImage = context.Images.Find(3), Parent = context.Categories.Find(1)});
            context.SaveChanges();
        }
    }
}
