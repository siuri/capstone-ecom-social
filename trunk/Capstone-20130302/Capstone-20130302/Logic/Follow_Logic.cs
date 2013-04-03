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
                           where follow.FollowedUserId == ID
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
                list_profile.Add(temp.User);
            }
            return list_profile;
        }
        #endregion

        #region [ Add new Follow ]
        /// <summary>
        /// Add new Follow 
        /// </summary>
        /// <param name="flow">Object Follow</param>
        /// <returns>True or False</returns>
        public static bool AddNewFollow(Follow flow)
        {
            try
            {
                db.Follows.Add(flow);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region [ Delete new Follow ]
        /// <summary>
        /// Delete new Follow
        /// </summary>
        /// <param name="flow">Object follow</param>
        /// <returns>True or False</returns>
        public static bool DeletFollow(Follow flow)
        {
            try
            {
                db.Follows.Attach(flow);
                db.Follows.Remove(flow);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region [ Delete new Follow ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID">Id followed</param>
        /// <param name="ID">ID with type(Categories,UsersID,StoreID)</param>
        /// <param name="type">1_Categories , 2_Users , 3_Store</param>
        /// <returns>True or False</returns>
        public static bool DeletFollow(int UserID,int ID,int type)
        {
            try
            {
                Follow item = null;
                switch (type)
                {
                    case 1:
                        item = (from follow in db.Follows
                                where follow.CategoryId == ID && follow.UserId == UserID
                                select follow).FirstOrDefault();
                        break;
                    case 2:
                        item = (from follow in db.Follows
                                where follow.FollowedUserId == ID && follow.UserId == UserID
                                select follow).FirstOrDefault();
                        break;
                    case 3:
                        item = (from follow in db.Follows
                                where follow.StoreId == ID && follow.UserId == UserID
                                select follow).FirstOrDefault();
                        break;
                    default:
                        break;
                }
                if (item != null)
                {
                    db.Follows.Attach(item);
                    db.Follows.Remove(item);
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

        #region [ Check Follow for User ID ]
       /// <summary>
        ///  Check Follow for User ID 
       /// </summary>
       /// <param name="UserID">Id followed</param>
        /// <param name="ID">ID with type(Categories,UsersID,StoreID)</param>
        /// <param name="type">1_Categories , 2_Users , 3_Store</param>
       /// <returns>True is exsits and False is not exsits</returns>
        public static bool CheckFollowForUser(int UserID, int ID, int type)
        {
            Follow item = null; 
            switch (type)
            {
                case 1:
                    item = (from follow in db.Follows
                           where follow.CategoryId == ID && follow.UserId == UserID
                           select follow).FirstOrDefault();
                    break;
                case 2:
                    item = (from follow in db.Follows
                            where follow.FollowedUserId == ID && follow.UserId == UserID 
                            select follow).FirstOrDefault();
                    break;
                case 3:
                    item = (from follow in db.Follows
                            where follow.StoreId == ID && follow.UserId == UserID
                            select follow).FirstOrDefault();
                    break;
                default:
                    break;
            }
            if (item != null)
            {
                return true;
            }
            return false;
        }
        #endregion

    }
}