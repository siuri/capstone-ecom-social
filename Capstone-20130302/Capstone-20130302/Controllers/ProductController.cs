using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_20130302.Models;
using System.IO;
using System.Data.Entity.Validation;
using System.Text;
using Capstone_20130302.Logic;
using Capstone_20130302.Constants;
using WebMatrix.WebData;

namespace Capstone_20130302.Controllers
{
    public class ProductController : Controller
    {
        private SocialBuyContext db = new SocialBuyContext();

        //
        // GET: /Product/
        [Authorize(Roles = Constant.ROLE_SELLER)]
        public ActionResult Index(int sid = 0)
        {
            if (sid <= 0)
            {
                ViewBag.Message = "Sorry, you must provide a valid Store Id.";
                return View("Error");
            }
            else
            {
                Store store = db.Stores.Find(sid);
                if (store != null && store.OwnerId == WebSecurity.CurrentUserId)
                {
                    ViewBag.sid = sid;
                    return View(db.Products.Where(p => p.StoreId == sid).ToList());
                }
                else
                {
                    ViewBag.Message = "Sorry, we can't find the store or you're not the owner.";
                    return View("Error");
                }

            }
            
        }

        //
        // GET:/ Product/Search
        public ActionResult Search(string searchString)
        {            
            var products = db.Products.Where(p => p.Name.ToUpper().Contains(searchString.ToUpper()));

            return View(products.ToList());
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int id = 0)
        {

            Product product = db.Products.Find(id);
            if (product == null)
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

            // List product recommend
            List<Product> listrecommend = Product_Logic.GetListProdcutRecommend(id, 10);
            ViewBag.listrecommend = listrecommend;
            // List user like product
            List<UserProfile> listlike = Product_Logic.GetListUserProfileRandom(1, id, 5);
            ViewBag.listlike = listlike;
            // List user buy product
            List<UserProfile> listbuy = Product_Logic.GetListUserProfileRandom(2, id, 5);
            ViewBag.listbuy = listbuy;
            // List comment product
            List<Comment> listcmt = Comment_Logic.GetListCommentByProductID(id);
            ViewBag.listcmt = listcmt;
            return View(product);
        }

  
        public ActionResult GetProductLike(int ID)
        {
            if (User.Identity.IsAuthenticated != false)
            {
                UserProfile user = UserProfiles_Logic.GetUserProfileByUserName(User.Identity.Name);
                return Json(ProductLike_Logic.CheckLikeProductUserID(ID, user.UserId), JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
           
        }

        public ActionResult AddProductLike(int ID)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return Json("You must login to Like", JsonRequestBehavior.AllowGet);
            }
            UserProfile user = UserProfiles_Logic.GetUserProfileByUserName(User.Identity.Name);
            if (ProductLike_Logic.AddProductLike(ID, user.UserId))
            {
                return Json("true", JsonRequestBehavior.AllowGet);
            }
            return Json("Error", JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteProductLike(int ID)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return Json("You must login to Like", JsonRequestBehavior.AllowGet);
            }
            UserProfile user = UserProfiles_Logic.GetUserProfileByUserName(User.Identity.Name);
            return Json(ProductLike_Logic.DeleteProductLike(ID, user.UserId).ToString(), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult PostComment(Comment cmt)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return Json("You must login to comment");
            }
            cmt.CreateDate = DateTime.Now;
            cmt.UserId = UserProfiles_Logic.GetUserProfileByUserName(User.Identity.Name).UserId;
            if (Comment_Logic.AddNewComment(cmt) > 0)
            {
                return Json("true");   
            }
            return Json("Add comment error");  
                   
        }


        //
        // GET: /Product/Create
        [Authorize(Roles = Constant.ROLE_SELLER)]
        public ActionResult Create(int sid = 0, int cid = 0)
        {
            if (sid <= 0 || cid <= 0)
            {
                ViewBag.Message = "Please define your Store and Category.";
                return View("Error");
            }
            else
            {
                Store store = db.Stores.Find(sid);
                if (store != null && store.OwnerId == WebSecurity.CurrentUserId)
                {
                    Category category = db.Categories.Find(cid);
                    if (category != null)
                    {
                        Product p = new Product();
                        p.SpecsInJson = category.Template.ContentInJson;
                        p.StoreId = store.StoreId;
                        ViewBag.Store = store;
                        ViewBag.Category = category;
                        return View(p);
                    }
                    else
                    {
                        ViewBag.Message = "Can't define the Category";
                        return View("Error");
                    }
                }
                else
                {
                    ViewBag.Message = "Sorry, we can't find the store or you're not the owner.";
                    return View("Error");
                }
                
            }
        }

        //
        // POST: /Product/Create
        [Authorize(Roles = Constant.ROLE_SELLER)]
        [HttpPost]
        public ActionResult Create(Product product, int sid, int cid)
        {
            Guid guid = new Guid();
            var path = "";
            List<Image> images = new List<Image>();
            for (int i = 0; i < Request.Files.AllKeys.Length; i++)
            {
                HttpPostedFileBase hpf = Request.Files[i] as HttpPostedFileBase;
                if (hpf != null && hpf.ContentLength > 0)
                {
                    guid = Guid.NewGuid();
                    path = Path.Combine(Server.MapPath("~/App_Data/Images"), guid.ToString());
                    hpf.SaveAs(path);
                    Image image = new Image { Path = guid.ToString() };
                    images.Add(image);
                }
            }
            if (ModelState.IsValid)
            {
                product.CategoryId = cid;
                product.StoreId = sid;
                product.ProductImages = images;
                db.Products.Add(product);
                
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (var failure in ex.EntityValidationErrors)
                    {
                        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                        foreach (var error in failure.ValidationErrors)
                        {
                            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                            sb.AppendLine();
                        }
                    }

                    throw new DbEntityValidationException(
                        "Entity Validation Failed - errors follow:\n" +
                        sb.ToString(), ex
                    ); // Add the original exception as the innerException
                }
                return RedirectToAction("Index");
            }

            return View(product);
        }

        //
        // GET: /Product/Edit/5
        [Authorize(Roles = Constant.ROLE_SELLER)]
        public ActionResult Edit(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Product/Edit/5
        [Authorize(Roles = Constant.ROLE_SELLER)]
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //
        // GET: /Product/Delete/5
        [Authorize(Roles = Constant.ROLE_SELLER)]
        public ActionResult Delete(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Product/Delete/5
        [Authorize(Roles = Constant.ROLE_SELLER)]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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