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
    /// 资讯管理实现类 
    /// 创建人：朱斌
    /// 创建时间：2017-05-01
    /// </summary>
    public class ArticleService : IArticleService
    {
        /// <summary>
        /// 资讯管理列表
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ArticleListRS GetArticles(ArticleListRQ rq)
        {
            var result = new ArticleListRS { total = 0, list = null };
            var sql = " 1=1 ";
            if (!string.IsNullOrWhiteSpace(rq.paraName))
            {
                sql += string.Format(" and title like '%{0}%' ", rq.paraName);
            }
            if (!string.IsNullOrWhiteSpace(rq.type))
            {
                sql += string.Format(" and type='{0}' ", rq.type);
            }
            if (!string.IsNullOrWhiteSpace(rq.status))
            {
                sql += string.Format(" and status='{0}' ", rq.status);
            }
            var user = Article.FindAll(sql, "Id desc", null, (rq.pageIndex - 1) * rq.pageSize, rq.pageSize);
            var query = (from a in user.ToList()
                         select new
                         {
                             a.content,
                             a.contentUrl,
                             a.createTime,
                             a.createUid,
                             a.id,
                             a.listUrl,
                             a.modifyUid,
                             a.publishTime,
                             a.shareTitle,
                             a.shareUrl,
                             a.status,
                             a.title,
                             a.type,
                             a.updateTime,
                         });
            result.total = Article.FindAll(sql, null, null, 0, 0).Count;
            if (result.total == 0) return result;
            result.list = query.Select(a => new ArticleListItemRS
            {
                content = a.content,
                contentUrl = a.contentUrl,
                createTime = a.createTime,
                createUid = a.createUid,
                id = a.id,
                listUrl = a.listUrl,
                modifyUid = a.modifyUid,
                publishTime = a.publishTime,
                shareTitle = a.shareTitle,
                shareUrl = a.shareUrl,
                status = a.status,
                title = a.title,
                type = a.type,
                updateTime = a.updateTime
            }).ToList();
            return result;
        }

        public ResultModel<string> DelArticles(SaveArticleRQ rq)
        {
            var obj = Article.FindByid(rq.id);
            int nCount = obj.Delete();
            return new ResultModel<string>
            {
                state = nCount,
                message = nCount > 0 ? "删除成功！" : "操作失败！",
                data = nCount.ToString()
            };
        }

        /// <summary>
        /// 保存资讯信息
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<string> SaveArticles(SaveArticleRQ rq)
        {
            EntityList<Article> users = new EntityList<Article>();
            var user = Article.FindByid(rq.id);
            if (null == user)
            {
                user = new Article();
                user.createUid = rq.createUid;
                user.createTime = DateTime.Now;
            }
            user.content = rq.content;
            user.contentUrl = rq.contentUrl;
            user.listUrl = rq.listUrl;
            user.modifyUid = rq.modifyUid;
            user.publishTime = rq.publishTime;
            user.shareTitle = rq.shareTitle;
            user.shareUrl = rq.shareUrl;
            user.status = rq.status;
            user.title = rq.title;
            user.type = rq.type;
            user.updateTime = DateTime.Now;
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
