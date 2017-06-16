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
    /// 获客助手管理实现类 
    /// 创建人：朱斌
    /// 创建时间：2017-05-01
    /// </summary>
    public class CustomerToolService : ICustomerToolService
    {
        /// <summary>
        /// 获客助手：图片管理
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public CustomerToolsRS GetTools(CustomerToolsRQ rq)
        {
            var result = new CustomerToolsRS { total = 0, list = null };
            var sql = " 1=1 ";
            if (!string.IsNullOrWhiteSpace(rq.paraName))
            {
                sql += string.Format(" and title like '%{0}%' ", rq.paraName);
            }
            if (!string.IsNullOrWhiteSpace(rq.status))
            {
                sql += string.Format(" and status='{0}' ", rq.status);
            }
            if (!string.IsNullOrWhiteSpace(rq.type))
            {
                sql += string.Format(" and type='{0}' ", rq.type);
            }
            var user = Picture.FindAll(sql, "id desc", null, (rq.pageIndex - 1) * rq.pageSize, rq.pageSize);
            var query = (from a in user.ToList()
                         select new
                         {
                             a.createTime,
                             a.createUid,
                             a.id,
                             a.imageUrl,
                             a.modifyUid,
                             a.publishTime,
                             a.sequence,
                             a.status,
                             a.title,
                             a.type,
                             a.updateTime,
                         });
            result.total = Picture.FindAll(sql, null, null, 0, 0).Count;
            if (result.total == 0) return result;
            result.list = query.Select(a => new CustomerToolsItemRS
            {
                createTime=a.createTime,
                createUid=a.createUid,
                id=a.id,
                imageUrl=a.imageUrl,
                publishTime=a.publishTime.ToString("yyyy/MM/dd HH:mm:ss"),
                sequence=a.sequence,
                status=a.status,
                title=a.title,
                type=a.type,
                updateTime=a.updateTime,
            }).ToList();
            return result;
        }

        /// <summary>
        /// 获客助手：图片保存
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<string> SaveTools(SaveCustomerToolsRQ rq)
        {
            EntityList<Picture> users = new EntityList<Picture>();
            var user = Picture.FindByid(rq.id);
            if (null == user)
            {
                user = new Picture();
                user.createUid = Convert.ToInt32(rq.CreatedByName);
                user.createTime = DateTime.Now;
            }
            user.imageUrl = rq.imageUrl;
            user.publishTime = rq.publishTime == null ? DateTime.Now :Convert.ToDateTime(rq.publishTime);
            user.sequence = rq.sequence;
            user.status = rq.publishTime == null ? 1 : rq.status;
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

        /// <summary>
        /// 获客助手：图片详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public CustomerToolsItemRS GetDetailTool(CustomerToolsRQ rq)
        {
            var condition = new CustomerToolsRQ()
            {
                pageIndex = 1,
                pageSize = Int32.MaxValue,
                id = rq.id
            };
            var list = GetTools(condition).list;
            var result = list == null ? new CustomerToolsItemRS() : list.Where(q => q.id == rq.id).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// 获客助手：发文章列表
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
                             a.modifyName
                         });
            result.total = Article.FindAll(sql, null, null, 0, 0).Count;
            if (result.total == 0) return result;
            result.list = query.Select(a => new ArticleListItemRS
            {
                content=a.content,
                contentUrl=a.contentUrl,
                createTime=a.createTime,
                createUid=a.createUid,
                id=a.id,
                listUrl=a.listUrl,
                modifyUid=a.modifyUid,
                publishTime=a.publishTime,
                shareTitle=a.shareTitle,
                shareUrl=a.shareUrl,
                status=a.status,
                title=a.title,
                type=a.type,
                updateTime=a.updateTime,
                modifyName=a.modifyName
            }).ToList();
            return result;
        }

        /// <summary>
        /// 获客助手：发文章
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
            user.modifyUid = rq.createUid;
            user.publishTime = rq.publishTime == null ? DateTime.Now : Convert.ToDateTime(rq.publishTime);
            user.shareTitle = rq.shareTitle;
            user.shareUrl = rq.shareUrl;
            user.status = rq.publishTime == null ? 1 : rq.status;
            user.title = rq.title;
            user.type = rq.type;
            user.updateTime = DateTime.Now;
            user.modifyName = rq.modifyName;
            users.Add(user);
            int nCount = users.Save();
            return new ResultModel<string>
            {
                state = nCount,
                message = nCount > 0 ? "保存成功！" : "操作失败！",
                data = nCount.ToString()
            };
        }

        /// <summary>
        /// 获客助手：发文章详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ArticleListItemRS GetDetailArticle(ArticleListRQ rq)
        {
            var condition = new ArticleListRQ()
            {
                pageIndex = 1,
                pageSize = Int32.MaxValue,
                id = rq.id
            };
            var list = GetArticles(condition).list;
            var result = list == null ? new ArticleListItemRS() : list.Where(q => q.id == rq.id).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<string> DeleteTool(CustomerToolsRQ rq)
        {
            var obj = Picture.FindByid(rq.id);
            int nCount = obj.Delete();
            return new ResultModel<string>
            {
                state = nCount,
                message = nCount > 0 ? "删除成功！" : "操作失败！",
                data = nCount.ToString()
            };
        }


        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns
        public ResultModel<string> DeleteArticle(ArticleListRQ rq)
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
    }
}
