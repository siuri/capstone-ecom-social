﻿using System;
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
using WebMatrix.WebData;
using System.Data.Entity.Validation;

namespace Capstone_20130302.Controllers
{
    public class StoreController : Controller
    {

        [Authorize(Roles = Constant.ROLE_SELLER)]
        public string UpdateStoreStatus(int storeID, string status)
        {
            Store store = db.Stores.Where(s => s.StoreId == storeID).FirstOrDefault();
            try
            {
                store.StatusId = db.StoreStatuses.Where(s => s.Name.Trim().ToLower().Equals(status.Trim().ToLower())).FirstOrDefault().StatusId;
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();
                return Constant.ST_OK;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception)
            {
                return Constant.ST_NG;
            }
        }
        private SocialBuyContext db = new SocialBuyContext();

        //
        // GET: /Store/
        [Authorize(Roles = Constant.ROLE_SELLER)]
        public ActionResult Index()
        {
            var sellerop = db.StoreStatuses.Where(s => s.StatusId == Constant.STATUS_ACTIVE || s.StatusId == Constant.STATUS_INACTIVE);
            ViewBag.StatusID = new SelectList(sellerop, "StatusId", "Name");
            List<Store> store = db.Stores.Where(s => s.OwnerId == WebSecurity.CurrentUserId).ToList();
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
            if (store.StatusId == Constant.STATUS_BANNED || store.StatusId == Constant.STATUS_INACTIVE)
            {
                ViewBag.Message = "Sorry, this store is not available.";
                return View("Error");
            }
            if (store.StatusId == Constant.STATUS_PENDING)
            {
                ViewBag.Message = "Sorry, this store is waiting arropve by admin";
                return View("Error");
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
            listprofile = Follow_Logic.GetFollowingUsersOfType(3, id,5);
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
                Store store = db.Stores.Find(ID);
                ++store.TotalFollowers;
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();

                // Publish Message
                Message_Logic.PublishMessage(WebSecurity.CurrentUserId, Constant.PRONOUN_TYPE_USER, ID, Constant.PRONOUN_TYPE_STORE, Constant.MESSAGE_TYPE_FOLLOW);
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
                Store store = db.Stores.Find(ID);
                --store.TotalFollowers;
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();

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
            Image img = null;
            // Read each file from Request, create each corresponding Image object and added to Image list
            for (int i = 0; i < Request.Files.AllKeys.Length; i++)
            {
                HttpPostedFileBase hpf = Request.Files[i] as HttpPostedFileBase;
                if (hpf != null && hpf.ContentLength > 0)
                {
                    guid = Guid.NewGuid();
                    path = Path.Combine(Server.MapPath("~/App_Data/Images"), guid.ToString());
                    hpf.SaveAs(path);
                    img = new Image { Path = guid.ToString() };
                    images.Add(img);
                }
            }
            db.SaveChanges();
            
            if (createStatus == 2)
                store.StatusId = Constant.STATUS_PENDING;
            else if (createStatus == 1)
                store.StatusId = Constant.STATUS_INACTIVE;

            if (ModelState.IsValid)
            {
                // Set images to Store object
                store.CoverImage = images.First();
                store.ProfileImage = images.Last();

                store.TotalFollowers = 0;
                store.TotalFollowings = 0;
                store.Address = address;
                store.CreateDate = DateTime.Now;
                store.OwnerId = WebSecurity.CurrentUserId;

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
        public ActionResult Edit(Store store, Address address, string editcoverimage, string editprofileimage,int createStatus = 0)
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
           
            store.Address = address;
         
            if (ModelState.IsValid)
            {
                Store temp = db.Stores.Find(store.StoreId);
                temp.Slogan = store.Slogan;
                temp.StoreName = store.StoreName;
                temp.Description = store.Description;
                temp.ShipFee = store.ShipFee;
                temp.Address = address;
                if (editcoverimage == "true")
                {
                    temp.CoverImage.Path = images.First().Path;
                }
                if (editprofileimage == "true")
                {
                    temp.ProfileImage.Path = images.Last().Path;
                }
                db.SaveChanges();
                return View(temp);
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