using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapstoneProjectCore.DAO;

namespace CapstoneProjectCore.BUS
{
    public class CommentProductBUS
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng CommentProduct
        /// </summary>
        /// <param name="_obj">đối tượng CommentProduct cần thêm</param>
        /// <returns></returns>
        public static CommentProduct Insert(CommentProduct _obj)
        {
            return CommentProductDAO.Insert(_obj);
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
            return CommentProductDAO.Delete(_iCommentID);
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
            return CommentProductDAO.GetAllToList(iProductID);
        }
        #endregion
    }
}
