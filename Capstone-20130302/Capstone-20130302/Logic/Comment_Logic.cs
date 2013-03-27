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
        /// <summary>
        /// Get list commnet by product
        /// </summary>
        /// <param name="productID">product ID</param>
        /// <returns>list comment</returns>
        public static List<Comment> GetListCommentByProductID(int productID)
        {
            List<Comment> list = new List<Comment>();
            list = (from Comment cm in db.Comments
                    where cm.ProductId == productID
                    select cm).OrderByDescending(cm =>cm.CreateDate).ToList();
            return list;
        }
        #endregion

        #region [ add new comment]
        /// <summary>
        ///  add new comment
        /// </summary>
        /// <param name="cmt">Object commnet need add</param>
        /// <returns>ID comment </returns>
        public static int AddNewComment(Comment cmt)
        {
            try
            {
                db.Comments.Add(cmt);
                db.SaveChanges();
                return cmt.CommentId;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        #endregion


    }
}