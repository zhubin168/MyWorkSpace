using GiveU.Infrastructure.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common
{
    public class DBHelper
    {
        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        public async static Task<string> GetConnectionStr(string project, string deKey, params string[] oauthUrls)
        {
            if(oauthUrls == null || oauthUrls.Length == 0)
            {
                throw new Exception("oauthUrls参数不能为空");
            }
            for (int i = 0; i < oauthUrls.Length; i++)
            {
                var str = oauthUrls[i];
                if (string.IsNullOrWhiteSpace(str)) continue;
                var strCon = await GetConnectionStrInner(str.Trim(), project, deKey);
                if (!string.IsNullOrWhiteSpace(strCon)) return strCon;
            }
            return null;
        }
        /// <summary>
        /// 内部方法
        /// </summary>
        private async static Task<string> GetConnectionStrInner(string oauthUrl, string project, string deKey)
        {
            try
            {
                var client = HttpClientProvider.CreateHttpClient(oauthUrl);
                var resp = await client.GetAsync(string.Format("/api/Config/GetConStr/?project={0}", project));
                if (resp.IsSuccessStatusCode)
                {
                    var resultData = resp.Content.ReadAsByteArrayAsync().Result;
                    if (resultData != null && resultData.Length > 0)
                    {
                        var data = RSAHelper.DecryptData(deKey, resultData);
                        return Encoding.UTF8.GetString(data);
                    }
                }
            }
            catch { }
            return null;
        }
    }
}
