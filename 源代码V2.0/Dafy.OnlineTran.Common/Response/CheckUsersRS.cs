using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Response
{
    /// <summary>
    /// 认证审核
    /// </summary>
    public class CheckUsersRS
    {
        public List<CheckUsersItemRS> list { get; set; }
        public int total { get; set; }
    }
    public class CheckUsersItemRS
    {
        public long uid { get; set; }
        /// <summary>
        /// 理财师姓名
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string telphone { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime applyTime { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 未通过原因
        /// </summary>
        public string reason { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime checkTime { get; set; }
    }
}
