using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Request
{
    public class ProductsRQ
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        /// <summary>
        /// 参数名
        /// </summary>
        public string paraName { get; set; }
        /// <summary>产品类型</summary>
        public string productType { get; set; }
        /// <summary>状态</summary>
        public string status { get; set; }
        public long pid { get; set; }
    }
}
