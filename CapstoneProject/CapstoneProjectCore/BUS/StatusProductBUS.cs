using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapstoneProjectCore.DAO;

namespace CapstoneProjectCore.BUS
{
    public class StatusProductBUS
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng tình trạng hóa đơn
        /// </summary>
        /// <param name="_obj">tình trạng hóa đơn cần thêm </param>
        /// <returns></returns>
        public static StatusProduct Insert(StatusProduct _obj)
        {
            return StatusProductDAO.Insert(_obj);
        }
        #endregion

        #region "[Delete]"
        /// <summary>
        /// xóa 1 đối tượng tình trạng hóa đơn
        /// </summary>
        /// <param name="_iImageID">mã đối tượng  cần xóa</param>
        /// <returns></returns>
        public static bool Delete(int _iStatusID)
        {
            return StatusProductDAO.Delete(_iStatusID);
        }
        #endregion

        #region "[Update]"
        /// <summary>
        /// cập nhật 1 đối tượng tình trạng hóa đơn
        /// </summary>
        /// <param name="_obj">đối tượng cần  cập nhật</param>
        /// <returns></returns>
        public static bool Update(StatusProduct _obj)
        {
            return StatusProductDAO.Update(_obj);
        }
        #endregion

        #region "[Lấy 1 đối tượng tình trạng sản phẩm]"
        /// <summary>
        /// Lấy 1 đối tượng tình trạng sản phẩm
        /// </summary>
        /// <param name="_iImageID"></param>
        /// <returns></returns>
        public static StatusProduct SelectByImageID(int _iStatusID)
        {
            return StatusProductDAO.SelectByImageID(_iStatusID);
        }
        #endregion

        #region "[Lấy danh sách đối tượng tình trạng sản phẩm]"
        /// <summary>
        /// Lấy  danh sách đối tượng tình trạng sản phẩm
        /// </summary>
        /// <returns></returns>
        public static List<StatusProduct> SelectListAll()
        {
            return StatusProductDAO.SelectListAll();
        }
        #endregion
    }
}
