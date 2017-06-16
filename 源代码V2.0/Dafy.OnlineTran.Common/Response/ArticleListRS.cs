using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Response
{
    public class ArticleListRS
    {
        public List<ArticleListItemRS> list { get; set; }
        public int total { get; set; }
    }
    public class ArticleListItemRS
    {
        /// <summary>文章ID</summary>
        public long id { get; set; }

        /// <summary>文章标题</summary>
        public string title { get; set; }

        /// <summary>文章类型</summary>
        public int type { get; set; }

        /// <summary>文章分享图片</summary>
        public string shareUrl { get; set; }

        /// <summary>文章分享描述</summary>
        public string shareTitle { get; set; }

        /// <summary>文章列表图片</summary>
        public string listUrl { get; set; }

        /// <summary>正文链接</summary>
        public string contentUrl { get; set; }

        /// <summary>文章内容</summary>
        public string content { get; set; }

        /// <summary>文章状态</summary>
        public int status { get; set; }

        /// <summary>发布时间</summary>
        public DateTime publishTime { get; set; }

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
}
