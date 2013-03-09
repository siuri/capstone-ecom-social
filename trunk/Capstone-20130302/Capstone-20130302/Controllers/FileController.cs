using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Capstone_20130302.Models;
using System.Web.Script.Serialization;


namespace Capstone_20130302.Controllers
{
    public class FileController : ApiController
    {
        public async Task<HttpResponseMessage> PostImage()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data/Images");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                StringBuilder sb = new StringBuilder(); // Holds the response body

                // Read the form data and return an async task.
                await Request.Content.ReadAsMultipartAsync(provider);

                //// This illustrates how to get the form data.
                //foreach (var key in provider.FormData.AllKeys)
                //{
                //    foreach (var val in provider.FormData.GetValues(key))
                //    {
                //        sb.Append(string.Format("{0}: {1}\n", key, val));
                //    }
                //}
                using (var ct = new SocialBuyContext())
                {

                    // This illustrates how to get the file names for uploaded files.
                    foreach (var file in provider.FileData)
                    {
                        FileInfo fileInfo = new FileInfo(file.LocalFileName);
                        var img = new Image { Path = fileInfo.Name };
                        ct.Images.Add(img);
                    }
                    ct.SaveChanges();
                }
                var status = new Dictionary<string, string>
                {
                    { "status", "OK" }
                };
                var serializer = new JavaScriptSerializer();

                var statusJson = serializer.Serialize(status);

                return Request.CreateResponse(HttpStatusCode.OK, statusJson, Configuration.Formatters.JsonFormatter);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
