using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Request.App
{
    public class AppSaveUserInfoRQ
    {
        public int uId { set; get; }
        public string userName { set; get; }
        public string rank { set; get; }
        public string phone { set; get; }

        public string remark { set; get; }
    }
}
