using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone_20130302.Models;

namespace Capstone_20130302.Logic
{
    public class Order_Logic
    {
        private static SocialBuyContext db = new SocialBuyContext();

        #region [ Add Order]
        /// <summary>
        /// Add Order
        /// </summary>
        /// <param name="_order">Object Order</param>
        /// <param name="pro">list Object product</param>
        /// <returns>Order ID</returns>
        public static int AddOrder(Order _order,List<ProductOrder> pro)
        {
            try
            {
                _order.StatusId = 1;
                db.Orders.Add(_order);
                db.SaveChanges();
                
                int orderid = _order.OrderId;
                foreach (ProductOrder temp in pro)
                {
                    OrderDetail orderdetail = new OrderDetail();
                    orderdetail.OrderId = orderid;
                    orderdetail.ProductId = temp.ProductId;
                    Product product = Product_Logic.GetProductByID(temp.ProductId);
                    orderdetail.SoldPrice = product.Price;
                    orderdetail.Amount = temp.Quantity;
                    db.OrderDetails.Add(orderdetail);
                    db.SaveChanges();
                }
                return orderid;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        #endregion

        #region [ Get List Order By UserID]
        /// <summary>
        /// Get List Order By UserID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="type">1 : seller , 2 : Buyer</param>
        /// <returns>List<Order></returns>
        public static List<Order> GetListByUserID(int userID,int type)
        {
           
            try
            {
                List<Order> list = new List<Order>();
                
                switch (type)
                {
                    case 1:
                        List<Store> liststore = (from Store _store in db.Stores
                                                 where _store.OwnerId == userID
                                                 select _store).ToList();
                        foreach (var item in liststore)
                        {
                            list.AddRange(GetListByStoreID(item.StoreId));
                        }
                        break;
                    case 2:
                        list = (from _order in db.Orders
                                where _order.UserId == userID
                                select _order).ToList();
                        break;
                    default:
                        break;
                }
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region [ Get List Order By StoreID]
        /// <summary>
        /// Get List Order By StoreID
        /// </summary>
        /// <param name="StoreID">StoreID</param>
        /// <returns> List<Order> </returns>
        public static List<Order> GetListByStoreID(int StoreID)
        {
            try
            {
                List<Order> list = (from _order in db.Orders
                                    where _order.StoreId == StoreID
                                    select _order).ToList();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region [Update Status Order]
        /// <summary>
        /// [Update Status Order]
        /// </summary>
        /// <param name="orderID">Order ID</param>
        /// <param name="statusID">Status ID</param>
        /// <returns>True or False</returns>
        public static bool UpdateStatusOrder(int orderID, int statusID)
        {
            try
            {
                Order _order = db.Orders.Single(t => t.OrderId == orderID);
                _order.StatusId = statusID;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}