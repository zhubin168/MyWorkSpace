using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Response.App
{
    public class AppArticleListRQ
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int type { get; set; }
    }
}
