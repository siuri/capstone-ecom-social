using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone_20130302.Models;

namespace Capstone_20130302.Logic
{
    public class Account_Logic
    {
        private static SocialBuyContext db = new SocialBuyContext();

        #region [Get list store follow by user]
        /// <summary>
        ///  [Get list store follow by user]
        /// </summary>
        /// <param name="userID">userID </param>
        /// <returns>List store</returns>
        
        public static List<Store> GetListStoreFollowByUser(int userID)
        {
            List<Store> liststore = new List<Store>();
            liststore = (from Follow follow in db.Follows
                         where follow.UserId == userID
                         select follow.Store).ToList();
            return liststore;
        }
        #endregion

        #region [Get list Product Like by user]
        /// <summary>
        /// [Get list Product Like by user]
        /// </summary>
        /// <param name="userID">user ID</param>
        /// <returns>List product</returns>
        public static List<Product> GetListProductLikeByUser(int userID)
        {
            List<Product> listpro = new List<Product>();
            listpro = (from ProductLike pro in db.ProductLikes
                         where pro.UserId == userID
                         select pro.Product).ToList();
            return listpro;
        }
        #endregion
    }
}