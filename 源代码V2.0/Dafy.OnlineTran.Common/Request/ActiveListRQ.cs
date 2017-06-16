using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Request
{
    public class ActiveListRQ
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        /// <summary>
        /// 参数名
        /// </summary>
        public string paraName { get; set; }
    }
    public class SaveActiveRQ
    {
        public long Id { get; set; }
        public string ImageUrl { get; set; }

        public string ContentUrl { get; set; }

        public string Title { get; set; }

        /// <summary>创建者名称</summary>
        public string CreatedByName { get; set; }
    }
}
