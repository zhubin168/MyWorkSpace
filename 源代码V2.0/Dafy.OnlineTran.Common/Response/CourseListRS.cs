using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Response
{
    public class CourseListRS
    {
        public List<CourseListItemRS> list { get; set; }
        public int total { get; set; }
    }
    public class CourseListItemRS 
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

        /// <summary>创建时间</summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>创建者名称</summary>
        public string CreatedByName { get; set; }

        /// <summary>修改时间</summary>
        public DateTime ModifiedOn { get; set; }

        /// <summary>修改者名称</summary>
        public string ModifiedByName { get; set; }
    }

    /// <summary>
    /// 资讯分类管理
    /// </summary>
    public class InfoCategorysRS
    {
        public List<InfoCategorysItemRS> list { get; set; }
        public int total { get; set; }
    }
    public class InfoCategorysItemRS
    {
        /// <summary>资讯分类ID</summary>
        public long id { get; set; }

        /// <summary>资讯分类名称</summary>
        public string name { get; set; }

        /// <summary>创建时间</summary>
        public DateTime createTime { get; set; }

        /// <summary>更新时间</summary>
        public DateTime updateTime { get; set; }

        /// <summary>创建者,用户表的uid</summary>
        public long createUid { get; set; }

        /// <summary>修改者，用户表的uid</summary>
        public long modifyUid { get; set; }

        /// <summary></summary>
        public int orderNum { get; set; }
    }

    /// <summary>
    /// 资讯管理
    /// </summary>
    public class InformationRS
    {
        public List<InformationItemRS> list { get; set; }
        public int total { get; set; }
    }

    public class InformationItemRS
    {
        /// <summary>资讯ID</summary>
        public long id { get; set; }

        /// <summary>资讯标题</summary>
        public string title { get; set; }

        /// <summary>来源资讯分类表id</summary>
        public long cid { get; set; }
        public string typeName { get; set; }

        /// <summary>资讯分享图片</summary>
        public string shareUrl { get; set; }

        /// <summary>资讯分享描述</summary>
        public string shareTitle { get; set; }

        /// <summary>资讯列表图片</summary>
        public string listUrl { get; set; }

        /// <summary>正文链接</summary>
        public string contentUrl { get; set; }

        /// <summary>资讯内容</summary>
        public string content { get; set; }

        /// <summary>资讯状态</summary>
        public int status { get; set; }

        /// <summary>发布时间</summary>
        public DateTime? publishTime { get; set; }

        /// <summary>创建时间</summary>
        public DateTime createTime { get; set; }

        /// <summary>更新时间</summary>
        public DateTime updateTime { get; set; }

        /// <summary>创建者,用户表的uid</summary>
         public long createUid { get; set; }

        /// <summary>修改者，用户表的uid</summary>
         public long modifyUid { get; set; }
         public string modifyName { get; set; }
    }

    /// <summary>
    /// 小知识管理
    /// </summary>
    public class KnowledgeRS
    {
        public List<KnowledgeItemRS> list { get; set; }
        public int total { get; set; }
    }
    public class KnowledgeItemRS
    {
        /// <summary>小知识ID</summary>
        public long id { get; set; }

        /// <summary>小知识标题</summary>
        public string title { get; set; }

        /// <summary>小知识分享图片</summary>
        public string shareUrl { get; set; }

        /// <summary>小知识分享描述</summary>
        public string shareTitle { get; set; }

        /// <summary></summary>
        public string listUrl { get; set; }

        /// <summary>正文链接</summary>
        public string contentUrl { get; set; }

        /// <summary></summary>
        public string content { get; set; }

        /// <summary>小知识状态</summary>
        public int status { get; set; }

        /// <summary>发布时间</summary>
        public DateTime? publishTime { get; set; }

        /// <summary>创建时间</summary>
        public DateTime createTime { get; set; }

        /// <summary>更新时间</summary>
        public DateTime updateTime { get; set; }

        /// <summary>创建者,用户表的uid</summary>
        public long createUid { get; set; }

        /// <summary>修改者，用户表的uid</summary>
        public long modifyUid { get; set; }
        public string modifyName { get; set; }
    }

    /// <summary>
    /// 理财师充电站
    /// </summary>
    public class CourseRS
    {
        public List<CourseItemRS> list { get; set; }
        public int total { get; set; }
    }
    public class CourseItemRS
    {
        /// <summary>课程ID</summary>
        public long id { get; set; }

        /// <summary>课程名称</summary>
        public string title { get; set; }

        /// <summary>副标题</summary>
        public string subTitle { get; set; }

        /// <summary>课程分享图片</summary>
        public string shareUrl { get; set; }

        /// <summary>课程分享描述</summary>
        public string shareTitle { get; set; }

        /// <summary>课程列表图片</summary>
        public string listUrl { get; set; }

        /// <summary>正文链接</summary>
        public string contentUrl { get; set; }

        /// <summary>课程内容</summary>
        public string content { get; set; }

        /// <summary>课程状态</summary>
        public int status { get; set; }

        /// <summary>推荐首页</summary>
        public int position { get; set; }

        /// <summary>发布时间</summary>
        public DateTime? publishTime { get; set; }

        /// <summary>创建时间</summary>
        public DateTime createTime { get; set; }

        /// <summary>更新时间</summary>
        public DateTime updateTime { get; set; }

        /// <summary>创建者,用户表的uid</summary>
        public long createUid { get; set; }

        /// <summary>修改者，用户表的uid</summary>
        public long modifyUid { get; set; }
        public string modifyName { get; set; }
    }

    /// <summary>
    /// 首页Banner
    /// </summary>
    public class BannerRS
    {
        public List<BannerItemRS> list { get; set; }
        public int total { get; set; }
    }
    public class BannerItemRS
    {
        /// <summary>活动页ID</summary>
        public long id { get; set; }

        /// <summary>活动页标题</summary>
        public string title { get; set; }

        /// <summary>活动页图片地址</summary>
        public string imageUrl { get; set; }

        /// <summary>活动页内容地址</summary>
        public string contentUrl { get; set; }

        /// <summary>可见用户</summary>
        public string visiableUid { get; set; }

        /// <summary>活动状态</summary>
        public int status { get; set; }

        /// <summary>发布时间</summary>
        public DateTime? publishTime { get; set; }

        /// <summary>创建时间</summary>
        public DateTime createTime { get; set; }

        /// <summary>更新时间</summary>
        public DateTime updateTime { get; set; }

        /// <summary>创建者,用户表的uid</summary>
        public long createUid { get; set; }

        /// <summary>修改者，用户表的uid</summary>
        public long modifyUid { get; set; }

        /// <summary></summary>
        public string visibleStartTime { get; set; }

        /// <summary></summary>
        public string visibleEndTime { get; set; }

        /// <summary></summary>
        public string shareTitle { get; set; }

        /// <summary></summary>
        public string shareImageUrl { get; set; }

        /// <summary></summary>
        public string shareContent { get; set; }

        /// <summary></summary>
        public string shareUrl { get; set; }
        public int orderNum { get; set; }
        public string modifyName { get; set; }
    }
}
