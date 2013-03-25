using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_20130302.Models;

namespace Capstone_20130302.Controllers
{
    public class SearchController : Controller
    {
        private SocialBuyContext db = new SocialBuyContext();
        //
        // GET: /Search/

        public ActionResult Index(string searchString)
        {
            return View();
        }

        public JsonResult Search(string searchString)
        {
            List<Product> products = (from pr in db.Products where pr.Name.ToUpper().Contains(searchString.ToUpper()) select pr).ToList();
            List<Store> stores = (from pr in db.Stores where pr.StoreName.ToUpper().Contains(searchString.ToUpper()) select pr).ToList();
            List<Profile> users = (from pr in db.Profiles where pr.DisplayName.ToUpper().Contains(searchString.ToUpper()) select pr).ToList();

            List<SearchItem> productResults = new List<SearchItem>();
            List<SearchItem> storeResults = new List<SearchItem>();
            List<SearchItem> userResults = new List<SearchItem>();

            foreach (var product in products)
            {
                if (product != null && product.ProductImages != null && product.ProductImages.Count > 0)
                {
                    productResults.Add(new SearchItem
                    {
                        ID = "/Product/Id/" + product.ProductId,
                        Value = product.Name,
                        ImageId = product.ProductImages.ElementAt(0).ImageId
                    });
                }
            }

            foreach (var store in stores)
            {
                if (store != null && store.ProfileImage != null)
                {
                    storeResults.Add(new SearchItem
                    {
                        ID = "/Store/Id/" + store.StoreId,
                        Value = store.StoreName,
                        ImageId = store.ProfileImage.ImageId
                    });
                }
            }

            var userId = (dynamic) null;
            foreach (var user in users)
            {
                if (user != null && user.ProfileImage != null)
                {
                    userId = (from _user in db.UserProfiles
                                  where _user.ProfileId == user.ProfileId
                                  select _user.UserId).FirstOrDefault();
                    userResults.Add(new SearchItem
                    {
                        ID = "/User/Id/" + userId,
                        Value = user.DisplayName,
                        ImageId = user.ProfileImage.ImageId
                    });
                }
            }
            var json = new { Products = productResults, Stores = storeResults, Users = userResults };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

    }


    public class SearchItem
    {
        public string ID { get; set; }
        public string Value { get; set; }
        public int ImageId { get; set; }
    }
}
