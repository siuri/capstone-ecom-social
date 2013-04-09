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
using Capstone_20130302.Constants;

namespace Capstone_20130302.Controllers
{
    public class StoreController : Controller
    {
        private SocialBuyContext db = new SocialBuyContext();

        //
        // GET: /Store/
        [Authorize(Roles = Constant.ROLE_SELLER)]
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

        [Authorize(Roles = Constant.ROLE_SELLER)]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Store/Create
        // createStatus 1: Save status as Inactive
        // createStatus 2: Save status as Active
        [Authorize(Roles = Constant.ROLE_SELLER)]
        [HttpPost]
        public ActionResult Create(Store store, Address address, int createStatus = 0)
        {
            // Check if there are 2 image files from Request 
            if (Request.Files.AllKeys.Length != 2)
            {
                ViewBag.Message("Cover image and/or store avatar needed.");
                return View("Error");
            }

            Guid guid = new Guid();
            var path = "";
            List<Image> images = new List<Image>();
            
            // Read each file from Request, create each corresponding Image object and added to Image list
            for (int i = 0; i < Request.Files.AllKeys.Length; i++)
            {
                HttpPostedFileBase hpf = Request.Files[i] as HttpPostedFileBase;
                if (hpf != null && hpf.ContentLength > 0)
                {
                    guid = Guid.NewGuid();
                    path = Path.Combine(Server.MapPath("~/App_Data/Images"), guid.ToString());
                    hpf.SaveAs(path);
                    images.Add(new Image { Path = guid.ToString() });
                }
            }
            // Set images to Store object
            store.CoverImage = images.First();
            store.ProfileImage = images.Last();

            store.TotalFollowers = 0;
            store.TotalFollowings = 0;
            store.Address = address;
            store.CreateDate = DateTime.Now;

            if (createStatus == 2)
                store.StatusId = Constant.STATUS_ACTIVE;
            else if (createStatus == 1)
                store.StatusId = Constant.STATUS_INACTIVE;

            if (ModelState.IsValid)
            {
                db.Stores.Add(store);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(store);
        }

        //
        // GET: /Store/Edit/5
        [Authorize(Roles = Constant.ROLE_SELLER)]
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
        [Authorize(Roles = Constant.ROLE_SELLER)]
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
        [Authorize(Roles = Constant.ROLE_SELLER)]
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
        [Authorize(Roles = Constant.ROLE_SELLER)]
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