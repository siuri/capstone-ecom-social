using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapstoneProjectCore.DAO;

namespace CapstoneProjectCore.BUS
{
    public class StoreBUS
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng Store
        /// </summary>
        /// <param name="_obj">Store cần thêm </param>
        /// <returns></returns>
        public static bool Insert(Store _obj)
        {
            return StoreDAO.Insert(_obj);
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
            return StoreDAO.Delete(_iStoreID);
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
            return StoreDAO.Update(_obj);
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
            return StoreDAO.GetByUserByStoreID(_obj);
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
            return StoreDAO.GetByUserTypeId(_obj);
        }
        #endregion
    }
}
