
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Threading;
using Dafy.OnlineTran.Container;
using Autofac;

namespace Dafy.OnlineTran.Api.Owin
{
    /// <summary>
    /// 给owin中间件写日志用的日志记录器
    /// </summary>
    public class OwinLogger : Microsoft.Owin.Logging.ILogger
    {
        string _name = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public OwinLogger(string name)
        {
            _name = name;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool WriteCore(TraceEventType eventType, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
        {
            return true;
        }
    }
}