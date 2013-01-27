using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapstoneProjectCore.DAO;

namespace CapstoneProjectCore.BUS
{
    public class UserTypeBUS
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng loại user
        /// </summary>
        /// <param name="_obj">tình trạng hóa đơn cần thêm </param>
        /// <returns></returns>
        public static UserType Insert(UserType _obj)
        {
            return UserTypeDAO.Insert(_obj);
        }
        #endregion

        #region "[Delete]"
        /// <summary>
        /// xóa 1 đối tượng loại user
        /// </summary>
        /// <param name="_iImageID">mã đối tượng  cần xóa</param>
        /// <returns></returns>
        public static bool Delete(int _iTypeID)
        {
            return UserTypeDAO.Delete(_iTypeID);
        }
        #endregion

        #region "[Update]"
        /// <summary>
        /// cập nhật 1 đối tượng tình trạng
        /// </summary>
        /// <param name="_obj">đối tượng cần  cập nhật</param>
        /// <returns></returns>
        public static bool Update(UserType _obj)
        {
            return UserTypeDAO.Update(_obj);
        }
        #endregion

        #region "[Lấy 1 đối tượng loại người dùng]"
        /// <summary>
        /// Lấy 1 đối tượng loai người dùng
        /// </summary>
        /// <param name="_iImageID"></param>
        /// <returns></returns>
        public static UserType SelectByImageID(int _iUserTypeID)
        {
            return UserTypeDAO.SelectByImageID(_iUserTypeID);
        }
        #endregion

        #region "[Lấy danh sách đối tượng loại người dùng]"
        /// <summary>
        /// Lấy  danh sách đối tượng loại người dùng
        /// </summary>
        /// <returns></returns>
        public static List<UserType> SelectByImageID()
        {
            return UserTypeDAO.SelectByImageID();
        }
        #endregion

    }
}
