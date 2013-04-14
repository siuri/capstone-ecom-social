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
            list = db.Comments.Where(c => c.ProductId == productID).OrderByDescending(c => c.CreateDate).ToList();
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
                Product _pro = db.Products.Find(cmt.ProductId);
                if (_pro.TotalComments != null)
                {
                    _pro.TotalComments = _pro.TotalLikes + 1;
                }
                else
                {
                    _pro.TotalComments = 1;
                }
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