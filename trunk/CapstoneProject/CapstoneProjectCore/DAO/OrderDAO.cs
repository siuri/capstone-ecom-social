using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapstoneProjectCore.DAO
{
    public class OrderDAO
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng đơn hàng
        /// </summary>
        /// <param name="_obj">đối tượng đơn hàng cần thêm</param>
        /// <returns></returns>
        public static int Insert(Order _obj)
        {
            int IDResult = -1;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                Order Obj = context.Order_Insert(_obj.StatusID,_obj.CreateDate,_obj.UserID,_obj.RecipientName,_obj.RecipientAddress,_obj.RecipientTel,_obj.EMail,_obj.Description,_obj.TransportFee,_obj.TotalMonney,_obj.StoreID).First<Order>();
                if (Obj != null)
                    IDResult = Obj.OrderID;
            }
            catch { }
            return IDResult;
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
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.Order_Delete(_iOrderID);
                isSuccess = true;
            }
            catch { }
            return isSuccess;
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
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.Order_Update(_obj.OrderID ,_obj.StatusID, _obj.CreateDate, _obj.UserID, _obj.RecipientName, _obj.RecipientAddress, _obj.RecipientTel, _obj.EMail, _obj.Description, _obj.TransportFee, _obj.TotalMonney, _obj.StoreID);
                isSuccess = true;
            } 
            catch { }
            return isSuccess;
        }
        #endregion

        #region "[Lấy danh sách các đối tượng đơn hàng theo cửa hàng]"
        /// <summary>
        /// Lấy danh sách các đối tượng đơn hàngtheo cửa hàng
        /// </summary>
        /// <param name="_iStatusID">Mã tình trạng</param>
        /// <param name="_iStoreID">Mã cửa hàng</param>
        /// <returns></returns>
        public static List<Order> GetAllToListByStoreID(int _iStoreID,int _iStatusID)
        {
            List<Order> orders = new List<Order>();
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                orders = context.Order_Get_ListByStore(_iStoreID, _iStatusID).ToList<Order>();

            }
            catch { }
            return orders;
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
            Order objResult = null;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                objResult = context.Order_GetByOrderId(_iOrderID).First<Order>();
            }
            catch { }
            return objResult;
        }
        #endregion

        #region "[Lấy danh sách các đơn hàng thuộc về 1 khách hàng-sắp xếp giảm dần theo thời gian]"
        /// <summary>
        /// Lấy danh sách các đơn hàng thuộc về 1 khách hàng-sắp xếp giảm dần theo thời gian
        /// </summary>
        /// <param name="_iUserID">mã người dùng</param>
        /// <param name="_iStatusID">Tình trạng</param>
        /// <returns></returns>
        public static List<Order> SelectByUserID(int _iUserID,int _iStatusID)
        {
            List<Order> orders = new List<Order>();
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                orders = context.Order_Get_ListByUser(_iUserID, _iStatusID).ToList<Order>();
            }
            catch { }
            return orders;
        }
        #endregion
    }
}
