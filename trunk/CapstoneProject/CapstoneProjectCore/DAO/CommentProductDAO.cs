using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapstoneProjectCore.DAO
{
    public class CommentProductDAO
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng CommentProduct
        /// </summary>
        /// <param name="_obj">đối tượng CommentProduct cần thêm</param>
        /// <returns></returns>
        public static CommentProduct Insert(CommentProduct _obj)
        {
            CommentProduct result = null;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                result = context.CommentProduct_Insert(_obj.CommentContent, _obj.CreateDate, _obj.UserID, _obj.ProductID).First<CommentProduct>();
            }
            catch { }
            return result;
        }
        #endregion

        #region "[Delete]"
        /// <summary>
        /// xóa 1 đối tượng CommentProduct
        /// </summary>
        /// <param name="_iUserID">mã đối tượng CommentProduct</param>
        /// <returns></returns>
        public static bool Delete(int _iCommentID)
        {
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.CommentProduct_Delete(_iCommentID);
                isSuccess = true;
            }
            catch { }
            return isSuccess;
        }
        #endregion

        #region "[ lấy danh sách các đối tượng CommentProduct]"
        /// <summary>
        /// lấy danh sách các đối tượng CommentProduct
        /// </summary>
        /// <param name="ProductID">mã sản phẩm</param>
        /// <returns></returns>
        public static List<CommentProduct> GetAllToList(int iProductID)
        {
            List<CommentProduct> lstComment = new List<CommentProduct>();
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                lstComment = context.CommentProduct_GetListByProductID(iProductID).ToList<CommentProduct>();
            }
            catch { }
            return lstComment;
        }
        #endregion


    }
}
