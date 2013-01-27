using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapstoneProjectCore.DAO;

namespace CapstoneProjectCore.BUS
{
    public class OrderBUS
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng đơn hàng
        /// </summary>
        /// <param name="_obj">đối tượng đơn hàng cần thêm</param>
        /// <returns></returns>
        public static int Insert(Order _obj)
        {
            return OrderDAO.Insert(_obj);
        }
        #endregion

        #region "[Delete]"
        /// <summary>
        /// xóa 1 đối tượng đơn hàng
        /// </summary>
        /// <param name="_iOrderID">mã đối tượng đơn hàng</param>
        /// <returns></returns>
        public static bool Delete(int _iOrderID)
        {
            return OrderDAO.Delete(_iOrderID);
        }
        #endregion

        #region "[Update]"
        /// <summary>
        /// cập nhật 1 đối tượng đơn hàng
        /// </summary>
        /// <param name="_obj">đối tượng đơn hàng cần cập nhật</param>
        /// <returns></returns>
        public static bool Update(Order _obj)
        {
            return OrderDAO.Update(_obj);
        }
        #endregion

        #region "[Lấy danh sách các đối tượng đơn hàng theo cửa hàng]"
        /// <summary>
        /// Lấy danh sách các đối tượng đơn hàngtheo cửa hàng
        /// </summary>
        /// <param name="_iStatusID">Mã tình trạng</param>
        /// <param name="_iStoreID">Mã cửa hàng</param>
        /// <returns></returns>
        public static List<Order> GetAllToListByStoreID(int _iStoreID, int _iStatusID)
        {
            return OrderDAO.GetAllToListByStoreID(_iStoreID, _iStatusID);
        }
        #endregion

        #region "[Lấy 1 đối tượng đơn hàng]"
        /// <summary>
        /// Lấy 1 đối tượng đơn hàng
        /// </summary>
        /// <param name="_iOrderID">mã đối tượng đơn hàng cần lấy</param>
        /// <returns></returns>
        public static Order SelectByOrderID(int _iOrderID)
        {
            return OrderDAO.SelectByOrderID(_iOrderID);
        }
        #endregion

        #region "[Lấy danh sách các đơn hàng thuộc về 1 khách hàng-sắp xếp giảm dần theo thời gian]"
        /// <summary>
        /// Lấy danh sách các đơn hàng thuộc về 1 khách hàng-sắp xếp giảm dần theo thời gian
        /// </summary>
        /// <param name="_iUserID">mã người dùng</param>
        /// <param name="_iStatusID">Tình trạng</param>
        /// <returns></returns>
        public static List<Order> SelectByUserID(int _iUserID, int _iStatusID)
        {
            return OrderDAO.SelectByUserID(_iUserID, _iStatusID);
        }
        #endregion
    }
}
