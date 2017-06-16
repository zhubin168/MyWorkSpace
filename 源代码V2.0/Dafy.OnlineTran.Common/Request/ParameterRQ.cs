using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Request
{
    /// <summary>
    /// 字典配置列表
    /// </summary>
    public class ParameterRQ
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        /// <summary>
        /// 参数名
        /// </summary>
        public string paraName { get; set; }
    }

    /// <summary>
    /// 保存字典
    /// </summary>
    public class SaveParameterRQ
    {
        public short? sortOrder { get; set; }

        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
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

        public int updateUser { get; set; }
    }

    public class DelParameterRQ
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        public int status { get; set; }
        public string remark { get; set; }
        public string statusText { get; set; }
        public string updateUser { get; set; }
    }

    public class ChangeVisitorRQ
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
    }
}
