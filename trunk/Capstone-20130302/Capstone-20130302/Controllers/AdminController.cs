using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_20130302.Constants;
using Capstone_20130302.Models;
using System.Data.Entity.Validation;

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
            var adminOptions = db.ProductStatuses.Where(s => s.StatusId == Constant.STATUS_ACTIVE || s.StatusId == Constant.STATUS_BANNED);
            ViewBag.StatusID = new SelectList(adminOptions, "StatusId", "Name");
            ViewBag.EditorPicks = db.EditorPicks.ToList();
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
                return Constant.ST_OK;
            }
            catch (Exception)
            {
                return Constant.ST_NG;
            }
        }


        [Authorize(Roles = Constant.ROLE_ADMIN)]
        public ActionResult ManageStore()
        {
            var adminOptions = db.StoreStatuses.Where(s => s.StatusId == Constant.STATUS_ACTIVE || s.StatusId == Constant.STATUS_BANNED);
            ViewBag.StatusID = new SelectList(adminOptions, "StatusId", "Name");
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

        [Authorize(Roles = Constant.ROLE_ADMIN)]
        public string AddEditorPick(int productID)
        {
            try
            {
                EditorPick pick = db.EditorPicks.Where(e => e.ProductId == productID).FirstOrDefault();
                if (pick != null)
                {
                    return Constant.ST_OK;
                }
                else
                {
                    pick = new EditorPick();
                    pick.ProductId = productID;

                    db.EditorPicks.Add(pick);
                    db.SaveChanges();
                    return Constant.ST_OK;
                }
            }
            catch (Exception)
            {
                return Constant.ST_NG;
            }
        }

        [Authorize(Roles = Constant.ROLE_ADMIN)]
        public string RemoveEditorPick(int productID, string status)
        {
            try
            {
                EditorPick pick = db.EditorPicks.Where(e => e.ProductId == productID).FirstOrDefault();
                if (pick != null)
                {
                    db.EditorPicks.Remove(pick);
                    db.SaveChanges();
                    return Constant.ST_OK;
                }
                else
                {
                    return Constant.ST_OK;
                }
            }
            catch (Exception)
            {
                return Constant.ST_NG;
            }
        }
    }
}
