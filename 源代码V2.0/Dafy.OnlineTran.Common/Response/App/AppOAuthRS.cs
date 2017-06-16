using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Response.App
{
    public class AppOAuthRS
    {
        public string accessToken { set; get; }

        public string headImg { set; get; }

        public int roleId { set; get; }

        public string name { set; get; }
        public long uId{set;get;}
    }
}
