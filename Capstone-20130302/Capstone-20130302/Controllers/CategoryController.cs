using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_20130302.Models;
using WebMatrix.WebData;
using Capstone_20130302.Logic;
using System.Data.Entity.Validation;
using System.Text;
using System.IO;
using Capstone_20130302.Constants;

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

        public ActionResult DropDown()
        {
            return Json(Category_Logic.CateroryCombobox(), JsonRequestBehavior.AllowGet);
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
        [Authorize(Roles = Constant.ROLE_ADMIN)]
        public ActionResult Create()
        {
            ViewBag.Parent = new SelectList(db.Categories.Where(c => c.ParentId == 1).ToList(), "CategoryId", "Name");

            //List<Category> categorylist = new List<Category>();
            //categorylist.AddRange((from Category cate in db.Categories
            //                       where cate.ParentId == 1
            //                       select cate).ToList());

            //ViewBag.categorylist = categorylist;

            return View();
        }



        //
        // POST: /Category/Create
        [Authorize(Roles = Constant.ROLE_ADMIN)]
        [HttpPost]
        public ActionResult Create(Category category)
        {
            Guid guid = new Guid();
            var path = "";
            HttpPostedFileBase hpf = Request.Files[0] as HttpPostedFileBase;
            if (hpf != null && hpf.ContentLength > 0)
            {
                guid = Guid.NewGuid();
                path = Path.Combine(Server.MapPath("~/App_Data/Images"), guid.ToString());
                hpf.SaveAs(path);
                Image image = new Image { Path = guid.ToString() };

                category.CoverImage = image;
            }
            if (category.ParentId == null)
            {
                category.ParentId = 1;
            }
            try
            {
                if (ModelState.IsValid)
                {
                    db.Categories.Add(category);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(category);
        }

        //
        // GET: /Category/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Category category = db.Categories.Find(id);
            ViewBag.Parent = new SelectList(db.Categories.Where(c => c.ParentId == 1).ToList(), "CategoryId", "Name");
            //Category d = new Category();
            //d.SpecsInJson = category.Template.ContentInJson;
            //return View(d);

            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // POST: /Category/Edit/5

        [Authorize(Roles = Constant.ROLE_ADMIN)]
        [HttpPost]
        public ActionResult Edit(Category category, string changeimage)
        {
            //Template temp = new Template();
            //temp = SpecsInJson;
            //category.Template = temp;
            if (category.ParentId == null)
            {
                category.ParentId = 1;
            }
            Guid guid = new Guid();
            var path = "";
            HttpPostedFileBase hpf = Request.Files[0] as HttpPostedFileBase;
            if (hpf != null && hpf.ContentLength > 0)
            {
                guid = Guid.NewGuid();
                path = Path.Combine(Server.MapPath("~/App_Data/Images"), guid.ToString());
                hpf.SaveAs(path);
                Image image = new Image { Path = guid.ToString() };
                category.CoverImage = image;
            }
            ViewBag.Parent = new SelectList(db.Categories.Where(c => c.ParentId == 1).ToList(), "CategoryId", "Name");
            if (ModelState.IsValid)
            {
                try
                {
                    Category temp = db.Categories.Find(category.CategoryId);
                    temp.Name = category.Name;
                    temp.ParentId = category.ParentId;
                    temp.Template.ContentInJson = category.Template.ContentInJson
;
                    if (changeimage == "true")
                    {
                        temp.CoverImage = category.CoverImage;
                    }
                    db.SaveChanges();
                    return View(temp);
                }
                catch (DbEntityValidationException ex)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (var failure in ex.EntityValidationErrors)
                    {
                        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                        foreach (var error in failure.ValidationErrors)
                        {
                            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                            sb.AppendLine();
                        }
                    }

                    throw new DbEntityValidationException(
                        "Entity Validation Failed - errors follow:\n" +
                        sb.ToString(), ex
                    ); // Add the original exception as the innerException
                }

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