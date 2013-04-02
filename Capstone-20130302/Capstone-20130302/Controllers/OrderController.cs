using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_20130302.Constants;
using Capstone_20130302.Logic;
using Capstone_20130302.Models;

namespace Capstone_20130302.Controllers
{
    public class OrderController : Controller
    {
        private SocialBuyContext db = new SocialBuyContext();

        //
        // GET: /Order/

        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        //
        // GET: /Order/Details/5

        public ActionResult Details(int id = 0)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }
        
        [Authorize(Roles = Constant.ROLE_SELLER)]
        public ActionResult SellerManage()
        {
            var userid = (from _user in db.UserProfiles
                          where _user.UserName == User.Identity.Name
                          select _user.UserId).FirstOrDefault();
            UserProfile user = db.UserProfiles.Find(userid);
            if (user == null)
            {
                return HttpNotFound();
            }
            List<Order> list = Order_Logic.GetListByUserID(userid,1);
            return View(list);
        }

        [Authorize]
        public ActionResult UserManage()
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login", "Account");
            }
            var userid = (from _user in db.UserProfiles
                          where _user.UserName == User.Identity.Name
                          select _user.UserId).FirstOrDefault();
            UserProfile user = db.UserProfiles.Find(userid);
            if (user == null)
            {
                return HttpNotFound();
            }
            List<Order> list = Order_Logic.GetListByUserID(userid, 0);
            return View(list);
        }
        
        //
        // GET: /Order/Checkout

        public ActionResult Checkout()
        {
            return View();
        }

        //
        // POST: /Order/Checkout

        [HttpPost]
        public ActionResult Checkout(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        //
        // GET: /Order/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //
        // POST: /Order/Edit/5

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        //
        // GET: /Order/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //
        // POST: /Order/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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