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
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
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
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        //
        // POST: /Profile/Edit/5

        [HttpPost]
        public ActionResult Edit(Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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