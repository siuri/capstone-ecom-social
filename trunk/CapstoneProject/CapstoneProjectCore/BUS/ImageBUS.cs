using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapstoneProjectCore.DAO;

namespace CapstoneProjectCore.BUS
{
    public class ImageBUS
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng Hình
        /// </summary>
        /// <param name="_obj">đối tượng Hình cần thêm</param>
        /// <returns></returns>
        public static int Insert(Image _obj)
        {
            return ImageDAO.Insert(_obj);
        }
        #endregion

        #region "[Delete]"
        /// <summary>
        /// xóa 1 đối tượng Hình
        /// </summary>
        /// <param name="_iImageID">mã đối tượng Hình cần xóa</param>
        /// <returns></returns>
        public static bool Delete(int _iImageID)
        {
            return ImageDAO.Delete(_iImageID);
        }
        #endregion

        #region "[Update]"
        /// <summary>
        /// cập nhật 1 đối tượng Hình
        /// </summary>
        /// <param name="_obj">đối tượng Hình cần cập nhật</param>
        /// <returns></returns>
        public static bool Update(Image _obj)
        {
            return ImageDAO.Update(_obj);
        }
        #endregion

        #region "[Lấy 1 đối tượng Hình]"
        /// <summary>
        /// Lấy 1 đối tượng Hình
        /// </summary>
        /// <param name="_iImageID"></param>
        /// <returns></returns>
        public static Image SelectByImageID(int _iImageID)
        {
            return ImageDAO.SelectByImageID(_iImageID);
        }
        #endregion
    }
}
