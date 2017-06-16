using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Request.App
{
    public class AppAddOrderRQ
    {
        public string userName { set; get; }
        public int sex { set; get; }
        public string phone { set; get; }
        public int uId { set; get; }

        public int productId { set; get; }
    }
}
