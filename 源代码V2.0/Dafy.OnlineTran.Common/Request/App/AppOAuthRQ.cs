using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Request.App
{
    public class AppOAuthRQ
    {
       public string code { set; get; }
       public string state { set; get; }
    }
}
