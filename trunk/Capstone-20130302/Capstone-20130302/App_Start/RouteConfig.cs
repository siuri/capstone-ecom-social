using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Capstone_20130302
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "StoreRoute",
                url: "Store/Id/{id}",
                defaults: new { controller = "Store", action = "Details", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ProductRoute",
                url: "Product/Id/{id}",
                defaults: new { controller = "Product", action = "Details", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "UserRoute",
                url: "User/Id/{id}",
                defaults: new { controller = "User", action = "Details", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ImageRoute",
                url: "Image/{id}",
                defaults: new { controller = "Image", action = "Details", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}