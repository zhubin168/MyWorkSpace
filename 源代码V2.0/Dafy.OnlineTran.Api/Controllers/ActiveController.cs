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
    /// 活动管理
    /// 创建人：朱斌
    /// 创建时间：2017-05-01
    /// </summary>
    [AllowAnonymous]
    public class ActiveController : AuthController
    {
        private readonly IActiveService _service;
        /// <summary>
        /// 注入service
        /// </summary>
        public ActiveController(IActiveService service)
        {
            _service = service;
        }

        /// <summary>
        /// 活动管理列表
        /// </summary>
        [HttpPost]
        public ActiveListRS GetActives(ActiveListRQ rq)
        {
            if (rq == null || rq.pageIndex <= 0 || rq.pageSize <= 0)
                return new ActiveListRS { total = 0, list = null };
            return _service.GetActives(rq);
        }

        /// <summary>
        /// 删除活动信息
        /// </summary>
        [HttpPost]
        public ResultModel<string> DelActives(SaveActiveRQ rq)
        {
            return _service.DelActives(rq);
        }

        /// <summary>
        /// 保存活动信息
        /// </summary>
        [HttpPost]
        public ResultModel<string> SaveActives(SaveActiveRQ rq)
        {
            rq.CreatedByName= this.User.Identity.Name;
            return _service.SaveActives(rq);
        }
    }
}
