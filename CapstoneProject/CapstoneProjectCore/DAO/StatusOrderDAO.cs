using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapstoneProjectCore.DAO
{
    public class StatusOrderDAO
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng tình trạng hóa đơn
        /// </summary>
        /// <param name="_obj">tình trạng hóa đơn cần thêm </param>
        /// <returns></returns>
        public static StatusOrder Insert(StatusOrder _obj)
        {
            StatusOrder result = null;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                result = context.StatusOrder_Insert(_obj.StatusName, _obj.Description, _obj.IsDelete).First<StatusOrder>();
               
            }
            catch { }
            return result;
        }
        #endregion

        #region "[Delete]"
        /// <summary>
        /// xóa 1 đối tượng tình trạng hóa đơn
        /// </summary>
        /// <param name="_iImageID">mã đối tượng  cần xóa</param>
        /// <returns></returns>
        public static bool Delete(int _iStatusOrderID)
        {
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.StatusOrder_Delete(_iStatusOrderID);

                isSuccess = true;
            }
            catch { }
            return isSuccess;
        }
        #endregion

        #region "[Update]"
        /// <summary>
        /// cập nhật 1 đối tượng tình trạng hóa đơn
        /// </summary>
        /// <param name="_obj">đối tượng cần  cập nhật</param>
        /// <returns></returns>
        public static bool Update(StatusOrder _obj)
        {
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.StatusOrder_Update(_obj.StatusID,_obj.StatusName, _obj.Description, _obj.IsDelete);
                isSuccess = true;
            }
            catch { }
            return isSuccess;
        }
        #endregion

        #region "[Lấy 1 đối tượng tình trạng hóa đơn]"
        /// <summary>
        /// Lấy 1 đối tượng tình trạng hóa đơn
        /// </summary>
        /// <param name="_iImageID"></param>
        /// <returns></returns>
        public static StatusOrder SelectByImageID(int _iStatusID)
        {
            StatusOrder objResult = null;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                objResult = context.StatusOrder_GetByStatusId(_iStatusID).First<StatusOrder>();
            }
            catch { }
            return objResult;
        }
        #endregion

        #region "[Lấy danh sách đối tượng tình trạng hóa đơn]"
        /// <summary>
        /// Lấy  danh sách đối tượng tình trạng hóa đơn
        /// </summary>
        /// <returns></returns>
        public static List<StatusOrder> SelectByImageID()
        {
            List<StatusOrder> objResult = new List<StatusOrder> ();
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                objResult = context.StatusOrder_Get_List().ToList<StatusOrder>();
            }
            catch { }
            return objResult;
        }
        #endregion

    }
}
