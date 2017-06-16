using Autofac;
using Dafy.OnlineTran.Container;

using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Dafy.OnlineTran.Api
{
    public partial class Startup
    {
        /// <summary>
        /// 配置SignalrR中间件
        /// </summary>
        public void ConfigureSignalR(IAppBuilder app)
        {
            GlobalHost.Configuration.ConnectionTimeout = TimeSpan.FromSeconds(110);
            GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromSeconds(30);
            GlobalHost.Configuration.KeepAlive = TimeSpan.FromSeconds(10);
            var config = new HubConfiguration()
            {
                EnableDetailedErrors = true
            };
            app.MapSignalR(config);
            GlobalHost.HubPipeline.AddModule(new SamplePipelineModule());
            GlobalHost.HubPipeline.AddModule(new ErrorHandlingPipelineModule());
        }

        private class SamplePipelineModule : HubPipelineModule
        {
            protected override bool OnBeforeIncoming(IHubIncomingInvokerContext context)
            {
                Debug.WriteLine("=> Invoking " + context.MethodDescriptor.Name + " on hub " + context.MethodDescriptor.Hub.Name);
                return base.OnBeforeIncoming(context);
            }

            protected override bool OnBeforeOutgoing(IHubOutgoingInvokerContext context)
            {
                Debug.WriteLine("<= Invoking " + context.Invocation.Method + " on client hub " + context.Invocation.Hub);
                return base.OnBeforeOutgoing(context);
            }
        }

        private class ErrorHandlingPipelineModule : HubPipelineModule
        {
            //public ErrorHandlingPipelineModule()
            //{
            //    _logger = ContainerManager.Container.Resolve<ILoggerFactory>().CreateLogger<ErrorHandlingPipelineModule>();
            //}
            protected override void OnIncomingError(ExceptionContext exceptionContext, IHubIncomingInvokerContext invokerContext)
            {
                Debug.WriteLine("=> Exception " + exceptionContext.Error.Message);
                base.OnIncomingError(exceptionContext, invokerContext);
            }
        }
    }
}