using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapstoneProjectCore.DAO
{
    public class FollowDAO
    {


        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng Follow
        /// </summary>
        /// <param name="_obj">đối tượng Follow cần thêm</param>
        /// <returns></returns>
        public static Follow Insert(Follow _obj)
        {
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.Follow_Insert(_obj.FollowIDFrom,_obj.FollowIDTo,_obj.FollowType);
            }
            catch { }
            return _obj;
        }
        #endregion

        #region "[Delete]"
        /// <summary>
        /// xóa 1 đối tượng Follow
        /// </summary>
        /// <param name="_iUserID">mã đối tượng Follow</param>
        /// <returns></returns>
        public static bool Delete(int _iFollowForm, int _iFollowTo)
        {
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.Follow_Delete(_iFollowForm, _iFollowTo);
            }
            catch { }
            return isSuccess;
        }
        #endregion

        #region "[Get List Folower]"
        /// <summary>
        /// Lấy danh sách Follower
        /// </summary>
        /// <param name="_iUserID">Mã FollerForm</param>
        /// <returns></returns>
        public static List<Follow> GetListFollower(int _iFollowID,int _iTypeID)
        {
            List<Follow> list = new List<Follow>();
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.Follow_Get_List_Follower(_iFollowID, _iTypeID).ToList<Follow>();
            }
            catch { }
            return list;
        }
        #endregion

        #region "[Get List Folowing]"
        /// <summary>
        /// Lấy danh sách Follower
        /// </summary>
        /// <param name="_iUserID">Mã FollerForm</param>
        /// <returns></returns>
        public static List<Follow> GetListFollowing(int _iFollowID, int _iTypeID)
        {
            List<Follow> list = new List<Follow>();
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.Follow_Get_List_Following(_iFollowID, _iTypeID).ToList<Follow>();
            }
            catch { }
            return list;
        }
        #endregion
    }
}
