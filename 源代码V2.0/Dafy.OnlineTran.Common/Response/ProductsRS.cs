using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Response
{
    public class ProductsRS
    {
        public List<ProductsItemRS> list { get; set; }
        public int total { get; set; }
    }
    public class ProductsItemRS
    {
        /// <summary>产品ID</summary>
        public long pid { get; set; }

        /// <summary>产品名称</summary>
        public string productName { get; set; }

        /// <summary>产品类型</summary>
        public string productType { get; set; }

        /// <summary>所属机构</summary>
        public long companyId { get; set; }

        /// <summary>所属机构名称</summary>
        public string companyName { get; set; }

        /// <summary>所属机构Logo</summary>
        public string companyLogo { get; set; }

        /// <summary>产品亮点</summary>
        public string description { get; set; }

        /// <summary>产品详情</summary>
        public string content { get; set; }

        /// <summary>产品文档url</summary>
        public string docUrl { get; set; }

        /// <summary>承保年龄</summary>
        public int proAge { get; set; }

        /// <summary>产品价格</summary>
        public decimal price { get; set; }

        /// <summary>投保示例</summary>
        public string demoContent { get; set; }

        /// <summary>选择原因</summary>
        public string reasonContent { get; set; }

        /// <summary>理赔指引</summary>
        public string guideContent { get; set; }

        /// <summary>常见问题</summary>
        public string problemContent { get; set; }

        /// <summary>详情顶部图片</summary>
        public string detailTopUrl { get; set; }

        /// <summary>位置</summary>
        public int position { get; set; }

        /// <summary>热门位置</summary>
        public int hotPosition { get; set; }

        /// <summary>状态</summary>
        public string status { get; set; }
        public DateTime publishTime { get; set; }
    }
}
