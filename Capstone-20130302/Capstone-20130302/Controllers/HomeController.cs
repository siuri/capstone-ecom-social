using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_20130302.Constants;
using Capstone_20130302.Logic;
using Capstone_20130302.Models;
using WebMatrix.WebData;

namespace Capstone_20130302.Controllers
{
    public class HomeController : Controller
    {
        public SocialBuyContext db = new SocialBuyContext();

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                UserProfile user = UserProfiles_Logic.GetUserProfileByUserName(User.Identity.Name);
                ViewBag.totalrow = Product_Logic.GetTotalRowListProductCateforyFollow(user.UserId);
                ViewBag.listpro = Product_Logic.GetListProductCateforyFollow(user.UserId, 1, Constant.PAGE_SIZE);
            }
            else
            {
                ViewBag.totalrow = 0;
                ViewBag.listpro = null;
            }
            ViewBag.EditorPicks = db.EditorPicks.ToList();
            var products = db.Products.ToList();
            return View(products);
        }
        public ActionResult GetProductPage(int page)
        {
            if (User.Identity.IsAuthenticated)
            {
                UserProfile user = UserProfiles_Logic.GetUserProfileByUserName(User.Identity.Name);
                List<ProductDisplay> list = Product_Logic.GetListProductCateforyFollow(user.UserId, page, Constant.PAGE_SIZE);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null);
            }
           
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
