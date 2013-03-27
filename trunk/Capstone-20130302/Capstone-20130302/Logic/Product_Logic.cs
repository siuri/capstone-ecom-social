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
        
        // Get List User Like,Buy Product 
        // Type : 1_Like , 2_Buy
        // ID : ID product
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


        // Get List User Like,Buy Product 
        // Type : 1_Like , 2_Buy
        // ID : ID product
        // number : Amount row select
        public static List<UserProfile> GetListUserProfileRandom(int type, int ID,int number)
        {
            List<UserProfile> listuser = new List<UserProfile>();
            switch (type)
            {
                case 1:
                    listuser = (from ProductLike pro in db.ProductLikes
                                where pro.ProductId == ID
                                select pro.User).Take(number).ToList();
                    break;
                case 2:
                    listuser = (from OrderDetail order in db.OrderDetails
                                where order.ProductId == ID
                                select order.Order.Users).Distinct().ToList();
                    break;
                default:
                    break;  
            }

            int count = listuser.Count(); // get count here
            int index = new Random(number).Next(count);

            var result = listuser.Skip(index).ToList(); // pick on here 

            return result;
        }


    }
}