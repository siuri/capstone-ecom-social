using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapstoneProjectCore.DAO;

namespace CapstoneProjectCore.BUS
{
    public class UserBUS
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng user
        /// </summary>
        /// <param name="_obj">User cần thêm </param>
        /// <returns></returns>
        public static bool Insert(User _obj)
        {
            return UserDAO.Insert(_obj);
        }
        #endregion

        #region "[Delete]"
        /// <summary>
        /// xóa 1 đối tượng tình trạng 
        /// </summary>
        /// <param name="_iImageID">mã đối tượng  cần xóa</param>
        /// <returns></returns>
        public static bool Delete(int _iUserID)
        {
            return UserDAO.Delete(_iUserID);
        }
        #endregion

        #region "[Update]"
        /// <summary>
        /// cập nhật 1 đối tượng tình trạng
        /// </summary>
        /// <param name="_obj">đối tượng cần  cập nhật</param>
        /// <returns></returns>
        public static bool Update(User _obj)
        {
            return UserDAO.Update(_obj);
        }
        #endregion

        #region "[Lấy user theo UserID]"
        /// <summary>
        /// Lấy user theo UserID
        /// </summary>
        /// <param name="_obj">UserID</param>
        /// <returns></returns>
        public static User GetByUserByUserID(int _obj)
        {
            return UserDAO.GetByUserByUserID(_obj);
        }
        #endregion

        #region "[Lấy user theo UserTypeID]"
        /// <summary>
        /// Lấy user theo UserID
        /// </summary>
        /// <param name="_obj">UserID</param>
        /// <returns></returns>
        public static List<User> GetByUserTypeId(int _obj)
        {
            return UserDAO.GetByUserTypeId(_obj);
        }
        #endregion
    }
}
