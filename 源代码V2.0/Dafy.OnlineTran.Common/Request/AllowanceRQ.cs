using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Request
{
    /// <summary>
    /// 理财师业绩
    /// </summary>
    public class AllowanceRQ
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        /// <summary>
        /// 参数名
        /// </summary>
        public string paraName { get; set; }
        public int roleId { get; set; }
    }

    /// <summary>
    /// 理财师业绩详情
    /// </summary>
    public class AllowanceDetailRQ
    {
        public int id { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        /// <summary>
        /// 参数名
        /// </summary>
        public string paraName { get; set; }
        public int roleId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
}
