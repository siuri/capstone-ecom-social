using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone_20130302.Models;

namespace Capstone_20130302.Logic
{
    public class OrderStatus_Logic
    {
        private static SocialBuyContext db = new SocialBuyContext();

        #region [Get Name Order Status By ID]
        /// <summary>
        /// Get Name Order Status By ID
        /// </summary>
        /// <param name="ID">Status ID</param>
        /// <returns>Status Name </returns>
        public static string GetNameOrderStatusByID(int ID)
        {
            try
            {
                string name = (from OrderStatus status in db.OrderStatuses
                               where status.StatusId == ID
                               select status.Name).FirstOrDefault();
                return name;
            }
            catch (Exception)
            {
                return "";
            }
        }
        #endregion
    }
}