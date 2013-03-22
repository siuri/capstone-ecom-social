using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_20130302.Models;
using WebMatrix.WebData;

namespace Capstone_20130302.Controllers
{
    public class CategoryController : Controller
    {
        private SocialBuyContext db = new SocialBuyContext();

        //
        // GET: /Category/Follow
        // Load Follow page

        public ActionResult Follow()
        {
            // Get categories list 
            var cates = from c in db.Categories
                        where c.ParentId == 1
                        select c;
            List<Category> parentCategories = cates.ToList();

            return View(parentCategories);
        }


        //
        // GET: /Category/Follow
        // Submit Follow page

        [HttpPost]
        public ActionResult Follow(List<Category> categories) // TODO: Pass a collection of Category from user's selection to controller
        {
            if (ModelState.IsValid)
            {
                //  Get current user
                UserProfile user = db.UserProfiles.Find(WebSecurity.CurrentUserId);
                //  Iterate Category list and add to User
                Follow follow = null;
                foreach (var category in categories)
                {
                    follow = new Follow { User = user, Category = category };
                    db.Follows.Add(follow);
                }
                db.SaveChanges();
                return RedirectToAction("Index"); // TODO: redirect to home
            }
            return View(categories);
        }

        //
        // GET: /Category/

        public ActionResult Index()
        {
            var cates = from c in db.Categories
                    where c.ParentId == 1
                    select c;
            return View(cates.ToList());
        }

        //
        // GET: /Category/Details/5

        public ActionResult Details(int id = 0)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        //
        // GET: /Category/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        //
        // GET: /Category/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // POST: /Category/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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