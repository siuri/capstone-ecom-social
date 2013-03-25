using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_20130302.Models;

namespace Capstone_20130302.Controllers
{
    public class StoreController : Controller
    {
        private SocialBuyContext db = new SocialBuyContext();

        //
        // GET: /Store/
        
        public ActionResult Index()
        {
            
            List<Store> store = db.Stores.ToList();
            return View(store);       
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(int id = 0)
        {
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        //
        // GET: /Store/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Store/Create

        [HttpPost]
        public ActionResult Create(Store store)
        {
            if (ModelState.IsValid)
            {
                store.StatusId = 1;
                store.TotalFollowers = 0;
                store.TotalFollowings = 0;
                store.CreateDate = DateTime.Now;
                db.Stores.Add(store);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(store);
        }

        //
        // GET: /Store/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        //
        // POST: /Store/Edit/5

        [HttpPost]
        public ActionResult Edit(Store store)
        {
            if (ModelState.IsValid)
            {
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(store);
        }

        //
        // GET: /Store/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        //
        // POST: /Store/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Store store = db.Stores.Find(id);
            db.Stores.Remove(store);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}