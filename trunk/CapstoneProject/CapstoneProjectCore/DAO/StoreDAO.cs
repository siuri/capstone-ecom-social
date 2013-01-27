using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapstoneProjectCore.DAO
{
    public class StoreDAO
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng Store
        /// </summary>
        /// <param name="_obj">Store cần thêm </param>
        /// <returns></returns>
        public static bool Insert(Store _obj)
        {
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.Store_Insert(_obj.StoreID,_obj.StoreName,_obj.Address,_obj.Description,_obj.CreateDate,_obj.StatusID,_obj.Slogan,_obj.ImageProfileID,_obj.ImageCoverID,_obj.ShipFee,_obj.TotalFllowers,_obj.TotalFllowing,_obj.Tel);
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
        public static bool Delete(int _iStoreID)
        {
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.Store_Delete(_iStoreID);
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
        public static bool Update(Store _obj)
        {
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.Store_Update(_obj.StoreID,_obj.StoreName,_obj.Address,_obj.Description,_obj.CreateDate,_obj.StatusID,_obj.Slogan,_obj.ImageProfileID,_obj.ImageCoverID,_obj.ShipFee,_obj.TotalFllowers,_obj.TotalFllowing,_obj.Tel);
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
        public static Store GetByUserByStoreID(int _obj)
        {
            Store _user = new Store();
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                _user = context.Store_GetByStoreId(_obj).First<Store>();

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
        public static List<Store> GetByUserTypeId(int _obj)
        {
            List<Store> _user = new List<Store>();
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                _user = context.Store_GetByStatusId(_obj).ToList<Store>();

            }
            catch { }
            return _user;
        }
        #endregion
    }
}
