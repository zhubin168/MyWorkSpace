using Dafy.OnlineTran.Api.Filters;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using System.Web.Http.Filters;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Dafy.OnlineTran.Common.Helpers;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;

namespace Dafy.OnlineTran.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // 将 Web API 配置为仅使用不记名令牌身份验证。
            config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            config.Filters.Add(new MyHostAuthenticationFilter());

            // 去掉XML序列化器,只保留JSON序列化器
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //让返回数据符合驼峰命名法
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //添加跨域支持
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }

    public class MyHostAuthenticationFilter : IAuthenticationFilter
    {
        public bool AllowMultiple
        {
            get { return false; }
        }

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var token = context.Request.Headers.Authorization != null ? context.Request.Headers.Authorization.Parameter : null;
            if (!string.IsNullOrWhiteSpace((token)) && token != "000" && token != "undefined")
            {
                var uid = DesCryptoUtil.Decrypt(token);
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, uid));
                //claims.Add(new Claim(ClaimTypes.Role, "123"));
                var identity = new ClaimsIdentity(claims, context.Request.Headers.Authorization.Scheme);
                context.Principal = new ClaimsPrincipal(identity);
            }
            return Task.FromResult(0);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}
