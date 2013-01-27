using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapstoneProjectCore.DAO;

namespace CapstoneProjectCore.BUS
{
    public class FollowBUS
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng Follow
        /// </summary>
        /// <param name="_obj">đối tượng Follow cần thêm</param>
        /// <returns></returns>
        public static Follow Insert(Follow _obj)
        {
            return FollowDAO.Insert(_obj);
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
            return FollowDAO.Delete(_iFollowForm, _iFollowTo);
        }
        #endregion

        #region "[Get List Folower]"
        /// <summary>
        /// Lấy danh sách Follower
        /// </summary>
        /// <param name="_iUserID">Mã FollerForm</param>
        /// <returns></returns>
        public static List<Follow> GetListFollower(int _iFollowID, int _iTypeID)
        {
            return FollowDAO.GetListFollower(_iFollowID, _iTypeID);
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
            return FollowDAO.GetListFollowing(_iFollowID, _iTypeID);
        }
        #endregion
    }
}
