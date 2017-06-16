using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Response
{
    public class ActiveListRS
    {
        public List<ActiveListItemRS> list { get; set; }
        public int total { get; set; }
    }
    public class ActiveListItemRS
    {
        /// <summary>主键ID(自增列)</summary>
        public long Id { get; set; }

        public string ImageUrl { get; set; }

        public string ContentUrl { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        /// <summary>创建者名称</summary>
        public string CreatedByName { get; set; }

        /// <summary>修改时间</summary>
        public DateTime ModifiedOn { get; set; }

        /// <summary>修改者名称</summary>
        public string ModifiedByName { get; set; }
    }
}
