using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Response
{
    public class CustomerToolsRS
    {
        public List<CustomerToolsItemRS> list { get; set; }
        public int total { get; set; }
    }
    public class CustomerToolsItemRS
    {
        /// <summary>图片ID</summary>
        public long id { get; set; }

        /// <summary>图片主题</summary>
        public string title { get; set; }

        /// <summary>图片类别</summary>
        public long type { get; set; }

        /// <summary>图片排序</summary>
        public long sequence { get; set; }

        /// <summary>图片地址</summary>
        public string imageUrl { get; set; }

        /// <summary>状态</summary>
        public long status { get; set; }

        /// <summary>发布时间</summary>
        public string publishTime { get; set; }

        /// <summary>创建时间</summary>
        public DateTime createTime { get; set; }

        /// <summary>更新时间</summary>
        public DateTime updateTime { get; set; }

        /// <summary>创建者,用户表的uid</summary>
        public long createUid { get; set; }
    }

    public class ArticleToolsRS
    {
        public List<ArticleToolsItemRS> list { get; set; }
        public int total { get; set; }
    }
    public class ArticleToolsItemRS
    {
        /// <summary>资讯ID</summary>
        public long id { get; set; }

        /// <summary>资讯标题</summary>
        public string title { get; set; }

        /// <summary>来源资讯分类表id</summary>
        public int cid { get; set; }

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
        public DateTime publishTime { get; set; }

        /// <summary>创建时间</summary>
        public DateTime createTime { get; set; }

        /// <summary>更新时间</summary>
        public DateTime updateTime { get; set; }

        /// <summary>创建者,用户表的uid</summary>
        public int createUid { get; set; }

        /// <summary>修改者，用户表的uid</summary>
        public int modifyUid { get; set; }
    }
}
