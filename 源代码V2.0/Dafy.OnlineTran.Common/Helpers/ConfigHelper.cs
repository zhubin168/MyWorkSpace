using GiveU.Infrastructure.Utility;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Dafy.OnlineTran.Common
{
    public class ConfigHelper
    {
        static List<string> oauthUrls = new List<string>();
        static string clientId = "";
        static string clientSecret = "";

        static ConfigHelper()
        {
            oauthUrls.Add(ConfigurationManager.AppSettings["UrlOAuthServer"]);
            oauthUrls.Add(ConfigurationManager.AppSettings["UrlOAuthServer2"]);
            oauthUrls.RemoveAll(q => string.IsNullOrWhiteSpace(q));

            clientId = ConfigurationManager.AppSettings["OAuthClientId"];
            clientSecret = ConfigurationManager.AppSettings["OAuthClientSecret"];
        }
        /// <summary>
        /// 获取公共的键值对配置
        /// </summary>
        public static string GetCurrModuleName()
        {
            return (ConfigurationManager.AppSettings["ModuleName"] ?? "Dafy.Decision").Trim();
        }
        /// <summary>
        /// 获取当前应用的OAuthClient信息
        /// </summary>
        /// <returns></returns>
        public static KeyValuePair<string,string> GetCurrOAuthClient()
        {
            return new KeyValuePair<string, string>(clientId, clientSecret);
        }
        /// <summary>
        /// 获取公共的键值对配置
        /// </summary>
        public async static Task<Dictionary<string, string>> GetKeyValues()
        {
            foreach (var url in oauthUrls)
            {
                using (var client = HttpClientProvider.CreateHttpClient(url))
                {
                    try
                    {
                        if (!await PrepareAccessToken(client)) continue;
                        var resp = await client.GetAsync("/api/Config/GetKeyValues");
                        if (resp.IsSuccessStatusCode)
                        {
                            var result = await resp.Content.ReadAsAsync<Dictionary<string, string>>();
                            if (result != null && result.Count > 0) return result;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            return new Dictionary<string, string>();
        }
        /// <summary>
        /// 获取公共的键值对配置
        /// </summary>
        public async static Task<string> GetRedisConfig()
        {
            foreach (var url in oauthUrls)
            {
                using (var client = HttpClientProvider.CreateHttpClient(url))
                {
                    try
                    {
                        if (!await PrepareAccessToken(client)) continue;
                        var resp = await client.GetAsync("/api/Config/GetRedisConfig");
                        if (resp.IsSuccessStatusCode)
                        {
                            var result = await resp.Content.ReadAsStringAsync();
                            if (!string.IsNullOrWhiteSpace(result)) return result;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// 获取公共的键值对配置
        /// </summary>
        public async static Task<string> GetMongoDBConfig()
        {
            foreach (var url in oauthUrls)
            {
                using (var client = HttpClientProvider.CreateHttpClient(url))
                {
                    try
                    {
                        if (!await PrepareAccessToken(client)) continue;
                        var resp = await client.GetAsync("/api/Config/GetMongoDBConfig");
                        if (resp.IsSuccessStatusCode)
                        {
                            var result = await resp.Content.ReadAsStringAsync();
                            if (!string.IsNullOrWhiteSpace(result)) return result;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// 获取公共的键值对配置
        /// </summary>
        public async static Task<string> GetRabbitMQConfig()
        {
            foreach (var url in oauthUrls)
            {
                using (var client = HttpClientProvider.CreateHttpClient(url))
                {
                    try
                    {
                        if (!await PrepareAccessToken(client)) continue;
                        var resp = await client.GetAsync("/api/Config/GetRabbitMQConfig");
                        if (resp.IsSuccessStatusCode)
                        {
                            var result = await resp.Content.ReadAsStringAsync();
                            if (!string.IsNullOrWhiteSpace(result)) return result;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// 访问接口之前先准备AccessToken
        /// </summary>
        private async static Task<bool> PrepareAccessToken(HttpClient client)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("client_id", clientId);
            parameters.Add("client_secret", clientSecret);
            parameters.Add("grant_type", "client_credentials");

            try
            {
                var response = await client.PostAsync("/OAuth/Token", new FormUrlEncodedContent(parameters));
                if (response.IsSuccessStatusCode)
                {
                    var oauthToken = await response.Content.ReadAsAsync<OAuthResult>();
                    if (oauthToken != null && !string.IsNullOrWhiteSpace(oauthToken.access_token))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", oauthToken.access_token);
                        return true;
                    }
                }
            }
            catch { }
            return false;
        }

        private class OAuthResult
        {
            public string access_token { get; set; }

            public string token_type { get; set; }

            public string refresh_token { get; set; }
        }
        /// <summary>
        /// 得到AppSettings中的配置字符串信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfigString(string key)
        {
            var objModel = ConfigurationManager.AppSettings[key];
            return objModel.ToString();
        }
    }
}
