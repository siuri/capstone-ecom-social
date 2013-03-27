using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone_20130302.Models;

namespace Capstone_20130302.Logic
{

    public class Follow_Logic
    {
        private static SocialBuyContext db = new SocialBuyContext();
        
        #region [ Get List Follow ]
        /// <summary>
        /// Get List Follow 
        /// </summary>
        /// <param name="type"> 1_Categories , 2_Users , 3_Store</param>
        /// <param name="ID">ID with type(Categories,UsersID,StoreID) </param>
        /// <returns>List <UserProfile></returns>
        /// 
        public static List<UserProfile> GetListFollow(int type, int ID)
        {
            List<Follow> lst = new List<Follow>();
            List<UserProfile> list_profile = new List<UserProfile>();
            switch (type)
            {
               
                case 1:
                    lst = (from follow in db.Follows
                                       where follow.CategoryId == ID
                                       select follow).ToList();
                    break;
                case 2:
                    lst = (from follow in db.Follows
                           where follow.UserId == ID
                           select follow).ToList();
                    break;
                case 3:
                    lst = (from follow in db.Follows
                           where follow.StoreId == ID
                           select follow).ToList();
                    break;
                default:
                    break;
            }
            foreach (Follow temp in lst)
            {
                list_profile.Add(temp.FollowedUser);
            }
            return list_profile;
        }
        #endregion

    }
}