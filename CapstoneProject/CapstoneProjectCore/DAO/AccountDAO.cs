using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapstoneProjectCore.DAO
{
    /// <summary>
    /// Người dùng
    /// </summary>
    public class AccountDAO
    {

        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng người dùng
        /// </summary>
        /// <param name="_obj">đối tượng người dùng cần thêm</param>
        /// <returns></returns>
        public static Account Insert(Account _obj)
        {
            Account Obj = null;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                Obj = context.Account_Insert(_obj.Email,_obj.Password,_obj.AccountType,_obj.LoginTwitter,_obj.LoginFacebook).First<Account>();
            }
            catch { }
            return Obj;
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
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.Account_Delete(_iUserID);
                isSuccess = true;
            }
            catch { }
            return isSuccess;
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
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.Account_Update(_obj.AccountID, _obj.Email, _obj.Password, _obj.AccountType,
                    _obj.LoginTwitter, _obj.LoginFacebook);
                isSuccess = true;
            }
            catch { }
            return isSuccess;
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
            Account userInfo = null;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                userInfo = context.Account_Login(_strEMailLogin.Trim(), _strPass.Trim()).First<Account>();
            }
            catch { }
            return userInfo;
        }
        #endregion


    }
}
