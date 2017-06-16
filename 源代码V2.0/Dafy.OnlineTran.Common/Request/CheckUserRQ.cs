using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Request
{
    /// <summary>
    /// 认证审核
    /// </summary>
    public class CheckUserRQ
    {
        public int id { get; set; }
        public int status { get; set; }
        public string reason { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public int auditUid { get; set; }
    }
}
