using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Request.App
{
    /// <summary>
    /// 我的销售记录
    /// </summary>
    public class SaleRecordRQ
    {
        public int uid { get; set; }
        public string paraName { get; set; }
        public int roleId { get; set; }
    }

    /// <summary>
    /// 申请理财师认证
    /// </summary>
    public class ApplyManagerRQ
    {
        public int uid { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
    }
}
