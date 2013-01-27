using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapstoneProjectCore.DAO
{
    public class ImageDAO
    {
        #region "[Insert]"
        /// <summary>
        /// thêm 1 đối tượng Hình
        /// </summary>
        /// <param name="_obj">đối tượng Hình cần thêm</param>
        /// <returns></returns>
        public static int Insert(Image _obj)
        {
            int IDResult = -1;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                Image Obj = context.Image_Insert(_obj.ImageName,_obj.Description,_obj.Path,_obj.IsDelete).First<Image>();
                if (Obj != null)
                    IDResult = Obj.ImageID;
            }
            catch { }
            return IDResult;
        }
        #endregion

        #region "[Delete]"
        /// <summary>
        /// xóa 1 đối tượng Hình
        /// </summary>
        /// <param name="_iImageID">mã đối tượng Hình cần xóa</param>
        /// <returns></returns>
        public static bool Delete(int _iImageID)
        {
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.Image_Delete(_iImageID);

                isSuccess = true;
            }
            catch { }
            return isSuccess;
        }
        #endregion

        #region "[Update]"
        /// <summary>
        /// cập nhật 1 đối tượng Hình
        /// </summary>
        /// <param name="_obj">đối tượng Hình cần cập nhật</param>
        /// <returns></returns>
        public static bool Update(Image _obj)
        {
            bool isSuccess = false;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                context.Image_Update(_obj.ImageID, _obj.ImageName, _obj.Description,_obj.Path, _obj.IsDelete);

                isSuccess = true;
            }
            catch { }
            return isSuccess;
        }
        #endregion

        #region "[Lấy 1 đối tượng Hình]"
        /// <summary>
        /// Lấy 1 đối tượng Hình
        /// </summary>
        /// <param name="_iImageID"></param>
        /// <returns></returns>
        public static Image SelectByImageID(int _iImageID)
        {
            Image objResult = null;
            try
            {
                CapstoneProjectsDataContext context = new CapstoneProjectsDataContext();
                objResult = context.Image_GetByImageId(_iImageID).First<Image>();
            }
            catch { }
            return objResult;
        }
        #endregion

    }
}
