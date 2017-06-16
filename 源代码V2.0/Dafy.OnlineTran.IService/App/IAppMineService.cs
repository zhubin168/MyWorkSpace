using Dafy.OnlineTran.Common.Request;
using Dafy.OnlineTran.Common.Request.App;
using Dafy.OnlineTran.Common.Response;
using Dafy.OnlineTran.Common.Response.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.IService.App
{
    /// <summary>
    /// 我的（微信端）
    /// </summary>
    public interface IAppMineService
    {
        /// <summary>
        /// 个人中心信息
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        WeixinUserItemRS GetPersonCenter(SaleRecordRQ rq);

        /// <summary>
        /// 设置个人头像
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<string> SetIcon(WeixinUserMineRQ rq);

        /// <summary>
        /// 绑定银行卡信息
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<string> SetBank(SetBankRQ rq);

        /// <summary>
        /// 获取所有银行
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ParameterRS GetBankNames();

        /// <summary>
        /// 我的销售记录
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        SaleRecordRS SaleRecord(SaleRecordRQ rq);

        /// <summary>
        /// 我的预约记录
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        OrderRecordRS OrderRecord(SaleRecordRQ rq);

        /// <summary>
        /// 客户详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        CustormDetailRS CustormDetail(SaleRecordRQ rq);

        /// <summary>
        /// 我的理财师团队
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        MineTeamRS GetMineTeam(SaleRecordRQ rq);

        /// <summary>
        /// 我的客户
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        MineCustomerRS GetMineCustomer(SaleRecordRQ rq);

        /// <summary>
        /// 申请理财师认证
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<string> ApplyManager(ApplyManagerRQ rq);

        /// <summary>
        /// 我的理财师（上级信息）
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        MineParentItemRS GetMineParent(SaleRecordRQ rq);

        /// <summary>
        /// 帮助中心
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ParameterRS GetHelperQuestion();

        /// <summary>
        /// 收益明细
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        IncomeRecordRS IncomeRecord(SaleRecordRQ rq);
    }
}
