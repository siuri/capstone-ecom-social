using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone_20130302.Models;

namespace Capstone_20130302.Logic
{
    public class UserProfiles_Logic
    {
        private static SocialBuyContext db = new SocialBuyContext();

        #region [Get User Profile By Profile ID]
        /// <summary>
        /// Get User Profile By Profile ID
        /// </summary>
        /// <param name="profileID">profile ID</param>
        /// <returns>object UserProfile</returns>
        public static UserProfile GetUserProfileByProfileID(int profileID)
        {
            UserProfile user = (from UserProfile us in db.UserProfiles
                                where us.ProfileId == profileID
                                select us).FirstOrDefault();
            return user;
        }
        #endregion


        #region [Get User Profile By User Name]
        /// <summary>
        /// Get User Profile By User Name
        /// </summary>
        /// <param name="profileID">User Name</param>
        /// <returns>object UserProfile</returns>
        public static UserProfile GetUserProfileByUserName(string username)
        {
            UserProfile user = (from UserProfile us in db.UserProfiles
                                where us.UserName == username
                                select us).FirstOrDefault();
            return user;
        }
        #endregion

    }
}