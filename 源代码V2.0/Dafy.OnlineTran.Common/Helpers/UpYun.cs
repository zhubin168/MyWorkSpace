using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Helpers
{
    public class UpYun
    {
        private string bucketname;
        private string username;
        private string password;
        private bool upAuth = false;
        private string api_domain = "v0.api.upyun.com";
        private string DL = "/";
        private Hashtable tmp_infos = new Hashtable();
        private string file_secret;
        private string content_md5;
        private bool auto_mkdir = false;
        public string version() { return "1.0.1"; }

        #region 解压
        private static readonly Encoding Endcoding = Encoding.UTF8;
        private HttpWebResponse ZipHttpWebResponse(string fileName, string unzip ,string method, string Url, string postData, Hashtable headers)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);

            byte[] bytes = Encoding.Default.GetBytes(postData);
            String signature = getSignature(fileName, unzip);
            request.Headers.Add("Authorization", " UPYUN " + this.username + ":" + signature);
            request.Method = method;



            if (postData != null)
            {
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(bytes, 0, bytes.Length);
                dataStream.Close();
            }
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                var result = response.GetResponseStream();
                this.tmp_infos = new Hashtable();
                foreach (var hl in response.Headers)
                {
                    string name = (string)hl;
                    if (name.Length > 7 && name.Substring(0, 7) == "x-upyun")
                    {
                        this.tmp_infos.Add(name, response.Headers[name]);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return response;
        }
        public bool ZipFile(string fileName, string unzip)
        {
            string postData = "[{\"sources\": \"/"+ fileName+ "\",\"save_as\": \"/" + unzip + "\"}]";  //*********此处填写分别为 需要解压的压缩包名，保存的路径*****************//
            string spostData = "bucket_name="+ this.bucketname + "&app_name=depress&tasks=" + Convert.ToBase64String(Endcoding.GetBytes(postData)) + "&notify_url=http://p0.api.upyun.com/pretreatment/";
            string data = spostData; //********* 上面填写 bucket_name= 后面的值要改为自己的空间名。如果要要压缩文件，则 app_name= 后面的值改为 compress **************************/

            Hashtable headers = new Hashtable();
            HttpWebResponse resp;
            resp = ZipHttpWebResponse(fileName, unzip, "POST", "http://p0.api.upyun.com/pretreatment/", data, headers);
            if ((int)resp.StatusCode == 200)
            {
                resp.Close();
                return true;
            }
            else
            {
                resp.Close();
                return false;
            }
        }

        //private string md5(string str)
        //{
        //    MD5 m = new MD5CryptoServiceProvider();
        //    byte[] s = m.ComputeHash(UnicodeEncoding.UTF8.GetBytes(str));
        //    string resule = BitConverter.ToString(s);
        //    resule = resule.Replace("-", "");
        //    return resule.ToLower();
        //}
        private String getSignature(string fileName, string unzip)
        {
            string postData = "[{\"sources\": \"/" + fileName + "\",\"save_as\": \"/" + unzip + "\"}]";  //*********此处填写分别为 需要解压的压缩包名，保存的路径*****************//

            byte[] bytes = Encoding.Default.GetBytes(postData);
            string tasks = Convert.ToBase64String(bytes);
            String tmp = "";
            String signature = "";

            //***************下面如果要压缩，填写则appname后面改为compress ;  bucket_name  后面填写自己的空间名； *****************************//
            string mid = "app_namedepressbucket_name"+ this.bucketname + "notify_urlhttp://p0.api.upyun.com/pretreatment/tasks" + tasks;
            tmp = this.username + mid + md5(this.password); //**************这里的两个值分别填写操作员账号和操作员密码************/

            signature = md5(tmp);
            return signature;
        }
        #endregion

        /**
        * 初始化 UpYun 存储接口
        * @param $bucketname 空间名称
        * @param $username 操作员名称
        * @param $password 密码
        * return UpYun object
        */
        public UpYun(string bucketname, string username, string password)
        {
            this.bucketname = bucketname;
            this.username = username;
            this.password = password;
        }


        private void upyunAuth(Hashtable headers, string method, string uri, HttpWebRequest request)
        {
            DateTime dt = DateTime.UtcNow;
            string date = dt.ToString("ddd, dd MMM yyyy HH':'mm':'ss 'GMT'", CultureInfo.CreateSpecificCulture("en-US"));
            request.Date = dt;
            //headers.Add("Date", date);
            string auth;
            if (request.ContentLength != -1)
                auth = md5(method + '&' + uri + '&' + date + '&' + request.ContentLength + '&' + md5(this.password));
            else
                auth = md5(method + '&' + uri + '&' + date + '&' + 0 + '&' + md5(this.password));
            headers.Add("Authorization", "UpYun " + this.username + ':' + auth);
        }

        private string md5(string str)
        {
            MD5 m = new MD5CryptoServiceProvider();
            byte[] s = m.ComputeHash(UnicodeEncoding.UTF8.GetBytes(str));
            string resule = BitConverter.ToString(s);
            resule = resule.Replace("-", "");
            return resule.ToLower();
        }
        private bool delete(string path, Hashtable headers)
        {
            HttpWebResponse resp;
            byte[] a = null;
            resp = newWorker("DELETE", DL + this.bucketname + path, a, headers);
            if ((int)resp.StatusCode == 200)
            {
                resp.Close();
                return true;
            }
            else
            {
                resp.Close();
                return false;
            }
        }
        private HttpWebResponse newWorker(string method, string Url, byte[] postData, Hashtable headers)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://" + api_domain + Url);


            request.Method = method;

            if (this.auto_mkdir == true)
            {
                headers.Add("mkdir", "true");
                this.auto_mkdir = false;
            }

            if (postData != null)
            {
                request.ContentLength = postData.Length;
                request.KeepAlive = true;
                if (this.content_md5 != null)
                {
                    request.Headers.Add("Content-MD5", this.content_md5);
                    this.content_md5 = null;
                }
                if (this.file_secret != null)
                {
                    request.Headers.Add("Content-Secret", this.file_secret);
                    this.file_secret = null;
                }
            }

            if (this.upAuth)
            {
                upyunAuth(headers, method, Url, request);
            }
            else
            {
                request.Headers.Add("Authorization", "Basic " +
                    Convert.ToBase64String(new System.Text.ASCIIEncoding().GetBytes(this.username + ":" + this.password)));
            }
            foreach (DictionaryEntry var in headers)
            {
                request.Headers.Add(var.Key.ToString(), var.Value.ToString());
            }

            if (postData != null)
            {
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(postData, 0, postData.Length);
                dataStream.Close();
            }
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                this.tmp_infos = new Hashtable();
                foreach (var hl in response.Headers)
                {
                    string name = (string)hl;
                    if (name.Length > 7 && name.Substring(0, 7) == "x-upyun")
                    {
                        this.tmp_infos.Add(name, response.Headers[name]);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return response;
        }

        /**
        * 获取总体空间的占用信息
        * return 空间占用量，失败返回 null
        */

        public long getFolderUsage(string url)
        {
            Hashtable headers = new Hashtable();
            int size;
            byte[] a = null;
            HttpWebResponse resp = newWorker("GET", DL + this.bucketname + url + "?usage", a, headers);
            try
            {
                StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
                string strhtml = sr.ReadToEnd();
                resp.Close();
                size = strhtml.Length;
            }
            catch (Exception)
            {
                size = 0;
            }
            return size;
        }

        /**
        * 上传文件
        * @param $file 文件路径（包含文件名）
        * @param $datas 文件内容 或 文件IO数据流
        * return true or false
        */
        public bool writeFile(string path, byte[] data, bool auto_mkdir)
        {
            Hashtable headers = new Hashtable();
            this.auto_mkdir = auto_mkdir;
            HttpWebResponse resp;
            resp = newWorker("POST", DL + this.bucketname + path, data, headers);
            if ((int)resp.StatusCode == 200)
            {
                resp.Close();
                return true;
            }
            else
            {
                resp.Close();
                return false;
            }
        }
    }
}
