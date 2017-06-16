using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Response
{
    /// <summary>
    /// 理财师业绩
    /// </summary>
    public class AllowanceRs
    {
        public List<AllowanceItemRs> list { get; set; }
        public int total { get; set; }
    }
    public class AllowanceItemRs
    {
        /// <summary>
        /// ID
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string telphone { get; set; }
        /// <summary>
        /// 累计销售额（元）
        /// </summary>
        public decimal salesNums { get; set; }
        /// <summary>
        /// 本月销售额（元）
        /// </summary>
        public decimal monthNums { get; set; }
    }

    /// <summary>
    /// 理财师业绩详情
    /// </summary>
    public class AllowanceDetailRs 
    {
        public List<AllowanceDetailItemRs> list { get; set; }
        public int total { get; set; }
    }
    public class AllowanceDetailItemRs
    {
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 客户电话
        /// </summary>
        public string telphone { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string productName { get; set; }
        /// <summary>
        /// 产品类型
        /// </summary>
        public string productType { get; set; }
        /// <summary>
        /// 购买金额（元）
        /// </summary>
        public decimal salesNums { get; set; }
        /// <summary>
        /// 购买时间
        /// </summary>
        public DateTime buyTime { get; set; }
    }
}
