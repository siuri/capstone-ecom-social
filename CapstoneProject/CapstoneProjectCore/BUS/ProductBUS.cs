using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapstoneProjectCore.DAO;

namespace CapstoneProjectCore.BUS
{
    public class ProductBUS
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng sản phẩm
        /// </summary>
        /// <param name="_obj">đối tượng sản phẩm cần thêm</param>
        /// <returns></returns>
        public static int Insert(Product _obj)
        {
            return ProductDAO.Insert(_obj);
        }
        #endregion

        #region "[Delete]"
        /// <summary>
        /// xóa 1 đối tượng sản phẩm
        /// </summary>
        /// <param name="_iProductID">mã đối tượng sản phẩm</param>
        /// <returns></returns>
        public static bool Delete(int _iProductID)
        {
            return ProductDAO.Delete(_iProductID);
        }
        #endregion

        #region "[Update]"
        /// <summary>
        /// cập nhật đối tượng sản phẩm
        /// </summary>
        /// <param name="_obj">đối tượng sản phẩm cần cập nhật</param>
        /// <returns></returns>
        public static bool Update(Product _obj)
        {
            return ProductDAO.Update(_obj);
        }
        #endregion

        #region "[lấy danh sách các đối tượng sản phẩm theo Categori]"
        /// <summary>
        /// lấy danh sách các đối tượng sản phẩm theo Categori
        /// <param name="_iCategoriID">Mã catalog</param>
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetListProductByCategoriID(int _iCategoriID)
        {
            return ProductDAO.GetListProductByCategoriID(_iCategoriID);
        }
        #endregion

        #region "[Lấy 1 đối tượng sản phẩm]"
        /// <summary>
        /// Lấy 1 đối tượng sản phẩm
        /// </summary>
        /// <param name="_iProductID">mã đối tượng sản phẩm</param>
        /// <returns></returns>
        public static Product SelectByPoductID(int _iProductID)
        {
            return ProductDAO.SelectByPoductID(_iProductID);
        }
        #endregion
    }
}
