using Autofac;
using Dafy.OnlineTran.ServiceImpl;
using System.Linq;

namespace Dafy.OnlineTran.Container
{
    public class ContainerManager
    {
        static ContainerManager()
        {
            Register();
        }
        /// <summary>
        /// 对外提供Builder对象用来注册接口
        /// </summary>
        private static readonly ContainerBuilder builder = new ContainerBuilder();
        public static ContainerBuilder Builder
        {
            get { return builder; }
        }
        /// <summary>
        /// 对外提供容器对象的调用
        /// </summary>
        private static IContainer container = null;
        public static IContainer Container
        {
            get { return container ?? (container = builder.Build()); }
        }
        /// <summary>
        /// 对外提供的注册服务接口
        /// </summary>
        public static void Register()
        {
            RegisterService(builder);
        }
        /// <summary>
        /// 注册servie服务
        /// </summary>
        public static void RegisterService(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(InitService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces()
               .SingleInstance();
        }
    }
}
