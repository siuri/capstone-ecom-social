using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapstoneProjectCore.DAO
{
    public class StatusProductDAO
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng tình trạng hóa đơn
        /// </summary>
        /// <param name="_obj">tình trạng hóa đơn cần thêm </param>
        /// <returns></returns>
        public static StatusProduct Insert(StatusProduct _obj)
        {
            StatusProduct result = null;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                result = context.StatusProduct_Insert(_obj.StatusName, _obj.Description, _obj.IsDelete).First<StatusProduct>();

            }
            catch { }
            return result;
        }
        #endregion

        #region "[Delete]"
        /// <summary>
        /// xóa 1 đối tượng tình trạng hóa đơn
        /// </summary>
        /// <param name="_iImageID">mã đối tượng  cần xóa</param>
        /// <returns></returns>
        public static bool Delete(int _iStatusID)
        {
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.StatusProduct_Delete(_iStatusID);

                isSuccess = true;
            }
            catch { }
            return isSuccess;
        }
        #endregion

        #region "[Update]"
        /// <summary>
        /// cập nhật 1 đối tượng tình trạng hóa đơn
        /// </summary>
        /// <param name="_obj">đối tượng cần  cập nhật</param>
        /// <returns></returns>
        public static bool Update(StatusProduct _obj)
        {
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.StatusProduct_Update(_obj.StatusID, _obj.StatusName, _obj.Description, _obj.IsDelete);
                isSuccess = true;
            }
            catch { }
            return isSuccess;
        }
        #endregion

        #region "[Lấy 1 đối tượng tình trạng sản phẩm]"
        /// <summary>
        /// Lấy 1 đối tượng tình trạng sản phẩm
        /// </summary>
        /// <param name="_iImageID"></param>
        /// <returns></returns>
        public static StatusProduct SelectByImageID(int _iStatusID)
        {
            StatusProduct objResult = null;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                objResult = context.StatusProduct_GetByStatusId(_iStatusID).First<StatusProduct>();
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
        public static List<StatusProduct> SelectListAll()
        {
            List<StatusProduct> objResult = new List<StatusProduct>();
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                objResult = context.StatusProduct_Get_List().ToList<StatusProduct>();
            }
            catch { }
            return objResult;
        }
        #endregion
    }
}
