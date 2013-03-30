using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_20130302.Constants;
using Capstone_20130302.Models;

namespace Capstone_20130302.Controllers
{
    public class AdminController : Controller
    {
        private SocialBuyContext db = new SocialBuyContext();

        //
        // GET: /Admin/
        [Authorize(Roles = Constant.ROLE_ADMIN)]
        public ActionResult ManageProduct()
        {
            ViewBag.StatusID = new SelectList(db.ProductStatuses, "StatusId", "Name");
            return View(db.Products.ToList());
            //return View(db.Products.ToList().Where(p => p.StatusId == 1));
        }

        [Authorize(Roles = Constant.ROLE_ADMIN)]
        public string UpdateProductStatus(int productID, string status)
        {
            Product product = db.Products.Where(p => p.ProductId == productID).FirstOrDefault();
            try
            {
                product.StatusId = db.ProductStatuses.Where(s => s.Name.Trim().ToLower().Equals(status.Trim().ToLower())).FirstOrDefault().StatusId;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return "OK";
            }
            catch (Exception)
            {
                return "Fail";
            }
        }


        [Authorize(Roles = Constant.ROLE_ADMIN)]
        public ActionResult ManageStore()
        {
            ViewBag.StatusID = new SelectList(db.StoreStatuses, "StatusId", "Name");
            return View(db.Stores.ToList());
            //return View(db.Products.ToList().Where(p => p.StatusId == 1));
        }

        [Authorize(Roles = Constant.ROLE_ADMIN)]
        public string UpdateStoreStatus(int storeID, string status)
        {
            Store store = db.Stores.Where(s => s.StoreId == storeID).FirstOrDefault();
            try
            {
                store.StatusId = db.StoreStatuses.Where(s => s.Name.Trim().ToLower().Equals(status.Trim().ToLower())).FirstOrDefault().StatusId;
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();
                return "OK";
            }
            catch (Exception)
            {
                return "Fail";
            }
        }
    }
}
