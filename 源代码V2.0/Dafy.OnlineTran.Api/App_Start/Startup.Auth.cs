using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using System;
using Microsoft.Owin.Security;
using System.Configuration;

namespace Dafy.OnlineTran.Api
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            var expireTimeSpanOfDay = 1;

            #region SysUserList用户的认证
            //use Cookie for authentication
            var cookieOptionOfUser = new CookieAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                AuthenticationType = OAuthDefaults.AuthenticationType,
                ExpireTimeSpan = TimeSpan.FromDays(expireTimeSpanOfDay)
            };
            app.UseCookieAuthentication(cookieOptionOfUser);

            #endregion
        }
    }
}