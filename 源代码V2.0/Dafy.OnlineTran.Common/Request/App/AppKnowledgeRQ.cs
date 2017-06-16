using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Request.App
{
    public class AppKnowledgeRQ
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }

    public class AppKnowledgeDetailRQ
    {
        public int id { get; set; }
    }
}
