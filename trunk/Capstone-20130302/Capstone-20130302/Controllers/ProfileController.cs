using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_20130302.Models;
using System.Data.Entity.Validation;
using System.Text;
using System.IO;
using WebMatrix.WebData;
using Capstone_20130302.Logic;
using System.Web.Security;
using Capstone_20130302.Constants;

namespace Capstone_20130302.Controllers
{
    public class ProfileController : Controller
    {
        private SocialBuyContext db = new SocialBuyContext();

        //
        // GET: /Profile/

        public ActionResult Index()
        {
            return View(db.Profiles.ToList());
        }

        //
        // GET: /Profile/Details/5

        public ActionResult Details(int id = 0)
        {
            UserProfile user = db.UserProfiles.Find(id);
            if (user == null)
            {
                ViewBag.Message = "User not found.";
                return View("Error");
            }
            Profile profile = user.Profile;
            if (profile == null)
            {
                return HttpNotFound();
            }
            // Get List Follow 
            List<UserProfile> listfollow = Follow_Logic.GetFollowingUsersOfType(2, id,5);
            ViewBag.listfollow = listfollow;

            ViewBag._user = user;
            // Get list store follow
            List<Store> liststore = Account_Logic.GetListStoreFollowByUser(id);
            ViewBag.liststore = liststore;

            // Get list product like
            List<Product> listpro = Account_Logic.GetListProductLikeByUser(id);
            ViewBag.listpro = listpro;
            return View(profile);
        }



        public ActionResult GetUserFollow(int ID)
        {
            if (User.Identity.IsAuthenticated != false)
            {
                UserProfile user = UserProfiles_Logic.GetUserProfileByUserName(User.Identity.Name);
                return Json(Follow_Logic.CheckFollowForUser(user.UserId,ID,2), JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AddUserFollow(int ID)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return Json("You must login to Like", JsonRequestBehavior.AllowGet);
            }
            Follow temp = new Follow();
            temp.UserId = WebSecurity.CurrentUserId;
            temp.FollowedUserId = ID;
            if(Follow_Logic.AddNewFollow(temp))
            {
                // Publish Message
                Message_Logic.PublishMessage(WebSecurity.CurrentUserId, Constant.PRONOUN_TYPE_USER, ID, Constant.PRONOUN_TYPE_USER, Constant.MESSAGE_TYPE_FOLLOW);
                return Json("true", JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteUserFollow(int ID)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return Json("You must login to Like", JsonRequestBehavior.AllowGet);
            }
            UserProfile user = UserProfiles_Logic.GetUserProfileByUserName(User.Identity.Name);
            if (Follow_Logic.DeletFollow(user.UserId, ID, 2))
            {
                return Json("true", JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);


        }


        //
        // GET: /Profile/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Profile/Create

        [HttpPost]
        public ActionResult Create(Profile profile, Address address, HttpPostedFileBase file)
        {
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                Guid guid = Guid.NewGuid();
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/App_Data/Images"), guid.ToString());
                file.SaveAs(path);
                Image image = new Image { Path = guid.ToString() };
                db.Images.Add(image);

                if (ModelState.IsValid)
                {
                    profile.Address = address;
                    profile.ProfileImage = image;
                    db.Profiles.Add(profile);
                    db.SaveChanges();

                    // Update profileid for Account
                    var userid = (from _user in db.UserProfiles
                                  where _user.UserName == User.Identity.Name
                                  select _user.UserId).FirstOrDefault();
                    UserProfile user = db.UserProfiles.Find(userid);
                    user.Profile = profile;
                    db.SaveChanges();
                    return RedirectToAction("Follow","Category");
                }
            }
            

            return View(profile);
        }

        //
        // GET: /Profile/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (id < 0)
            {
                ViewBag.Message = "Sorry, profileid not found";
                return View("Error");
            }

            if (User.Identity.IsAuthenticated == false)
            {
                ViewBag.Message = "Sorry, you must login ";
                return View("Error");
            }
            UserProfile user = UserProfiles_Logic.GetUserProfileByUserName(User.Identity.Name);
            string []roles = Roles.GetRolesForUser(User.Identity.Name);
            if (roles[0] == Constant.ROLE_ADMIN)
            {
                Profile profile = db.Profiles.Find(id);
                profile.DateOfBirth = profile.DateOfBirth.Date;
                if (profile == null)
                {
                    return HttpNotFound();
                }
                return View(profile);
            }
            else
            {
                if (user.ProfileId != id)
                {
                    ViewBag.Message = "Sorry, profileid not found";
                    return View("Error");
                }
                Profile profile = db.Profiles.Find(id);
                profile.DateOfBirth = profile.DateOfBirth.Date;
                if (profile == null)
                {
                    return HttpNotFound();
                }
                return View(profile);
            }
           
        }

        //
        // POST: /Profile/Edit/5

        [HttpPost]
        public ActionResult Edit(Profile profile, Address address, HttpPostedFileBase file, string changeimage)
        {
            // Verify that the user selected a file
            
                    

                if (ModelState.IsValid)
                {
                    profile.Address = address;
                    Profile temp = db.Profiles.Find(profile.ProfileId);
                    temp.DisplayName = profile.DisplayName;
                    temp.Email = profile.Email;
                    temp.DateOfBirth = profile.DateOfBirth;
                    temp.ContactNumber = profile.ContactNumber;
                    temp.Address = address;
                    if(changeimage == "true")
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            Guid guid = Guid.NewGuid();
                            // store the file inside ~/App_Data/uploads folder
                            var path = Path.Combine(Server.MapPath("~/App_Data/Images"), guid.ToString());
                            file.SaveAs(path);
                            Image image = new Image { Path = guid.ToString() };
                            db.Images.Add(image);
                            temp.ProfileImage.Path = image.Path;
                        }
                       
                    }
                    db.SaveChanges();
                    return View(temp);
                }
            
            
            return View(profile);
        }

        //
        // GET: /Profile/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        //
        // POST: /Profile/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Profile profile = db.Profiles.Find(id);
            db.Profiles.Remove(profile);
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