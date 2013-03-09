using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_20130302.Models;

namespace Capstone_20130302.Controllers
{
    public class FollowController : Controller
    {
        private SocialBuyContext db = new SocialBuyContext();

        //
        // GET: /Follow/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FollowCategories()
        {
            return View(db.Categories.ToList());
        }

        //
        // GET: /Follow/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Follow/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Follow/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Follow/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Follow/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Follow/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Follow/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
