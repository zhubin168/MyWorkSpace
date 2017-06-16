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
    /// 理财师管理
    /// 创建人：朱斌
    /// 创建时间：2017-04-30
    /// </summary>
    [AllowAnonymous]
    public class OrderController : AuthController
    {
        private readonly IOrderService _service;
        /// <summary>
        /// 注入service
        /// </summary>
        public OrderController(IOrderService service)
        {
            _service = service;
        }

        /// <summary>
        /// 订单管理列表
        /// </summary>
        [HttpPost]
        public OrderListRS GetOrders(OrderListRQ rq)
        {
            if (rq == null || rq.pageIndex <= 0 || rq.pageSize <= 0)
                return new OrderListRS { total = 0, list = null };
            return _service.GetOrders(rq);
        }

        /// <summary>
        /// 更新状态
        /// </summary>
        [HttpPost]
        public ResultModel<string> UpdateOrders(DelParameterRQ rq)
        {
            rq.updateUser = this.User.Identity.Name.ToString();
            return _service.UpdateOrders(rq);
        }

        /// <summary>
        /// 操作记录
        /// </summary>
        [HttpPost]
        public ResultModel<string> OpRecord(DelParameterRQ rq)
        {
            return _service.OpRecord(rq);
        }
    }
}
