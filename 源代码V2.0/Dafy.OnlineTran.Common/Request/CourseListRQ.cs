using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Request
{
    public class CourseListRQ
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        /// <summary>
        /// 参数名
        /// </summary>
        public string paraName { get; set; }
    }
    public class SaveCourseRQ
    {
        /// <summary>主键ID(自增列)</summary>
        public long Id { get; set; }

        /// <summary>创建者名称</summary>
        public string Name { get; set; }

        /// <summary>创建者名称</summary>
        public string Title { get; set; }

        /// <summary>创建者名称</summary>
        public string Conent { get; set; }

        /// <summary>创建者名称</summary>
        public string IsRecomand { get; set; }

        /// <summary>创建者名称</summary>
        public string ImageUrl { get; set; }

        /// <summary>状态(0：未激活  1：激活失败 2：已启用  3：已停用 4：已删除)</summary>
        public int Status { get; set; }
        public string CreatedByName { get; set; }
    }

    /// <summary>
    /// 资讯分类管理
    /// </summary>
    public class InfoCategorysRQ
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        /// <summary>
        /// 参数名
        /// </summary>
        public string paraName { get; set; }
    }
    /// <summary>
    /// 资讯管理
    /// </summary>
    public class InformationRQ
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        /// <summary>
        /// 参数名
        /// </summary>
        public string paraName { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public int id { get; set; }
    }
    /// <summary>
    /// 小知识管理
    /// </summary>
    public class KnowledgeRQ
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        /// <summary>
        /// 参数名
        /// </summary>
        public string paraName { get; set; }
        public string status { get; set; }
        public int id { get; set; }
    }
    /// <summary>
    /// 理财师充电站
    /// </summary>
    public class CourseRQ
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        /// <summary>
        /// 参数名
        /// </summary>
        public string paraName { get; set; }
        public string status { get; set; }
        public int id { get; set; }
    }
    /// <summary>
    /// 首页Banner
    /// </summary>
    public class BannerRQ
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public string status { get; set; }
        public int id { get; set; }
    }
}
