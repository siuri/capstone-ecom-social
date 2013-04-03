using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone_20130302.Models;

namespace Capstone_20130302.Logic
{
    public class ProductLike_Logic
    {
        private static SocialBuyContext db = new SocialBuyContext();

        #region [Add Product Like ]
        /// <summary>
        /// [Add Product Like
        /// </summary>
        /// <param name="productID">Product ID</param>
        /// <param name="userID">User ID</param>
        /// <returns>True or False</returns>
        public static bool AddProductLike(int productID,int userID)
        {
            try
            {
                ProductLike item = new ProductLike();
                item.ProductId = productID;
                item.UserId = userID;
                db.ProductLikes.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        #endregion

        #region [Add Product Like ]
      /// <summary>
        /// Add Product Like
      /// </summary>
        /// <param name="item">ProductLike object</param>
      /// <returns>True or False</returns>
        public static bool AddProductLike(ProductLike item)
        {
            try
            {
                db.ProductLikes.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        #endregion

        #region [Delete Product Like ]
        /// <summary>
        /// Delete Product Like
        /// </summary>
        /// <param name="pro">Object ProductLike</param>
        /// <returns>True or False</returns>
        public static bool DeleteProductLike(ProductLike pro)
        {
            try
            {
                if (pro != null)
                {
                    db.ProductLikes.Attach(pro);
                    db.ProductLikes.Remove(pro);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        #endregion

        #region [Delete Product Like ]
        /// <summary>
        /// [Delete Product Like
        /// </summary>
        /// <param name="productID">Product ID</param>
        /// <param name="userID">User ID</param>
        /// <returns>True or False</returns>
        public static bool DeleteProductLike(int productID, int userID)
        {
            try
            {
                ProductLike pro = (from ProductLike item in db.ProductLikes
                                    where item.ProductId == productID && item.UserId == userID
                                    select item).FirstOrDefault();
                if (pro != null)
                {
                    db.ProductLikes.Attach(pro);
                    db.ProductLikes.Remove(pro);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                return false;
            }
        }

        #endregion

        #region [Check Like Product User ID]
        /// <summary>
        /// Check Like Product User ID
        /// </summary>
        /// <param name="productID"> product ID</param>
        /// <param name="userID"> user ID </param>
        /// <returns>return True is exsits and Flase is not exsits</returns>
        public static bool CheckLikeProductUserID(int productID, int userID)
        {
            try
            {
                ProductLike pro = (from ProductLike item in db.ProductLikes
                                   where item.ProductId == productID && item.UserId == userID
                                   select item).FirstOrDefault();
                if (pro != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        #endregion
    }
}