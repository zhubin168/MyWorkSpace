using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GiveU.CollectionVisit.Web.Controllers
{
    public class CookieHelper
    {
       /// <summary>
       /// 写入Cookie
       /// </summary>
       /// <param name="name">cookie 的名称</param>
       /// <param name="key">健值</param>
       /// <param name="value">内容</param>
       /// <param name="seconds">有效时间</param>
        public static void WriteCodeCookie(string name, string value, int seconds)
        {
           HttpCookie cookie = new HttpCookie(name)
           {
               Value = value,
               Expires = DateTime.Now.AddSeconds(seconds)
           };
           HttpContext.Current.Response.Cookies.Add(cookie);
        }
        /// <summary>
        /// 清除cookie
        /// </summary>
        /// <param name="name">cookie 名称</param>
        public static void ClearCookie(string name)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(name);
            if (cookie == null) return;
            cookie.Expires = DateTime.Now.AddDays(-15);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        /// <summary>
        /// 读取cookie 的值
        /// </summary>
        /// <param name="name">cookie 名称</param>
        /// <returns></returns>

        public static string GetCookie(string name)
        {
            var cookie = HttpContext.Current.Request.Cookies.Get(name);
            return cookie == null ? "" : cookie.Value;
        }
    }
}
