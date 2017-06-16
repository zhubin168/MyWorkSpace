using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Request
{
    public class CheckUsersRQ
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        /// <summary>
        /// 参数名
        /// </summary>
        public string paraName { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public string status { get; set; }
        public int roleId { get; set; }
    }
}
