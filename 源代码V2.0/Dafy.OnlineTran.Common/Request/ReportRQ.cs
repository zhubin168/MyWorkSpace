using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Request
{
    public class ReportRQ
    {
        public int Day { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
    public class ReportDateType
    {
        public int day { get; set; }
    }
}
