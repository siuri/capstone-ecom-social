using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapstoneProjectCore.DAO
{
    public class UserTypeDAO
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng loại user
        /// </summary>
        /// <param name="_obj">tình trạng hóa đơn cần thêm </param>
        /// <returns></returns>
        public static UserType Insert(UserType _obj)
        {
            UserType result = null;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                result = context.UserType_Insert(_obj.UserTypeName, _obj.Description, _obj.IsDelete).First<UserType>();

            }
            catch { }
            return result;
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
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.UserType_Delete(_iTypeID);

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
        public static bool Update(UserType _obj)
        {
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.StatusStore_Update(_obj.UserTypeID,_obj.UserTypeName, _obj.Description, _obj.IsDelete);
                isSuccess = true;
            }
            catch { }
            return isSuccess;
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
            UserType objResult = null;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                objResult = context.UserType_GetByUserTypeId(_iUserTypeID).First<UserType>();
            }
            catch { }
            return objResult;
        }
        #endregion

        #region "[Lấy danh sách đối tượng loại người dùng]"
        /// <summary>
        /// Lấy  danh sách đối tượng loại người dùng
        /// </summary>
        /// <returns></returns>
        public static List<UserType> SelectByImageID()
        {
            List<UserType> objResult = new List<UserType>();
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                objResult = context.UserType_Get_List().ToList<UserType>();
            }
            catch { }
            return objResult;
        }
        #endregion
    }
}
