using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Request.App
{
    public class AppProductsRQ
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }

        public int productType { get; set; }
    }
}
