using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapstoneProjectCore.DAO
{
    public class ProductDAO
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng sản phẩm
        /// </summary>
        /// <param name="_obj">đối tượng sản phẩm cần thêm</param>
        /// <returns></returns>
        public static int Insert(Product _obj)
        {
            int IDResult = -1;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                Product Obj = context.Product_Insert(_obj.ProductName,_obj.Description,_obj.PriceCurrent,_obj.CategoriesID,_obj.StoreID,_obj.TotalLike,_obj.TotalComment,_obj.StatusID,_obj.ImageID,_obj.MoreDetailJson,_obj.TotalBuy).First<Product>();
            }
            catch { }
            return IDResult;
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
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.Product_Delete(_iProductID);

                isSuccess = true;
            }
            catch { }
            return isSuccess;
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
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.Product_Update(_obj.ProductID,_obj.ProductName, _obj.Description, _obj.PriceCurrent, _obj.CategoriesID, _obj.StoreID, _obj.TotalLike, _obj.TotalComment, _obj.StatusID, _obj.ImageID, _obj.MoreDetailJson, _obj.TotalBuy);

                isSuccess = true;
            }
            catch { }
            return isSuccess;
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
            List<Product> products = new List<Product>();
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                products = context.Product_GetByCategoriesId(_iCategoriID).ToList<Product>();
            }
            catch { }
            return products;
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
            Product objResult = null;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                objResult = context.Product_GetByProductId(_iProductID).First<Product>();
            }
            catch { }
            return objResult;
        }
        #endregion
    }
}
