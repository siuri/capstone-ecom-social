using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapstoneProjectCore.DAO
{
    public class StatusStoreDAO
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng tình trạng hóa đơn
        /// </summary>
        /// <param name="_obj">tình trạng hóa đơn cần thêm </param>
        /// <returns></returns>
        public static StatusStore Insert(StatusStore _obj)
        {
            StatusStore result = null;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                result = context.StatusStore_Insert(_obj.StatusName, _obj.Description, _obj.IsDelete).First<StatusStore>();

            }
            catch { }
            return result;
        }
        #endregion

        #region "[Delete]"
        /// <summary>
        /// xóa 1 đối tượng tình trạng 
        /// </summary>
        /// <param name="_iImageID">mã đối tượng  cần xóa</param>
        /// <returns></returns>
        public static bool Delete(int _iStatusID)
        {
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.StatusStore_Delete(_iStatusID);

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
        public static bool Update(StatusStore _obj)
        {
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.StatusStore_Update(_obj.StatusID, _obj.StatusName, _obj.Description, _obj.IsDelete);
                isSuccess = true;
            }
            catch { }
            return isSuccess;
        }
        #endregion

        #region "[Lấy 1 đối tượng tình trạng sản phẩm]"
        /// <summary>
        /// Lấy 1 đối tượng tình trạng 
        /// </summary>
        /// <param name="_iImageID"></param>
        /// <returns></returns>
        public static StatusStore SelectByImageID(int _iStatusID)
        {
            StatusStore objResult = null;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                objResult = context.StatusStore_GetByStatusId(_iStatusID).First<StatusStore>();
            }
            catch { }
            return objResult;
        }
        #endregion

        #region "[Lấy danh sách đối tượng tình trạng sản phẩm]"
        /// <summary>
        /// Lấy  danh sách đối tượng tình trạng sản phẩm
        /// </summary>
        /// <returns></returns>
        public static List<StatusStore> SelectByImageID()
        {
            List<StatusStore> objResult = new List<StatusStore>();
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                objResult = context.StatusStore_Get_List().ToList<StatusStore>();
            }
            catch { }
            return objResult;
        }
        #endregion
    }
}
