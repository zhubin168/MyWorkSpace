using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using Dafy.OnlineTran.Common.Response;
using Dafy.OnlineTran.IService.Pc;
using Dafy.OnlineTran.Common.Request;
using System.Collections.Generic;
using System.Web;
using System.Collections;
using Swashbuckle.Swagger;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Globalization;

namespace Dafy.OnlineTran.Api.Controllers
{
    /// <summary>
    /// 公共接口管理
    /// 创建人：朱斌
    /// 创建时间：2017-05-05
    /// </summary>
    [AllowAnonymous]
    public class CommonController : ApiController
    {
        private static readonly string picsPath = "doc/pics";
        private static readonly string attachmentsPath = "doc/attachments";

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ResultModel<string> UploadImg()
        {
            #region 多个文件上传
            bool success = false;
            string msg = "";
            string filePath = "";
            HttpFileCollection files = HttpContext.Current.Request.Files;
            List<string> lstfilePath = new List<string>();
            foreach (string key in files.AllKeys)
            {
                HttpPostedFile file = files[key];
                string ext = System.IO.Path.GetExtension(file.FileName).ToLower();
                if (CheckUploadFileType(ext))
                {
                    if (file.ContentLength > 5 * 1024 * 1024)
                    {
                        msg = "上传的文件大小最大为5M！";
                    }
                    else
                    {
                        string fileName = Guid.NewGuid().ToString("N") + ext;
                        if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, picsPath)))
                        {
                            Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, picsPath));
                        }
                        //物理路径
                        filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, picsPath, fileName);
                        file.SaveAs(filePath);
                        //虚拟路径
                        filePath =Path.Combine(HttpContext.Current.Request.Url.Authority, picsPath, fileName);
                        lstfilePath.Add(filePath);
                        success = true;
                    }
                }
                else
                {
                    msg = "请上传正确的文件类型(.jpg .jpeg .gif .png .bmp)";
                    break;
                }
            }
            return new ResultModel<string>
            {
                state =success?1:0,
                message = msg,
                data = string.Join(",", lstfilePath.ToArray())
            };
            #endregion
        }

        /// <summary>
        /// 上传附件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ResultModel<string> UploadDoc()
        {
            #region 多个文件上传
            bool success = false;
            string msg = "";
            string filePath = "";
            HttpFileCollection files = HttpContext.Current.Request.Files;
            List<string> lstfilePath = new List<string>();
            foreach (string key in files.AllKeys)
            {
                HttpPostedFile file = files[key];
                string ext = System.IO.Path.GetExtension(file.FileName).ToLower();
                if (file.ContentLength > 50 * 1024 * 1024)
                {
                    msg = "上传的文件大小最大为50M！";
                }
                else
                {
                    string fileName = Guid.NewGuid().ToString("N") + ext;
                    if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, attachmentsPath)))
                    {
                        Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, attachmentsPath));
                    }
                    //物理路径
                    filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, attachmentsPath, fileName);
                    file.SaveAs(filePath);
                    //虚拟路径
                    filePath = Path.Combine(HttpContext.Current.Request.Url.Authority, attachmentsPath, fileName);
                    lstfilePath.Add(filePath);
                    success = true;
                }
            }
            return new ResultModel<string>
            {
                state = success?1:0,
                message = msg,
                data = string.Join(",", lstfilePath.ToArray())
            };
            #endregion
        }

        /// <summary>
        /// 检验文件类型
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        private bool CheckUploadFileType(string fileName)
        {
            List<string> fileTypeList = new List<string>() { ".jpg", ".jpeg", ".gif", ".png", ".bmp" };
            string extension = fileName.Substring(fileName.LastIndexOf('.')).ToLower();
            if (fileTypeList.Contains(extension))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
