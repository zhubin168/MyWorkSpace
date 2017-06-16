using Dafy.OnlineTran.Common.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Dafy.OnlineTran.Common.Helpers
{
    /// <summary>
    /// 文件处理帮助类
    /// 创建人：朱斌
    /// 创建时间：2016-12-01
    /// </summary>
    public static class FileHelper
    {
        public static readonly string strUploadPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "/template/built");
        /// <summary>
        /// 上传Excel公共方法
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public static ResultModel<string> UploadFile(HttpFileCollection files)
        {
            HttpPostedFile file = files[0];
            string apiFileName = string.Empty;
            var strWarningMessage = new StringBuilder();
            var uploadedFilePath = string.Empty;
            if (file != null && file.ContentLength > 0)
            {
                //判断文件大小（最大10M）
                if (file.ContentLength > 10 * 1024 * 1024)
                {
                    strWarningMessage.AppendLine("上传的文件大小最大为10M！");
                    return new ResultModel<string>()
                    {
                        message = strWarningMessage.ToString(),
                        state = 0
                    };
                }
                apiFileName = file.FileName;
                //判断文件名字是否包含路径名，如果有则提取文件名
                if (apiFileName.LastIndexOf("\\") > -1)
                {
                    apiFileName = apiFileName.Substring(apiFileName.LastIndexOf("\\") + 1);
                }
                //判断文件格式
                if (apiFileName.LastIndexOf('.') > -1 && CheckUploadFileType(apiFileName))
                {
                    string strInnerPath = strUploadPath;
                    if (!Directory.Exists(strInnerPath))
                    {
                        Directory.CreateDirectory(strInnerPath);
                    }
                    //重命名文件
                    string guid = Guid.NewGuid().ToString();
                    string[] names = file.FileName.Split('.');
                    apiFileName = guid + "." + names[names.Length - 1];

                    uploadedFilePath = strUploadPath + apiFileName;
                    string tempFilePath = strInnerPath + apiFileName;
                    if (File.Exists(tempFilePath))
                    {
                        strWarningMessage.AppendLine("您上传的文件名已存在，请更换名称！");
                        return new ResultModel<string>()
                        {
                            message = strWarningMessage.ToString(),
                            state = 0
                        };
                    }
                    else
                    {
                        try
                        {
                            //1.上传Excel到服务器 
                            file.SaveAs(tempFilePath);
                            return new ResultModel<string>()
                            {
                                message = "导入成功！",
                                state = 1,
                                data = tempFilePath
                            };
                        }
                        catch (Exception e)
                        {
                            strWarningMessage.AppendLine("上传失败！失败原因：" + e.Message);
                            uploadedFilePath = string.Empty;
                            return new ResultModel<string>()
                            {
                                message = strWarningMessage.ToString(),
                                state = 0
                            };
                        }
                    }
                }
                else
                {
                    strWarningMessage.AppendLine("上传文件的格式不符合要求！");
                    return new ResultModel<string>()
                    {
                        message = strWarningMessage.ToString(),
                        state = 0
                    };
                }
            }
            else
            {
                if (string.IsNullOrEmpty(file.FileName))
                {
                    strWarningMessage.AppendLine("请选择要上传的文件！");
                }
                else
                {
                    strWarningMessage.AppendLine("上传的文件是空文件！");
                }
                return new ResultModel<string>()
                {
                    message = strWarningMessage.ToString(),
                    state = 0
                };
            }
        }


        /// <summary>
        /// 检验文件类型
        /// 创建人：朱斌
        /// 创建时间：2016-02-23 
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        private static bool CheckUploadFileType(string fileName)
        {
            List<string> fileTypeList = new List<string>() { ".XLS", ".XLSX", ".CSV" };
            string extension = fileName.Substring(fileName.LastIndexOf('.')).ToUpper();
            if (fileTypeList.Contains(extension))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 删除服务器文件夹下的文档
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteDocInFolder(string logAPI)
        {
            //获取物理存储文件夹位置
            string dir = strUploadPath;
            string delname1 = logAPI.Substring(logAPI.LastIndexOf("/") + 1);
            DeleteFolder(dir, delname1);
        }

        /// <summary>
        /// 删除指定文件夹下的文件
        /// 创建人：朱斌
        /// </summary>
        /// <param name="dir">目录</param>
        /// <param name="delname">文件名</param>
        public static void DeleteFolder(string dir, string delname)
        {
            if (Directory.Exists(dir))
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    string tmpd = d.Substring(0, d.Replace("/", @"\").LastIndexOf(@"\")) + @"\" + delname;
                    if (Directory.Exists(d))
                    {
                        if (d == tmpd)
                            Directory.Delete(d, true);
                        else
                            DeleteFolder(d, delname);//递归删除子文件夹   
                    }
                    else if (System.IO.File.Exists(d))
                    {
                        if (d == tmpd)
                            System.IO.File.Delete(d);
                    }
                }
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileBytes"></param>
        /// <param name="destinationPath"></param>
        /// <param name="emsg"></param>
        /// <returns></returns>
        public static bool SaveFile(byte[] fileBytes, string destinationPath, out string emsg)
        {
            emsg = "";
            try
            {
                using (var fsWrite = new FileStream(destinationPath, FileMode.Append))
                {
                    fsWrite.Write(fileBytes, 0, fileBytes.Length);
                }
                ;
            }
            catch (Exception ex)
            {
                emsg = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 文件文件路径，生成二进制文件流
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static byte[] GetFileBytes(string filePath)
        {
            using (var fsRead = new FileStream(filePath, FileMode.Open))
            {
                var fsLen = (int)fsRead.Length;
                var fileByte = new byte[fsLen];
                fsRead.Read(fileByte, 0, fileByte.Length);
                return fileByte;
            }
        }

        public static string GetFileFolder(string fileType, string serverPath)
        {
            //根据文件类型获取文件夹
            var fileFolder = GetAppConfig(fileType.ToLower());
            fileFolder = @"/" + fileFolder + @"/" + DateTime.Now.Year.ToString() +
                         DateTime.Now.Month.ToString() + @"/" + DateTime.Now.Day.ToString();
            if (!Directory.Exists(serverPath + @"/" + fileFolder))
                Directory.CreateDirectory(serverPath + @"/" + fileFolder);
            return fileFolder;
        }

        private static string GetAppConfig(string key)
        {
            return ConfigurationManager.AppSettings[key] ?? ConfigurationManager.AppSettings[key];
        }
    }
}
