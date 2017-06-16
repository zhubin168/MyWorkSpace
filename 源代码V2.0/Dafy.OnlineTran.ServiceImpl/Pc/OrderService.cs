using Dafy.OnlineTran.Common.Request;
using Dafy.OnlineTran.Common.Response;
using Dafy.OnlineTran.Entity.Models;
using Dafy.OnlineTran.IService.Pc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCode;

namespace Dafy.OnlineTran.ServiceImpl.Pc
{
    /// <summary>
    /// 订单管理实现类 
    /// 创建人：朱斌
    /// 创建时间：2017-05-01
    /// </summary>
    public class OrderService : IOrderService
    {
        /// <summary>
        /// 订单管理列表
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public OrderListRS GetOrders(OrderListRQ rq)
        {
            var result = new OrderListRS { total = 0, list = null };
            var sql =" 1=1 ";
            if (!string.IsNullOrWhiteSpace(rq.paraName))
            {
                sql += string.Format(" and (clientName like '%{0}%' or clientPhone like '%{0}%') ", rq.paraName);
            }
            if (!string.IsNullOrWhiteSpace(rq.type))
            {
                sql += string.Format(" and productType='{0}' ", rq.type);
            }
            if (!string.IsNullOrWhiteSpace(rq.status))
            {
                sql += string.Format(" and status='{0}' ", rq.status);
            }
            if (!string.IsNullOrWhiteSpace(rq.clientUid))
            {
                sql += string.Format(" and clientUid='{0}' ", rq.clientUid);
            }
            var user = Order.FindAll(sql, "oid desc", null, (rq.pageIndex - 1) * rq.pageSize, rq.pageSize);
            var query = (from a in user.ToList()
                         select new
                         {
                             a.clientName,
                             a.clientPhone,
                             a.clientUid,
                             a.createTime,
                             a.oid,
                             a.prodcutPrice,
                             a.Product,
                             a.productId,
                             a.productName,
                             a.productType,
                             a.record,
                             a.status,
                             a.total,
                             a.uid,
                             a.uname,
                             a.updateTime,
                         });
            result.total = Order.FindAll(sql, null, null, 0, 0).Count; 
            if (result.total == 0) return result;
            result.list = query.Select(a => new OrderListItemRS
            {
                clientName = a.clientName,
                clientPhone = a.clientPhone,
                clientUid = a.clientUid,
                createTime = a.createTime,
                oid = a.oid,
                prodcutPrice = a.prodcutPrice,
                productId = a.productId,
                productName = a.productName,
                productType = a.productType,
                record = a.record,
                status = a.status,
                total = a.total,
                uid = a.uid,
                uname = a.uname,
                updateTime = a.updateTime,
            }).ToList();
            return result;
        }

        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<string> UpdateOrders(DelParameterRQ rq)
        {
            var obj = Order.FindByoid(rq.id);
            obj.updateTime = DateTime.Now;
            obj.status = rq.status;
            obj.record = obj.record+"<br>"+string.Format(@"{0}  {1}
                         更新预约状态：{2}
                         更新备注：{3}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), rq.updateUser, rq.status.ToString().Replace("0", "已预约")
                       .Replace("1", "已受理")
                       .Replace("2", "安排购买中")
                       .Replace("3", "已完成")
                       .Replace("4", "不受理")
                       .Replace("5", "已终止"), rq.remark);
            int nCount = obj.Save();
            return new ResultModel<string>
            {
                state = nCount,
                message = nCount > 0 ? "操作成功！" : "操作失败！",
                data = nCount.ToString()
            };
        }

        /// <summary>
        /// 操作记录
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<string> OpRecord(DelParameterRQ rq)
        {
            var obj = Order.FindByoid(rq.id);
            return new ResultModel<string>
            {
                state = 1,
                message = "",
                data = obj.record
            };
        }
    }
}
