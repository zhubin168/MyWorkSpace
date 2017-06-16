using GiveU.Infrastructure.Utility;
using System.Configuration;

namespace Dafy.OnlineTran.Common
{
    /// <summary>
    /// 发生手机短息的帮助类
    /// </summary>
    public class SMSHelper
    {
        /// <summary>
        /// 短信发送
        /// </summary>
        public static bool Send(string msg, params string[] phoneList)
        {
            if (string.IsNullOrWhiteSpace(msg) || phoneList == null || phoneList.Length == 0) return false;

            var sendUrl = ConfigurationManager.AppSettings["SmsSendUrl"] ?? "";
            var userName = ConfigurationManager.AppSettings["UserName"] ?? "";
            if (string.IsNullOrWhiteSpace(sendUrl) || string.IsNullOrWhiteSpace(userName)) return false;

            var client = HttpClientProvider.CreateHttpClient(sendUrl);
            var resp = client.GetAsync(string.Format("?username={0}&mobile={1}&content={2}&sendtime=", userName, string.Join(",", phoneList), msg)).Result;
            return resp.IsSuccessStatusCode && resp.Content.ReadAsStringAsync().Result.Contains("ok");
        }
    }
}
