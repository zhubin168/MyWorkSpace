using System;
using System.Net.Http;
using System.Threading;
using System.Web.Http.Filters;
using Autofac;
using Dafy.OnlineTran.Container;

namespace Dafy.OnlineTran.Api.Filters
{
    /// <summary>
    /// 
    /// </summary>
    //public class WebApiExceptionHandleFilter : GiveUWebApiHandleExceptionAttribute
    //{
    //    ILogger _logger = null;
    //    /// <summary>
    //    /// 异常时报错处理
    //    /// </summary>
    //    protected override void HandleException(HttpActionExecutedContext actionExecutedContext, string prefix, string ctrlName, string actionName, string userName)
    //    {
    //        if (_logger == null)
    //        {
    //            LazyInitializer.EnsureInitialized(ref _logger, () =>
    //            {
    //                var facLogger = ContainerManager.Container.Resolve<ILoggerFactory>();
    //                return facLogger.CreateLogger<WebApiExceptionHandleFilter>();
    //            });
    //        }
    //        var msg = string.Format("{0}-{1}-{2} ({3})", prefix ?? "", ctrlName, actionName, userName ?? "");
    //        _logger.LogError(new Random().Next(65530), actionExecutedContext.Exception, msg);

    //        //TODO 业务处理
    //        actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, "服务器出错啦！");
    //    }
    //}
}