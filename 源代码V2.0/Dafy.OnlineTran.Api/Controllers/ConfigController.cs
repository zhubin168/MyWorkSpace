using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using Dafy.OnlineTran.Common.Response;
using Dafy.OnlineTran.IService.Pc;
using Dafy.OnlineTran.Common.Request;

namespace Dafy.OnlineTran.Api.Controllers
{
    /// <summary>
    /// 数据配置
    /// 创建人：朱斌
    /// 创建时间：2017-04-30
    /// </summary>
    [AllowAnonymous]
    public class ConfigController : AuthController
    {
        private readonly IConfigService _service;
        /// <summary>
        /// 注入service
        /// </summary>
        public ConfigController(IConfigService service)
        {
            _service = service;
        }

        /// <summary>
        /// 参数字典列表
        /// </summary>
        [HttpPost]
        public ParameterRS GetConfigs(ParameterRQ rq)
        {
            if (rq == null || rq.pageIndex <= 0 || rq.pageSize <= 0)
                return new ParameterRS { total = 0, list = null };
            return _service.GetConfigs(rq);
        }

        /// <summary>
        /// 保存字典信息
        /// </summary>
        [HttpPost]
        public ResultModel<string> SaveConfig(SaveParameterRQ rq)
        {
            rq.updateUser = 0;
            return _service.SaveConfig(rq);
        }

        /// <summary>
        /// 删除字典信息
        /// </summary>
        [HttpPost]
        public ResultModel<string> DeleteConfig(DelParameterRQ rq)
        {
            return _service.DeleteConfig(rq);
        }
     
    }
}
