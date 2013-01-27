using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapstoneProjectCore.DAO;

namespace CapstoneProjectCore.BUS
{
    public class AccountBUS
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng người dùng
        /// </summary>
        /// <param name="_obj">đối tượng người dùng cần thêm</param>
        /// <returns></returns>
        public static Account Insert(Account _obj)
        {
            return AccountDAO.Insert(_obj);
        }
        #endregion

        #region "[Delete]"
        /// <summary>
        /// xóa 1 đối tượng người dùng
        /// </summary>
        /// <param name="_iUserID">mã đối tượng người dùng</param>
        /// <returns></returns>
        public static bool Delete(int _iUserID)
        {
            return AccountDAO.Delete(_iUserID);
        }
        #endregion

        #region "[Update]"
        /// <summary>
        /// cập nhật 1 đối tượng người dùng
        /// </summary>
        /// <param name="_obj">đối tượng người dùng cần cập nhật</param>
        /// <returns></returns>
        public static bool Update(Account _obj)
        {
            return AccountDAO.Update(_obj);
        }
        #endregion

        #region "[Login]"
        /// <summary>
        /// chức năng đăng nhập
        /// </summary>
        /// <param name="_strTelLogin">số điện thoại đăng nhập</param>
        /// <param name="_strPass">mật khẩu</param>
        /// <returns></returns>
        public static Account Login(string _strEMailLogin, string _strPass)
        {
            return AccountDAO.Login(_strEMailLogin, _strPass);
        }
        #endregion
    }
}
