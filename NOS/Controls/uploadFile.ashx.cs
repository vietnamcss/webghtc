using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace NOS.Controls
{
    /// <summary>
    /// Summary description for uploadFile
    /// </summary>
    public class uploadFile : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string msg_Response = "";
            try
            {
                var _path = context.Request["_path"];
                string FileName = "";
                string folderPath = context.Server.MapPath(_path);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                if (context.Request.Files.Count > 0)
                {
                    HttpFileCollection files = context.Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = files[i];
                        string ext = System.IO.Path.GetExtension(file.FileName);

                        int fileSize = file.ContentLength;
                        if (fileSize > 26250000)
                        {
                            msg_Response = "Dung lượng file quá lớn yêu cầu file nhỏ hơn " + 2 + "MB";
                        }
                        else
                        {
                            if (IsExtension(ext))
                            {
                                Guid id = Guid.NewGuid();
                                FileName = id + "." + ext;
                                string fName = context.Server.MapPath(_path + FileName);
                                file.SaveAs(fName);
                                msg_Response = _path + FileName;
                            }
                            else
                            {
                                msg_Response = "ERR: Không đúng định dạng ảnh!";
                            }
                        }
                    }
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(msg_Response);
                }
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "text/plain";
                msg_Response = "ERR:" + ex.Message;
                context.Response.Write(msg_Response);
            }
        }
        public bool IsExtension(string ext)
        {
            bool isValidFile = false;
            string[] validFileTypes = { "png", "PNG", "jpg", "JPG" };
            for (int i = 0; i < validFileTypes.Length; i++)
            {
                if (ext == "." + validFileTypes[i])
                {
                    isValidFile = true;
                    break;
                }
            }
            return isValidFile;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}