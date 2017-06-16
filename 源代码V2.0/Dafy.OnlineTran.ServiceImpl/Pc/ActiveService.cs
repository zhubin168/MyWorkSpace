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
    /// 活动管理实现类 
    /// 创建人：朱斌
    /// 创建时间：2017-05-01
    /// </summary>
    public class ActiveService:IActiveService
    {
        /// <summary>
        /// 活动管理列表
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>

        public ActiveListRS GetActives(ActiveListRQ rq)
        {
            var result = new ActiveListRS { total = 0, list = null };
            var sql = string.Empty;//"select * from Active where 1=1 "; 
            if (!string.IsNullOrWhiteSpace(rq.paraName))
            {
                sql += string.Format(" (Title like '%{0}%' or ContentUrl like '%{0}%') ", rq.paraName);
            }
            var user = Active.FindAll(sql, "Id desc", null, (rq.pageIndex - 1) * rq.pageSize, rq.pageSize);
            var query = (from a in user.ToList()
                         select new
                         {
                             a.ContentUrl,
                             a.ImageUrl,
                             a.Title,
                             a.CreatedByName,
                             a.CreatedOn,
                             a.Id,
                             a.ModifiedByName,
                             a.ModifiedOn,
                         });
            query = query.OrderByDescending(q => q.ModifiedOn).ThenByDescending(q => q.Id);
            result.total = Active.FindAll(sql, null, null, 0, 0).Count;//query.Count();
            if (result.total == 0) return result;
            result.list = query.Select(a => new ActiveListItemRS
            {
                ContentUrl=a.ContentUrl,
                ImageUrl=a.ImageUrl,
                Title=a.Title,
                Id = a.Id,
                ModifiedByName=a.ModifiedByName,
                ModifiedOn=a.ModifiedOn,
                CreatedOn = a.CreatedOn,
                CreatedByName = a.CreatedByName
            }).ToList();
            return result;
        }

        public ResultModel<string> DelActives(SaveActiveRQ rq)
        {
            var obj = Active.FindById(rq.Id);
            int nCount = obj.Delete();
            return new ResultModel<string>
            {
                state = nCount,
                message = nCount > 0 ? "删除成功！" : "操作失败！",
                data = nCount.ToString()
            };
        }

        /// <summary>
        /// 保存活动信息
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<string> SaveActives(SaveActiveRQ rq)
        {
            EntityList<Active> users = new EntityList<Active>();
            var user = Active.FindById(rq.Id);
            if (null == user)
            {
                user = new Active();
                user.CreatedByName = rq.CreatedByName;
                user.CreatedOn = DateTime.Now;
            }
            user.ContentUrl = rq.ContentUrl;
            user.ImageUrl=rq.ImageUrl;
            user.Title=rq.Title;
            user.ModifiedByName = rq.CreatedByName;
            user.ModifiedOn = DateTime.Now;
            users.Add(user);
            int nCount = users.Save();
            return new ResultModel<string>
            {
                state = nCount,
                message = nCount > 0 ? "保存成功！" : "操作失败！",
                data = nCount.ToString()
            };
        }
    }
}
