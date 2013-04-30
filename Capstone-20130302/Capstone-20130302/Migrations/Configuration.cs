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
    using Capstone_20130302.Constants;

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

            context.MessageTypes.AddOrUpdate(
                new MessageType { MessageTypeId = Constant.MESSAGE_TYPE_FOLLOW, MessageTypeName = "Follow", Content = " follows " },
                new MessageType { MessageTypeId = Constant.MESSAGE_TYPE_LIKE, MessageTypeName = "Like", Content = " likes " },
                new MessageType { MessageTypeId = Constant.MESSAGE_TYPE_COMMENT, MessageTypeName = "Comment", Content = " commented on " },
                new MessageType { MessageTypeId = Constant.MESSAGE_TYPE_ORDER, MessageTypeName = "Order", Content = " ordered " },
                new MessageType { MessageTypeId = Constant.MESSAGE_TYPE_NEW_PRODUCT, MessageTypeName = "New Product", Content = " introduces " }
            );

            context.PronounsTypes.AddOrUpdate(
                new PronounsType { PronounsTypeId = Constant.PRONOUN_TYPE_USER, PronounsTypeName = "USER" },
                new PronounsType { PronounsTypeId = Constant.PRONOUN_TYPE_CATEGORY, PronounsTypeName = "CATEGORY" },
                new PronounsType { PronounsTypeId = Constant.PRONOUN_TYPE_STORE, PronounsTypeName = "STORE" },
                new PronounsType { PronounsTypeId = Constant.PRONOUN_TYPE_PRODUCT, PronounsTypeName = "PRODUCT" }
            );
        }
    }
}