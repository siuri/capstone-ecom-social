using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapstoneProjectCore.DAO;

namespace CapstoneProjectCore.BUS
{
    public class StatusStoreBUS
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng tình trạng hóa đơn
        /// </summary>
        /// <param name="_obj">tình trạng hóa đơn cần thêm </param>
        /// <returns></returns>
        public static StatusStore Insert(StatusStore _obj)
        {
            return StatusStoreDAO.Insert(_obj);
        }
        #endregion

        #region "[Delete]"
        /// <summary>
        /// xóa 1 đối tượng tình trạng 
        /// </summary>
        /// <param name="_iImageID">mã đối tượng  cần xóa</param>
        /// <returns></returns>
        public static bool Delete(int _iStatusID)
        {
            return StatusStoreDAO.Delete(_iStatusID);
        }
        #endregion

        #region "[Update]"
        /// <summary>
        /// cập nhật 1 đối tượng tình trạng
        /// </summary>
        /// <param name="_obj">đối tượng cần  cập nhật</param>
        /// <returns></returns>
        public static bool Update(StatusStore _obj)
        {
            return StatusStoreDAO.Update(_obj);
        }
        #endregion

        #region "[Lấy 1 đối tượng tình trạng sản phẩm]"
        /// <summary>
        /// Lấy 1 đối tượng tình trạng 
        /// </summary>
        /// <param name="_iImageID"></param>
        /// <returns></returns>
        public static StatusStore SelectByImageID(int _iStatusID)
        {
            return StatusStoreDAO.SelectByImageID(_iStatusID);
        }
        #endregion

        #region "[Lấy danh sách đối tượng tình trạng sản phẩm]"
        /// <summary>
        /// Lấy  danh sách đối tượng tình trạng sản phẩm
        /// </summary>
        /// <returns></returns>
        public static List<StatusStore> SelectByImageID()
        {
            return StatusStoreDAO.SelectByImageID();
        }
        #endregion
    }
}
