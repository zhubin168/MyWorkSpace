using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Logging;

namespace Dafy.OnlineTran.Api.Owin
{
    /// <summary>
    /// OWIN中间件里面用到的日志工厂类
    /// </summary>
    public class OwinLogFactory : Microsoft.Owin.Logging.ILoggerFactory
    {
        /// <summary>
        /// 创建owin里面用到的日志对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ILogger Create(string name)
        {
            return new OwinLogger(name);
        }
    }
}