using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapstoneProjectCore.DAO
{
    public class Product_LikeDAO
    {
        #region "[Insert]"
        /// <summary>
        /// Thêm 1 Like sản phẩm
        /// </summary>
        /// <param name="_obj">Đối tượng Product_ like</param>
        /// <returns></returns>
        public static bool Insert(Product_Like _obj)
        {
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.Product_Likes_Insert(_obj.UserID, _obj.ProductID);
                return true;
            }
            catch { }
            return false;
        }
        #endregion

        #region "[Delete]"
        /// <summary>
        /// xóa like
        /// </summary>
        /// <param name="_iProductID">Mã sản phẩm</param>
        /// <param name="_iUserID">Mã User like</param>
        /// <returns></returns>
        public static bool Delete(int _iProductID,int _iUserID)
        {
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.Product_Likes_Delete(_iUserID,_iProductID);
                isSuccess = true;
            }
            catch { }
            return isSuccess;
        }
        #endregion

        #region "[Lấy danh sách người like ]"
        /// <summary>
        /// xóa like
        /// </summary>
     
        /// <param name="_iProductID">Mã sản phẩm</param>
        /// <returns></returns>
        public static List<User> GetListUserLikeByProductID(int _iProductID)
        {
            List<User> list = new List<User>();
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                list  = context.Product_Likes_GetByProductId(_iProductID).ToList<User>();
               
            }
            catch { }
            return list;
        }
        #endregion

        #region "[Lấy danh sách sản phẩm của user ]"
        /// <summary>
        /// xóa like
        /// </summary>

        /// <param name="_iProductID">Mã user</param>
        /// <returns></returns>
        public static List<Product> GetListProductLikeByUserID(int _iUserID)
        {
            List<Product> list = new List<Product>();
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                list = context.Product_Likes_GetByUserId(_iUserID).ToList<Product>();

            }
            catch { }
            return list;
        }
        #endregion

    }
}
