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
                if (order.Stores != null && order.Stores.OwnerId != WebSecurity.CurrentUserId && order.UserId != WebSecurity.CurrentUserId)
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

        public ActionResult GetNameStatusByID(int ID)
        {
            return Json(OrderStatus_Logic.GetNameOrderStatusByID(ID), JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateOrderStatus(int ID,int StatusID)
        {
            return Json(Order_Logic.UpdateStatusOrder(ID,StatusID), JsonRequestBehavior.AllowGet);
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
            var userid = (from _user in db.UserProfiles
                          where _user.UserName == User.Identity.Name
                          select _user.UserId).FirstOrDefault();
            UserProfile user = db.UserProfiles.Find(userid);
            if (user == null)
            {
                return HttpNotFound();
            }
            List<Order> list = Order_Logic.GetListByUserID(userid, 2);
            return View(list);
        }
        
        //
        // GET: /Order/Checkout
        [Authorize]
        public ActionResult Checkout(int sid = 0)
        {
            if (sid <= 0)
            {
                ViewBag.Message = "Sorry, store identifier are missing. Please try again.";
                return View("Error");
            }
            Store store = db.Stores.Find(sid);
            Order order = new Order();
            Profile profile = db.UserProfiles.Find(WebSecurity.CurrentUserId).Profile;
            if (profile.Address != null)
            {
                order.BillingAddress = profile.Address;
                order.BillingName = profile.DisplayName;
            }
            order.Stores = store;
            order.IsUsedAsShipping = true;
            order.StatusId = Constant.ORDER_STATUS_PENDING;
            order.UserId = WebSecurity.CurrentUserId;
            order.StoreId = sid;
            return View(order);
        }

        //
        // POST: /Order/Checkout

        [HttpPost]
        [Authorize]
        public ActionResult Checkout(Order order, Address BillingAddress, Address ShippingAddress, String cartdata)
        {
            if (cartdata == null || cartdata.Length == 0)
            {
                ViewBag.Message = "You must have at least one item to checkout.";
                return View("Error");
            }
            order.Stores = null;
            order.BillingAddress = BillingAddress;
            if (order.IsUsedAsShipping == false)
                order.ShippingAddress = ShippingAddress;
            string[] itemsArray = cartdata.Split(',');
            List<ProductOrder> cartList = new List<ProductOrder>();
            ProductOrder orderItem = null;
            foreach (var item in itemsArray)
            {
                string[] itemDict = item.Split(':');
                orderItem = new ProductOrder();
                orderItem.ProductId = Int32.Parse(itemDict[0]);
                orderItem.Quantity = Int32.Parse(itemDict[1]);
                cartList.Add(orderItem);
            }
            
            order.OrderDate = DateTime.Now;

            Order_Logic.AddOrder(order, cartList);

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