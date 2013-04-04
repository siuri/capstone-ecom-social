using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone_20130302.Models;

namespace Capstone_20130302.Logic
{
      

    public class Product_Logic
    {
        private static SocialBuyContext db = new SocialBuyContext();

        #region [ Get List All User Like,Buy Product ]
        /// <summary>
        ///  Get List All User Like,Buy Product
        /// </summary>
        /// <param name="type"> 1_Like , 2_Buy</param>
        /// <param name="ID">ID Product</param>
        /// <returns>List <UserProfile></returns>
        /// 
        public static List<UserProfile> GetListUserProfileAll(int type,int ID)
        {
            List<UserProfile> listuser = new List<UserProfile>();
            switch (type)
            {
                case 1:
                    listuser = (from ProductLike pro in db.ProductLikes
                                where pro.ProductId == ID
                                select pro.User).ToList();
                    break;
                case 2:
                    listuser = (from OrderDetail order in db.OrderDetails
                                where order.ProductId == ID
                                select order.Order.Users).Distinct().ToList();
                    break;
                default:
                    break;
            }
            return listuser;
        }
        #endregion

        #region [ Get List User Like,Buy Product ]
        /// <summary>
        ///  Get List User Like,Buy Product
        /// </summary>
        /// <param name="type"> 1_Like , 2_Buy</param>
        /// <param name="ID">ID Product</param>
        /// <param name="number">Amount row select</param>
        /// <returns>List <UserProfile></returns>
        public static List<UserProfile> GetListUserProfileRandom(int type, int ID, int number)
        {
            List<UserProfile> listuser = new List<UserProfile>();
            switch (type)
            {
                case 1:
                    listuser = (from ProductLike pro in db.ProductLikes
                                where pro.ProductId == ID
                                select pro.User).Take(number).Take(5).ToList();
                    break;
                case 2:
                    listuser = (from OrderDetail order in db.OrderDetails
                                where order.ProductId == ID
                                select order.Order.Users).Take(5).Distinct().ToList();
                    break;
                default:
                    break;
            }

           // int count = listuser.Count(); // get count here
           // int index = new Random(number).Next(count);

           // var result = listuser.Skip(index).ToList(); // pick on here 

            return listuser;
        }
        #endregion

        #region [ Get Prodcut By ID ]
        /// <summary>
        /// Get Prodcut By ID
        /// </summary>
        /// <param name="ID">Procut UD</param>
        /// <returns>Product</returns>
        public static Product GetProductByID(int ID)
        {
            try
            {
                Product temp = db.Products.FirstOrDefault(m => m.ProductId == ID);
                return temp;
            }
            catch (Exception)
            {
                return null;
            }
           
        }
        #endregion

    }
}