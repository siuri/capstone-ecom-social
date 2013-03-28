using Capstone_20130302.Constants;
using Capstone_20130302.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Capstone_20130302.Controllers
{
    public class ManageController : Controller
    {
        private SocialBuyContext db = new SocialBuyContext();

        
        
        //
        // GET: /Manage/
        // Return seller's store
        [Authorize(Roles = Constant.ROLE_SELLER)]
        public ActionResult Index()
        {
            return View(db.Stores.Where(s => s.OwnerId == WebSecurity.CurrentUserId).ToList());
        }

        public ActionResult Dashboard(int sid)
        {
            
            if (sid == -1)
            {
                ViewBag.Message = "Please define your Store.";
                return View("Error");
            }
            else
            {
                var store = db.Stores.Find(sid);
                if (store != null && store.OwnerId == WebSecurity.CurrentUserId)
                {
                    ViewBag.Store = store;
                }
                else
                {
                    ViewBag.Message = "Sorry, we can't find the store or you're not the owner.";
                    return View("Error");
                }
            }
            
            return View();
        }

        //
        // GET: /Manage/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Manage/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Manage/Create

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
        // GET: /Manage/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Manage/Edit/5

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
        // GET: /Manage/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Manage/Delete/5

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
