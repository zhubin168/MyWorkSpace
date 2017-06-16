using Autofac;
using Autofac.Integration.WebApi;
using Dafy.OnlineTran.Api.Owin;
using Dafy.OnlineTran.Common;
using Dafy.OnlineTran.Container;
using Dafy.OnlineTran.IService;
using Microsoft.Owin;
using Owin;
using System.Configuration;
using System.Reflection;
using System.Web.Http;

[assembly: OwinStartup(typeof(Dafy.OnlineTran.Api.Startup))]
namespace Dafy.OnlineTran.Api
{
    /// <summary>
    /// OWIN启动类
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// 构建IoC容器
        /// </summary>
        private void ConfigureDependency()
        {
            var builder = ContainerManager.Builder;

            //autofac for webapi
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            //autofac for current web
            

            //autofac for DependencyResolver
            config.DependencyResolver = new AutofacWebApiDependencyResolver(ContainerManager.Container);
        }
        /// <summary>
        /// 配置需要初始化的service
        /// </summary>
        private void ConfigureService()
        {
            var initService = ContainerManager.Container.Resolve<IInitService>();
            initService.Init();
        }
        /// <summary>
        /// 配置中间件
        /// </summary>
        public void Configuration(IAppBuilder app)
        {
            Microsoft.Owin.Logging.AppBuilderLoggerExtensions.SetLoggerFactory(app, new OwinLogFactory());

            ConfigureDependency();
            ConfigureService();

            ConfigureAuth(app);
            ConfigureSignalR(app);
        }
    }
}
