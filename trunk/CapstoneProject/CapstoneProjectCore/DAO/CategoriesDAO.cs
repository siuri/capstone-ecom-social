using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapstoneProjectCore.DAO
{
    public class CategoriesDAO
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng Categories
        /// </summary>
        /// <param name="_obj">đối tượng Categories cần thêm</param>
        /// <returns></returns>
        public static Category Insert(Category _obj)
        {
            Category Obj = null;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                Obj = context.Categories_Insert(_obj.CategoriesName,_obj.Description,_obj.IsDelete,_obj.TeamplateDetailJson).First<Category>();
            }
            catch { }
            return Obj;
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
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.Categories_Delete(_iCategoryID);
                isSuccess = true;
            }
            catch { }
            return isSuccess;
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
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.Categories_Update(_obj.CategoriesID,_obj.CategoriesName,_obj.Description,_obj.IsDelete,_obj.TeamplateDetailJson);
                isSuccess = true;
            }
            catch { }
            return isSuccess;
        }
        #endregion

        #region "[ lấy danh sách các đối tượng Categories]"
        /// <summary>
        /// lấy danh sách các đối tượng Categories
        /// </summary>
        /// <returns></returns>
        public static List<Category> GetAllToList()
        {
            List<Category> lstCatagory = new List<Category>();
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                lstCatagory = context.Categories_Get_List().ToList<Category>();
            }
            catch { }
            return lstCatagory;
        }
        #endregion

    }
}
