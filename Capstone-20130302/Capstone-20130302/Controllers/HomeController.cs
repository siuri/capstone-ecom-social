using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_20130302.Models;
using WebMatrix.WebData;

namespace Capstone_20130302.Controllers
{
    public class HomeController : Controller
    {
        public SocialBuyContext db = new SocialBuyContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            if (Request.IsAuthenticated)
            {
                var stores = from s in db.Stores
                             where s.Owner.UserId == WebSecurity.CurrentUserId
                             select s;
                ViewBag.Message = stores.ElementAt(0).Description;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Step2()
        {
            ViewBag.Message = "Step 2: Complete your profile";
            return View();
        }
    }
}
