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
using WebMatrix.WebData;

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
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            if (User.IsInRole(Constant.ROLE_SELLER))
            {
                if (order.Stores != null && order.Stores.OwnerId != WebSecurity.CurrentUserId)
                {
                    ViewBag.Message = "Sorry, you can only access orders of the stores that you are owning.";
                    return View("Error");
                }
            }
            else
            {
                if (order.Stores != null && order.UserId != WebSecurity.CurrentUserId)
                {
                    ViewBag.Message = "Sorry, have not right to access orders other than yours.";
                    return View("Error");
                }
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
        [Authorize]
        public ActionResult Checkout(int sid = 0)
        {
            if (sid <= 0)
            {
                ViewBag.Message = "Sorry, some parameters are missing.";
                return View("Error");
            }
            Order order = new Order();
            order.StatusId = Constant.ORDER_STATUS_PENDING;
            order.UserId = WebSecurity.CurrentUserId;
            order.StoreId = sid;
            return View(order);
        }

        //
        // POST: /Order/Checkout

        [HttpPost]
        [Authorize]
        public ActionResult Checkout(Order order, String cartdata)
        {
            order.OrderDate = DateTime.Now;
            
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