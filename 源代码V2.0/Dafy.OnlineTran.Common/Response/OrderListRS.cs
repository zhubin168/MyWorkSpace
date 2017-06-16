using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Response
{
    public class OrderListRS
    {
        public List<OrderListItemRS> list { get; set; }
        public int total { get; set; }
    }
    public class OrderListItemRS
    {
        /// <summary>预约号</summary>
        public long oid { get; set; }

        /// <summary>理财师ID</summary>
        public long uid { get; set; }

        /// <summary>理财师姓名</summary>
        public string uname { get; set; }

        /// <summary>产品ID</summary>
        public long productId { get; set; }

        /// <summary>产品名称</summary>
        public string productName { get; set; }

        /// <summary>产品类型</summary>
        public string productType { get; set; }

        /// <summary>产品价格</summary>
        public decimal prodcutPrice { get; set; }

        /// <summary>客户ID</summary>
        public long clientUid { get; set; }

        /// <summary>客户姓名</summary>
        public string clientName { get; set; }

        /// <summary>客户电话</summary>
        public string clientPhone { get; set; }

        /// <summary>购买数量</summary>
        public int total { get; set; }

        /// <summary>预约状态</summary>
        public int status { get; set; }

        /// <summary>订单时间</summary>
        public DateTime createTime { get; set; }

        /// <summary>更新时间</summary>
        public DateTime updateTime { get; set; }

        /// <summary>操作记录</summary>
        public string record { get; set; }
    }
}
