using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapstoneProjectCore.DAO;

namespace CapstoneProjectCore.BUS
{
    public class StatusOrderBUS
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng tình trạng hóa đơn
        /// </summary>
        /// <param name="_obj">tình trạng hóa đơn cần thêm </param>
        /// <returns></returns>
        public static StatusOrder Insert(StatusOrder _obj)
        {
            return StatusOrderDAO.Insert(_obj);
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
            return StatusOrderDAO.Delete(_iStatusOrderID);
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
            return StatusOrderDAO.Update(_obj);
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
            return StatusOrderDAO.SelectByImageID(_iStatusID);
        }
        #endregion

        #region "[Lấy danh sách đối tượng tình trạng hóa đơn]"
        /// <summary>
        /// Lấy  danh sách đối tượng tình trạng hóa đơn
        /// </summary>
        /// <returns></returns>
        public static List<StatusOrder> SelectByImageID()
        {
            return StatusOrderDAO.SelectByImageID();
        }
        #endregion
    }
}
