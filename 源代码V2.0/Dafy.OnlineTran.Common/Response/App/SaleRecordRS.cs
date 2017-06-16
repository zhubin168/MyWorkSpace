using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Response.App
{
    public class SaleRecordRS
    {
        public int total { get; set; }
        public decimal monthSumSales { get; set; }
        public List<SaleRecordItemRS> list { get; set; }
    }
    public class SaleRecordItemRS
    {
        /// <summary>产品名称</summary>
        public string productName { get; set; }

        /// <summary>产品类型</summary>
        public string productType { get; set; }

        /// <summary>产品价格</summary>
        public decimal prodcutPrice { get; set; }

        /// <summary>订单时间</summary>
        public DateTime createTime { get; set; }
    }

    public class OrderRecordRS
    {
        public int total { get; set; }
        public List<OrderRecordItemRS> list { get; set; }
    }
    public class OrderRecordItemRS
    {
        /// <summary>产品名称</summary>
        public string productName { get; set; }

        /// <summary>产品类型</summary>
        public string productType { get; set; }

        /// <summary>产品价格</summary>
        public decimal prodcutPrice { get; set; }

        /// <summary>订单时间</summary>
        public DateTime createTime { get; set; }
        public string status { get; set; }
    }
    public class MineTeamRS
    {
        public int total { get; set; }
        /// <summary>
        /// 直接下属
        /// </summary>
        public int directNum { get; set; }
        /// <summary>
        /// 间接下属
        /// </summary>
        public int undirectNum { get; set; }
        public List<MineTeamItemRS> list { get; set; }
    }
    public class MineTeamItemRS
    {
        public long uid { get; set; }
        /// <summary></summary>
        public string Nickname { get; set; }

        /// <summary></summary>
        public string Headimgurl { get; set; }

        /// <summary></summary>
        public string Username { get; set; }

        /// <summary>(0:客户；1：理财师)</summary>
        public int RoleId { get; set; }

        /// <summary>电话</summary>
        public string TelePhone { get; set; }
        /// <summary>
        /// 下级数量
        /// </summary>
        public int ChildNum { get; set; }
    }

    public class MineCustomerRS
    {
        public int total { get; set; }
        public Dictionary<string,List<MineCustomerItemRS>> list { get; set; }
    }
    public class MineCustomerItemRS
    {
        public long Uid { get; set; }
        public string Ping { get; set; }
        /// <summary></summary>
        public string Nickname { get; set; }

        /// <summary></summary>
        public string Headimgurl { get; set; }

        /// <summary></summary>
        public string Username { get; set; }

        /// <summary>电话</summary>
        public string TelePhone { get; set; }
        /// <summary>
        /// 购买次数
        /// </summary>
        public int Number { get; set; }
    }

    public class MineParentItemRS
    {
        /// <summary></summary>
        public string Nickname { get; set; }

        /// <summary></summary>
        public string Headimgurl { get; set; }

        /// <summary>(0:客户；1：理财师)</summary>
        public int RoleId { get; set; }

        /// <summary>电话</summary>
        public string TelePhone { get; set; }
        /// <summary>职位</summary>
        public string Rank { get; set; }
        public string Remark { get; set; }
    }

    public class CustormDetailRS
    {
        /// <summary></summary>
        public string Nickname { get; set; }

        /// <summary></summary>
        public string Headimgurl { get; set; }

        /// <summary>电话</summary>
        public string TelePhone { get; set; }

        public DateTime regTime { get; set; }

        public int total { get; set; }
        public decimal monthSumSales { get; set; }
        public List<CustormDetailItemRS> list { get; set; }
    }
    public class CustormDetailItemRS
    {
        /// <summary>产品名称</summary>
        public string productName { get; set; }

        /// <summary>产品类型</summary>
        public string productType { get; set; }

        /// <summary>产品价格</summary>
        public decimal prodcutPrice { get; set; }

        /// <summary>订单时间</summary>
        public DateTime createTime { get; set; }
        public string status { get; set; }
    }
    /// <summary>
    /// 收益明细
    /// </summary>
    public class IncomeRecordRS
    {
        public int total { get; set; }
        public decimal sumIncomes { get; set; }
        public List<IncomeRecordItemRS> list { get; set; }
    }
    public class IncomeRecordItemRS
    {
        public string moth { get; set; }
        public decimal income { get; set; }
        /// <summary>
        /// 销售佣金
        /// </summary>
        public decimal rate1 { get; set; }
        /// <summary>
        /// 活动奖励
        /// </summary>
        public decimal rate2 { get; set; }
        /// <summary>
        /// 直接推荐奖励
        /// </summary>
        public decimal rate3 { get; set; }
        /// <summary>
        /// 间接推荐奖励
        /// </summary>
        public decimal rate4 { get; set; }
    }
}
