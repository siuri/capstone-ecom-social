using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapstoneProjectCore.DAO;

namespace CapstoneProjectCore.BUS
{
    public class Product_LikeBUS
    {
        #region "[Insert]"
        /// <summary>
        /// Thêm 1 Like sản phẩm
        /// </summary>
        /// <param name="_obj">Đối tượng Product_ like</param>
        /// <returns></returns>
        public static bool Insert(Product_Like _obj)
        {
            return Product_LikeDAO.Insert(_obj);
        }
        #endregion

        #region "[Delete]"
        /// <summary>
        /// xóa like
        /// </summary>
        /// <param name="_iProductID">Mã sản phẩm</param>
        /// <param name="_iUserID">Mã User like</param>
        /// <returns></returns>
        public static bool Delete(int _iProductID, int _iUserID)
        {
            return Product_LikeDAO.Delete(_iProductID, _iUserID);
            
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
            return Product_LikeDAO.GetListUserLikeByProductID(_iProductID);
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
            return Product_LikeDAO.GetListProductLikeByUserID(_iUserID);
        }
        #endregion
    }
}
