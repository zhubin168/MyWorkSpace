using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Response
{
    /// <summary>
    /// 字典配置列表
    /// </summary>
    public class ParameterRS
    {
        public List<ParameterItemRS> list { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>
        public int total { get; set; }
    }

    public class ParameterItemRS
    {
        public int sortOrder { get; set; }
        /// <summary>
        /// id
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// 参数名称
        /// </summary>
        public string paraName { get; set; }
        /// <summary>
        /// 参数Code
        /// </summary>
        public string paraCode { get; set; }
        /// <summary>
        /// 参数分组
        /// </summary>
        public string paraGroup { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public Nullable<int> createUser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public Nullable<System.DateTime> createTime { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public Nullable<int> updateUser { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public Nullable<System.DateTime> updateTime { get; set; }
        /// <summary>
        /// /参数值
        /// </summary>
        public string paraValue { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public Nullable<decimal> status { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
    }
}
