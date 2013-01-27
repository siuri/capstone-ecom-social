using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapstoneProjectCore.DAO
{
    public class OrderDetailDAO
    {
        #region "[Insert]"
        /// <summary>
        /// Thêm 1 đối tượng danh sách đơn hàng
        /// </summary>
        /// <param name="_obj">đối tượng danh sách đơn hàng cần thêm</param>
        /// <returns></returns>
        public static int Insert(OrderDetail _obj)
        {
            int IDResult = -1;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                OrderDetail Obj = context.OrderDetail_Insert(_obj.ProductID, _obj.Amount, _obj.PriceCurrent, _obj.OrderID, _obj.IsDelete).First<OrderDetail>();

                if (Obj != null)
                    IDResult = Obj.OrderDetailID;
            }
            catch { }
            return IDResult;
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
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.OrderDetail_Delete(_iOrderDetailsID);
                isSuccess = true;
            }
            catch { }
            return isSuccess;
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
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.OrderDetail_Update(_obj.OrderDetailID,_obj.ProductID, _obj.Amount, _obj.PriceCurrent, _obj.OrderID, _obj.IsDelete);
                isSuccess = true;
            }
            catch { }
            return isSuccess;
        }
        #endregion

        #region "[lấy danh sách các đối tượng danh sách đơn hàng]"
        /// <summary>
        /// lấy danh sách các đối tượng danh sách đơn hàng
        /// </summary>
        /// <returns></returns>
        public static List<OrderDetail> GetAllToList(int _iOrderID)
        {
            List<OrderDetail> OrderDetails = new List<OrderDetail>();
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                OrderDetails = context.OrderDetail_GetByOrderId(_iOrderID).ToList<OrderDetail>();

            }
            catch { }
            return OrderDetails;
        }
        #endregion

        #region "[ Lấy 1 đối tượng danh sách đơn hàng]"
        /// <summary>
        /// Lấy 1 đối tượng danh sách đơn hàng
        /// </summary>
        /// <param name="_iOrderDetailID">mã đối tượng đơn hàng</param>
        /// <returns></returns>
        public static OrderDetail SelectByPrimaryKey(int _iOrderDetailID)
        {
            OrderDetail objResult = null;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                objResult = context.OrderDetail_GetByOrderDetailId(_iOrderDetailID).First<OrderDetail>();
            }
            catch { }
            return objResult;
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
            List<OrderDetail> objResult = new List<OrderDetail>() ;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                objResult = context.OrderDetail_GetByProductId(_iProductID).ToList<OrderDetail>();
            }
            catch { }
            return objResult;
        }
        #endregion

    }
}
