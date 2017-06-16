using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Response
{
    public class BindRecordRS
    {
        public List<BindRecordItemRS> list { get; set; }
    }
    public class BindRecordItemRS
    {
        public long pUid { get; set; }
        public string pUserName { get; set; }
        public DateTime bingTime { get; set; }
        public DateTime unbindTime { get; set; }
    }
}
