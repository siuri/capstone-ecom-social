﻿using System;
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
            ViewBag.EditorPicks = db.EditorPicks.ToList();
            var products = db.Products.ToList();
            return View(products);
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
