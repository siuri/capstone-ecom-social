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
            List<SearchItem> listitem = SearchLocal(searchString);
            return View(listitem);
        }

        public JsonResult Search(string searchString)
        {
            List<SearchItem> listitem = SearchLocal(searchString);
            return this.Json(listitem, JsonRequestBehavior.AllowGet);
        }
        private List<SearchItem> SearchLocal(string searchString)
        {
            List<Product> products = (from pr in db.Products where pr.Name.ToUpper().Contains(searchString.ToUpper()) select pr).ToList();
            List<Store> stores = (from pr in db.Stores where pr.StoreName.ToUpper().Contains(searchString.ToUpper()) select pr).ToList();
            List<Profile> users = (from pr in db.Profiles where pr.DisplayName.ToUpper().Contains(searchString.ToUpper()) select pr).ToList();

            List<SearchItem> listitem = new List<SearchItem>();
            for (int i = 0; i < products.Count(); i++)
            {
                listitem.Add(new SearchItem
                {
                    Text = "Product",
                    ID = "" + products[i].ProductId,
                    Value = products[i].Name,
                    ImageUrl = products[i].ProductImages.ElementAt(0).Path

                });
            }
            for (int i = 0; i < stores.Count(); i++)
            {
                listitem.Add(new SearchItem
                {
                    Text = "Store",
                    ID = "" + stores[i].StoreId,
                    Value = stores[i].StoreName,
                    ImageUrl = stores[i].CoverImage.Path

                });
            }

            for (int i = 0; i < users.Count(); i++)
            {
                listitem.Add(new SearchItem
                {
                    Text = "User",
                    ID = "" + users[i].ProfileId,
                    Value = users[i].DisplayName,
                    ImageUrl = users[i].ProfileImage.Path,

                });
            }

            return listitem;
        }

    }
}
