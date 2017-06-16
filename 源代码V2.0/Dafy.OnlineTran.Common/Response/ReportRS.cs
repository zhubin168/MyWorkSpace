using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Response
{
    public class ReportRS
    {
        /// <summary>
        /// 新增客户
        /// </summary>
        public int Num1 { get; set; }
        /// <summary>
        /// 新增理财师
        /// </summary>
        public int Num2 { get; set; }
        /// <summary>
        /// 新增预约
        /// </summary>
        public int Num3 { get; set; }
        /// <summary>
        /// 新增成单金额
        /// </summary>
        public decimal Num4 { get; set; }
        /// <summary>
        /// 累计客户
        /// </summary>
        public int Num5 { get; set; }
        /// <summary>
        /// 累计理财师
        /// </summary>
        public int Num6 { get; set; }
        /// <summary>
        /// 累计预约
        /// </summary>
        public int Num7 { get; set; }
        /// <summary>
        /// 累计成单金额
        /// </summary>
        public decimal Num8 { get; set; }

        /// <summary>
        /// X轴数据
        /// </summary>
        public string xDataSource { get; set; }
        public string yDataSource1 { get; set; }
        public string yDataSource2 { get; set; }
        public string yDataSource3 { get; set; }
        public string yDataSource4 { get; set; }
    }
}
