using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Request
{
    public class CustomerToolsRQ
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        /// <summary>
        /// 参数名
        /// </summary>
        public string paraName { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public string type { get;set;}
        /// <summary>
        /// 状态
        /// </summary>
        public string status { get; set; }
        public int id { get; set; }
    }
    public class SaveCustomerToolsRQ
    {
        /// <summary>图片ID</summary>
        public long id { get; set; }

        /// <summary>图片主题</summary>
        public string title { get; set; }

        /// <summary>图片类别</summary>
        public int type { get; set; }

        /// <summary>图片排序</summary>
        public int sequence { get; set; }

        /// <summary>图片地址</summary>
        public string imageUrl { get; set; }

        /// <summary>状态</summary>
        public int status { get; set; }

        /// <summary>发布时间</summary>
        public DateTime? publishTime { get; set; }

        /// <summary>创建时间</summary>
        public DateTime createTime { get; set; }

        /// <summary>更新时间</summary>
        public DateTime updateTime { get; set; }

        /// <summary>创建者名称</summary>
        public string CreatedByName { get; set; }
    }
}
