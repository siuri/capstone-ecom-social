using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapstoneProjectCore.DAO;

namespace CapstoneProjectCore.BUS
{
    public class OrderDetailBUS
    {
        #region "[Insert]"
        /// <summary>
        /// Thêm 1 đối tượng danh sách đơn hàng
        /// </summary>
        /// <param name="_obj">đối tượng danh sách đơn hàng cần thêm</param>
        /// <returns></returns>
        public static int Insert(OrderDetail _obj)
        {
            return OrderDetailDAO.Insert(_obj);
        }
        #endregion

        #region "[Delete]"
        /// <summary>
        /// xóa 1 đối tượng danh sách đơn hàng
        /// </summary>
        /// <param name="_iOrderDetailsID">mã đối tượng danh sách đơn hàng</param>
        /// <returns></returns>
        public static bool Delete(int _iOrderDetailsID)
        {
            return OrderDetailDAO.Delete(_iOrderDetailsID);
        }
        #endregion

        #region "[Update]"
        /// <summary>
        /// cập nhật đối tượng danh sách đơn hàng
        /// </summary>
        /// <param name="_obj">đối tượng đối tượng danh sách đơn hàng</param>
        /// <returns></returns>
        public static bool Update(OrderDetail _obj)
        {
            return OrderDetailDAO.Update(_obj);
        }
        #endregion

        #region "[lấy danh sách các đối tượng danh sách đơn hàng]"
        /// <summary>
        /// lấy danh sách các đối tượng danh sách đơn hàng
        /// </summary>
        /// <returns></returns>
        public static List<OrderDetail> GetAllToList(int _iOrderID)
        {
            return OrderDetailDAO.GetAllToList(_iOrderID);
        }
        #endregion

        #region "[ Lấy 1 đối tượng danh sách đơn hàng]"
        /// <summary>
        /// Lấy 1 đối tượng danh sách đơn hàng
        /// </summary>
        /// <param name="_iOrderDetailID">mã đối tượng đơn hàng</param>
        /// <returns></returns>
        public static OrderDetail SelectByOrderDetailID(int _iOrderDetailID)
        {
            return OrderDetailDAO.SelectByPrimaryKey(_iOrderDetailID);
        }
        #endregion

        #region "[ Lấy 1 đối tượng danh sách đơn hàng theo sản phẩm]"
        /// <summary>
        /// Lấy 1 đối tượng danh sách đơn hàng
        /// </summary>
        /// <param name="_iOrderDetailID">mã đối tượng đơn hàng</param>
        /// <returns></returns>
        public static List<OrderDetail> SelectByProductID(int _iProductID)
        {
            return OrderDetailDAO.SelectByProductID(_iProductID);
        }
        #endregion
    }
}
