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
    /// 资讯管理接口定义
    /// 创建人：朱斌
    /// 创建时间：2017-05-01
    /// </summary>
    public interface IArticleService
    {
        /// <summary>
        /// 资讯管理列表
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ArticleListRS GetArticles(ArticleListRQ rq);

        ResultModel<string> DelArticles(SaveArticleRQ rq);

        /// <summary>
        /// 保存资讯信息
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<string> SaveArticles(SaveArticleRQ rq);
    }
}
