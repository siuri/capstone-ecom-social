using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone_20130302.Models;
using PagedList;
using Capstone_20130302.Constants;

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
        public static List<UserProfile> GetListUserProfileRandom(int type, int productId, int number, int userId = 0)
        {
            List<UserProfile> listuser = new List<UserProfile>();
            List<UserProfile> followedUsers = Follow_Logic.GetFollowedUsers(userId);
            switch (type)
            {
                case 1:
                    if (userId <= 0)
                    {
                        // Not login user
                        listuser = (from ProductLike pro in db.ProductLikes
                                    where pro.ProductId == productId orderby pro.ProductLikeId descending
                                    select pro.User).Distinct().Take(number).ToList();
                    }
                    else
                    {
                        // Login user
                        
                        List<UserProfile> likeClickedUsers = (from ProductLike pro in db.ProductLikes
                                    where pro.ProductId == productId orderby pro.ProductLikeId descending
                                    select pro.User).Distinct().ToList();
                        listuser = (from f in followedUsers
                                    join l in likeClickedUsers on f.UserId equals l.UserId
                                    select l).ToList();
                        foreach (var followedUser in followedUsers)
                        {
                            likeClickedUsers.RemoveAll(u => u.UserId == followedUser.UserId);
                        }
                        listuser.AddRange(likeClickedUsers);
                    }
                    
                    break;
                case 2:
                    if (userId <= 0)
                    {
                        listuser = (from OrderDetail order in db.OrderDetails
                                    where order.ProductId == productId
                                    orderby order.OrderId descending
                                    select order.Order.Users).Distinct().Take(number).ToList();
                    }
                    else
                    {
                        // Login user
                        List<UserProfile> orderedUsers = (from OrderDetail order in db.OrderDetails
                                                          where order.ProductId == productId
                                                          orderby order.OrderId descending
                                                          select order.Order.Users).Distinct().ToList();
                        listuser = (from f in followedUsers
                                    join o in orderedUsers on f.UserId equals o.UserId
                                    select o).ToList();
                        foreach (var followedUser in followedUsers)
                        {
                            orderedUsers.RemoveAll(u => u.UserId == followedUser.UserId);
                        }
                        listuser.AddRange(orderedUsers);
                    }
                    
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

        #region [Get List Product Recommend]
        /// <summary>
        /// [Get List Product Recommend]
        /// </summary>
        /// <param name="ProductID">Product ID</param>
        /// <param name="number">Number product</param>
        /// <returns>List Product</returns>
        public static List<Product> GetListProdcutRecommend(int ProductID,int number)
        {
            List<Product> list = new List<Product>();

            Product current = db.Products.Find(ProductID);
            if (current != null)
            {
                list = (from Product pro in db.Products
                        where pro.CategoryId == current.CategoryId && current.StoreId == pro.StoreId && pro.ProductId != current.ProductId && pro.StatusId == Constant.STATUS_ACTIVE
                        select pro ).Take(number).ToList();
            }
            if (list.Count < number)
            {
                var temp = (from Product pro in db.Products
                            where pro.CategoryId == current.CategoryId && current.StoreId != pro.StoreId && pro.ProductId != current.ProductId && pro.StatusId == Constant.STATUS_ACTIVE
                            select pro).Take(number - list.Count).ToList();
                list.AddRange(temp);
            }
            return list;
        }

        #endregion


        #region [Get List Product By CategoryID]
       /// <summary>
        ///  [Get List Product By CategoryID]
       /// </summary>
       /// <param name="CategoryID">Category ID</param>
       /// <param name="iPage">Page</param>
       /// <param name="iSize">Rows product</param>
       /// <returns></returns>
        public static List<ProductDisplay> GetListProdcutByCategoryID(int CategoryID, int iPage,int iSize)
        {
            List<ProductDisplay> list = new List<ProductDisplay>();
            IPagedList<Product> tmp = (from c in db.Products

                                      where (c.StatusId == 2 && c.CategoryId == CategoryID)
                                      orderby c.CreateDate descending
                                      select c).Take(100).ToPagedList(iPage, iSize);
            foreach (var c in tmp)
            {
                ProductDisplay temp = new ProductDisplay();
                temp.Name = c.Name;
                temp.Price = c.Price;
                temp.ProductId = c.ProductId;
                temp.Description = c.Description;
                temp.CategoryId = (int)c.CategoryId;
                temp.Images = c.ProductImages.ElementAt(0).ImageId.ToString();
                list.Add(temp);
                
            }
            return list;
        }

        #endregion

        #region [Get Total Row List Product By CategoryID]
        /// <summary>
        ///   [Get Total Row List Product By CategoryID]
        /// </summary>
        /// <param name="CategoryID">Category ID</param>
        /// <returns>Total row</returns>
        public static int GetTotalRowsProdcutByCategoryID(int CategoryID)
        {
            int count = 0;
            count = (from c in db.Products

                                       where (c.StatusId == 2 && c.CategoryId == CategoryID)
                                       select c).Count();

            return count;
        }

        #endregion

        #region [Get  List Product Category User Follows]
       /// <summary>
        ///  [Get  List Product Category User Follows]
       /// </summary>
       /// <param name="userID">User ID</param>
       /// <returns></returns>
        public static List<ProductDisplay> GetListProductCateforyFollow(int userID,int iPage,int iSize)
        {
            List<ProductDisplay> listresult = new List<ProductDisplay>();

            var list = (from c in db.Follows
                        where (c.UserId == userID && c.Category != null)
                        select c.CategoryId);
            List<int> listtemp = new List<int>();
            foreach (var temp in list)
            {
                listtemp.Add((int)temp);
            }

            IPagedList<Product> tmp = (from c in db.Products

                                       where (c.StatusId == 2 && listtemp.Contains((int)c.CategoryId))
                                       orderby c.CreateDate descending
                                       select c).Take(100).ToPagedList(iPage, iSize);
            foreach (var c in tmp)
            {
                ProductDisplay temp = new ProductDisplay();
                temp.Name = c.Name;
                temp.Price = c.Price;
                temp.ProductId = c.ProductId;
                temp.Description = c.Description.Substring(0, 30);
                temp.CategoryId = (int)c.CategoryId;
                temp.Images = c.ProductImages.ElementAt(0).ImageId.ToString();
                listresult.Add(temp);

            }
            return listresult;
        }

        #endregion

        #region [Get Total Row List Product Category User Follows]
        /// <summary>
        ///  [Get Total Row List Product Category User Follows]
        /// </summary>
        /// <param name="userID">User ID</param>
        /// <returns></returns>
        public static int GetTotalRowListProductCateforyFollow(int userID)
        {

            var list = (from c in db.Follows
                        where (c.UserId == userID && c.Category != null)
                        select c.CategoryId);
            int count = 0;
            List<int> listtemp = new List<int>();
            foreach (var temp in list)
            {
                listtemp.Add((int)temp);
            }

            count = (from c in db.Products

                     where (c.StatusId == 2 && listtemp.Contains((int)c.CategoryId))
             orderby c.CreateDate descending
             select c).Count();

            return count;
        }

        #endregion



    }
}