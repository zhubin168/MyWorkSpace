using Dafy.OnlineTran.Common.Request;
using Dafy.OnlineTran.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.IService.Pc
{
    /// <summary>
    /// 获客助手管理实现类 
    /// 创建人：朱斌
    /// 创建时间：2017-05-01
    /// </summary>
    public interface ICustomerToolService
    {
        /// <summary>
        /// 获客助手：图片管理
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        CustomerToolsRS GetTools(CustomerToolsRQ rq);

        /// <summary>
        /// 获客助手：图片保存
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<string> SaveTools(SaveCustomerToolsRQ rq);

        /// <summary>
        /// 获客助手：图片详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        CustomerToolsItemRS GetDetailTool(CustomerToolsRQ rq);

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<string> DeleteTool(CustomerToolsRQ rq);

        /// <summary>
        /// 获客助手：发文章列表
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ArticleListRS GetArticles(ArticleListRQ rq);

        /// <summary>
        /// 获客助手：发文章
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<string> SaveArticles(SaveArticleRQ rq);

        /// <summary>
        /// 获客助手：发文章详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ArticleListItemRS GetDetailArticle(ArticleListRQ rq);

        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<string> DeleteArticle(ArticleListRQ rq);
    }
}
