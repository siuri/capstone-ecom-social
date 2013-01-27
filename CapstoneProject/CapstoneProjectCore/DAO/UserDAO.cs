using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapstoneProjectCore.DAO
{
    public class UserDAO
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng user
        /// </summary>
        /// <param name="_obj">User cần thêm </param>
        /// <returns></returns>
        public static bool Insert(User _obj)
        {
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.User_Insert(_obj.UserID, _obj.FirstName, _obj.LastName, _obj.About, _obj.ImageAvartarID, _obj.Address, _obj.UserTypeID, _obj.Isdelete, _obj.TotalFllowers, _obj.TotalFllowing, _obj.TotalLikes);
                return true;
            }
            catch { }
            return false;
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
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.User_Delete(_iUserID);

                isSuccess = true;
            }
            catch { }
            return isSuccess;
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
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.User_Update(_obj.UserID, _obj.FirstName, _obj.LastName, _obj.About, _obj.ImageAvartarID, _obj.Address, _obj.UserTypeID, _obj.Isdelete, _obj.TotalFllowers, _obj.TotalFllowing, _obj.TotalLikes);
                isSuccess = true;
            }
            catch { }
            return isSuccess;
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
            User _user = new User();
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                _user = context.User_GetByUserId(_obj).First<User>();
              
            }
            catch { }
            return _user;
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
            List<User> _user = new List<User>();
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                _user = context.User_GetByUserTypeId(_obj).ToList<User>();

            }
            catch { }
            return _user;
        }
        #endregion

    }
}
