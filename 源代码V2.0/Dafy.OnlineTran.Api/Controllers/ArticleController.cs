using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using Dafy.OnlineTran.Common.Response;
using Dafy.OnlineTran.IService.Pc;
using Dafy.OnlineTran.Common.Request;

namespace Dafy.OnlineTran.Api.Controllers
{
    /// <summary>
    /// 资讯管理
    /// 创建人：朱斌
    /// 创建时间：2017-05-01
    /// </summary>
    [AllowAnonymous]
    public class ArticleController : AuthController
    {
        private readonly IArticleService _service;
        /// <summary>
        /// 注入service getArticles
        /// </summary>
        public ArticleController(IArticleService service)
        {
            _service = service;
        }

        /// <summary>
        /// 资讯管理列表
        /// </summary>
        [HttpPost]
        public ArticleListRS GetArticles(ArticleListRQ rq)
        {
            if (rq == null || rq.pageIndex <= 0 || rq.pageSize <= 0)
                return new ArticleListRS { total = 0, list = null };
            return _service.GetArticles(rq);
        }

        /// <summary>
        /// 删除资讯信息
        /// </summary>
        [HttpPost]
        public ResultModel<string> DelArticles(SaveArticleRQ rq)
        {
            return _service.DelArticles(rq);
        }

        /// <summary>
        /// 保存资讯信息
        /// </summary>
        [HttpPost]
        public ResultModel<string> SaveArticles(SaveArticleRQ rq)
        {
            return _service.SaveArticles(rq);
        }
    }
}
