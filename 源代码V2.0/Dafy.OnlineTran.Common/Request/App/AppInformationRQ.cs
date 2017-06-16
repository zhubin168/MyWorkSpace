using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Request.App
{
    public class AppInformationRQ
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }

    public class AppInformationDetailRQ
    {
        public int id { set; get; }
    }
}
