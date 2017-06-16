using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Response
{
    public class DetailMemberRS
    {
        public List<DetailMemberItemRS> list { get; set; }
        public int total { get; set; }
    }
    public class DetailMemberItemRS
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string telePhone { get; set; }
        /// <summary>
        /// 团队关系
        /// </summary>
        public string relation { get; set; }
        /// <summary>
        /// 绑定时间
        /// </summary>
        public DateTime? bindDate { get; set; }
        /// <summary>
        /// 销售额
        /// </summary>
        public decimal nums1 { get; set; }
        /// <summary>
        /// 销售笔数
        /// </summary>
        public int nums2 { get; set; }
        /// <summary>
        /// 为我贡献奖励（元）
        /// </summary>
        public decimal nums3 { get; set; }
    }
}
