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
using Dafy.OnlineTran.IService.App;
using Dafy.OnlineTran.Common.Response.App;
using Dafy.OnlineTran.Common.Request.App;

namespace Dafy.OnlineTran.Api.Controllers
{
    /// <summary>
    /// 我的（微信端）
    /// 创建人：朱斌
    /// 创建时间：2017-05-27
    /// </summary>
    [AllowAnonymous]
    public class AppMineController : AuthController
    {
        private readonly IAppMineService _service;
        /// <summary>
        /// 注入service
        /// </summary>
        public AppMineController(IAppMineService service)
        {
            _service = service;
        }

        /// <summary>
        /// 个人中心信息
        /// </summary>
        [HttpPost]
        public WeixinUserItemRS GetPersonCenter(SaleRecordRQ rq)
        {
            return _service.GetPersonCenter(rq);
        }

        /// <summary>
        /// 设置个人头像
        /// </summary>
        [HttpPost]
        public ResultModel<string> SetIcon(WeixinUserMineRQ rq)
        {
            return _service.SetIcon(rq);
        }

        /// <summary>
        /// 绑定银行卡信息
        /// </summary>
        [HttpPost]
        public ResultModel<string> SetBank(SetBankRQ rq)
        {
            return _service.SetBank(rq);
        }

        /// <summary>
        /// 获取所有银行
        /// </summary>
        [HttpPost]
        public ParameterRS GetBankNames()
        {
            return _service.GetBankNames();
        }

        /// <summary>
        /// 我的销售记录
        /// </summary>
        [HttpPost]
        public SaleRecordRS SaleRecord(SaleRecordRQ rq)
        {
            return _service.SaleRecord(rq);
        }

        /// <summary>
        /// 我的预约记录
        /// </summary>
        [HttpPost]
        public OrderRecordRS OrderRecord(SaleRecordRQ rq)
        {
            return _service.OrderRecord(rq);
        }

        /// <summary>
        /// 我的理财师团队
        /// </summary>
        [HttpPost]
        public MineTeamRS GetMineTeam(SaleRecordRQ rq)
        {
            return _service.GetMineTeam(rq);
        }

        /// <summary>
        /// 我的客户
        /// </summary>
        [HttpPost]
        public MineCustomerRS GetMineCustomer(SaleRecordRQ rq)
        {
            return _service.GetMineCustomer(rq);
        }

        /// <summary>
        /// 客户详情
        /// </summary>
        [HttpPost]
        public CustormDetailRS CustormDetail(SaleRecordRQ rq)
        {
            return _service.CustormDetail(rq);
        }

        /// <summary>
        /// 申请理财师认证
        /// </summary>
        [HttpPost]
        public ResultModel<string> ApplyManager(ApplyManagerRQ rq)
        {
            return _service.ApplyManager(rq);
        }

        /// <summary>
        /// 我的理财师（上级信息）
        /// </summary>
        [HttpPost]
        public MineParentItemRS GetMineParent(SaleRecordRQ rq)
        {
            return _service.GetMineParent(rq);
        }

        /// <summary>
        /// 帮助中心
        /// </summary>
        [HttpPost]
        public ParameterRS GetHelperQuestion()
        {
            return _service.GetHelperQuestion();
        }

        /// <summary>
        /// 收益明细
        /// </summary>
        [HttpPost]
        public IncomeRecordRS IncomeRecord(SaleRecordRQ rq)
        {
            return _service.IncomeRecord(rq);
        }
    }
}
