using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_20130302.Logic;
using Capstone_20130302.Models;
using System.IO;

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
            if (User.Identity.IsAuthenticated != false)
            {
                UserProfile user = UserProfiles_Logic.GetUserProfileByUserName(User.Identity.Name);
                ViewBag.detailuser = user;
            }
            else
            {
                ViewBag.detailuser = null;
            }
            List<UserProfile> listprofile = new List<UserProfile>();
            listprofile = Follow_Logic.GetListFollow(3, id,5);
            ViewBag.listprofile = listprofile;
            return View(store);
        }

        //
        // GET: /Store/Create


        public ActionResult GetStoreFollow(int ID)
        {
            if (User.Identity.IsAuthenticated != false)
            {
                UserProfile user = UserProfiles_Logic.GetUserProfileByUserName(User.Identity.Name);
                return Json(Follow_Logic.CheckFollowForUser(user.UserId,ID,3), JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AddStoreFollow(int ID)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return Json("You must login to Follow", JsonRequestBehavior.AllowGet);
            }
            UserProfile user = UserProfiles_Logic.GetUserProfileByUserName(User.Identity.Name);
            Follow temp = new Follow();
            temp.UserId = user.UserId;
            temp.StoreId = ID;
            if(Follow_Logic.AddNewFollow(temp))
            {
                return Json("true", JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteStoreFollow(int ID)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return Json("You must login to Follow", JsonRequestBehavior.AllowGet);
            }
            UserProfile user = UserProfiles_Logic.GetUserProfileByUserName(User.Identity.Name);
            if (Follow_Logic.DeletFollow(user.UserId, ID, 3))
            {
                return Json("true", JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);

        }
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Store/Create

        [HttpPost]
        public ActionResult Create(Store store, Address address)
        {
            Guid guid = new Guid();
            var path = "";
            for (int i = 0; i < Request.Files.AllKeys.Length; i++)
            {
                HttpPostedFileBase hpf = Request.Files[i] as HttpPostedFileBase;
                if (hpf != null && hpf.ContentLength > 0)
                {
                    guid = Guid.NewGuid();
                    path = Path.Combine(Server.MapPath("~/App_Data/Images"), guid.ToString());
                    hpf.SaveAs(path);
                    Image image = new Image { Path = guid.ToString() };
                }
            }
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