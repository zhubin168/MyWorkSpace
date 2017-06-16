using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Response.App
{
    public class JsSdkSignRS
    {
        public string timestamp { set; get; }
        public string nonceStr { set; get; }
        public string signature { set; get; }
    }
}
