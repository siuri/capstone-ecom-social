using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone_20130302.Models;

namespace Capstone_20130302.Logic
{
    public class OrderDetails_Logic
    {
        private static SocialBuyContext db = new SocialBuyContext();

        


        #region [ Get OrderDetail By OderID]
        /// <summary>
        ///  [ Get OrderDetail By OderID]
        /// </summary>
        /// <param name="OderId">OderId</param>
        /// <returns>List OrderDetail</returns>
        public static List<OrderDetail> GetOrderDetailByOrderID(int OderId)
        {

            try
            {
                List<OrderDetail> list = new List<OrderDetail>();


                list = (from OrderDetail _orderdetail in db.OrderDetails
                        where _orderdetail.OrderId == OderId
                        select _orderdetail).ToList();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}