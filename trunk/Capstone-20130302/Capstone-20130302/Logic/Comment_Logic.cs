using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone_20130302.Models;

namespace Capstone_20130302.Logic
{

    public class Comment_Logic
    {
        private static SocialBuyContext db = new SocialBuyContext();

        #region [ Get list commnet by product]

        public static List<Comment> GetListCommentByProductID(int productID)
        {
            List<Comment> list = new List<Comment>();

          
            return list;
        }
        #endregion

    }
}