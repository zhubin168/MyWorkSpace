using Microsoft.Owin.Cors;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dafy.OnlineTran.Api
{
    public partial class Startup
    {
        /// <summary>
        /// 配置跨域中间件
        /// </summary>
        public void ConfigureCors(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
        }
    }
}