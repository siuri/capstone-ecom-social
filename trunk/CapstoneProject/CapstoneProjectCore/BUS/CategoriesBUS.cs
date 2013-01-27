using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapstoneProjectCore.DAO;

namespace CapstoneProjectCore.BUS
{
    public class CategoriesBUS
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng Categories
        /// </summary>
        /// <param name="_obj">đối tượng Categories cần thêm</param>
        /// <returns></returns>
        public static Category Insert(Category _obj)
        {
            return CategoriesDAO.Insert(_obj);
        }
        #endregion

        #region "[Delete]"
        /// <summary>
        /// xóa 1 đối tượng Categories
        /// </summary>
        /// <param name="_iUserID">mã đối tượng Categories</param>
        /// <returns></returns>
        public static bool Delete(int _iCategoryID)
        {
            return CategoriesDAO.Delete(_iCategoryID);
        }
        #endregion

        #region "[Update]"
        /// <summary>
        /// cập nhật 1 đối tượng ategories
        /// </summary>
        /// <param name="_obj">đối tượng Categories cần cập nhật</param>
        /// <returns></returns>
        public static bool Update(Category _obj)
        {
            return  CategoriesDAO.Update(_obj);
        }
        #endregion

        #region "[ lấy danh sách các đối tượng Categories]"
        /// <summary>
        /// lấy danh sách các đối tượng Categories
        /// </summary>
        /// <returns></returns>
        public static List<Category> GetAllToList()
        {
            return CategoriesDAO.GetAllToList();
        }
        #endregion
    }
}
