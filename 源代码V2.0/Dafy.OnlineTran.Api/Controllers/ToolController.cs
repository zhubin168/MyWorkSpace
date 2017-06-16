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
    /// 获客助手管理
    /// 创建人：朱斌
    /// 创建时间：2017-05-01
    /// </summary>
    [AllowAnonymous]
    public class ToolController : AuthController
    {
        private readonly ICustomerToolService _service;
        /// <summary>
        /// 注入service
        /// </summary>
        public ToolController(ICustomerToolService service)
        {
            _service = service;
        }

        /// <summary>
        /// 获客助手：图片管理
        /// </summary>
        [HttpPost]
        public CustomerToolsRS GetTools(CustomerToolsRQ rq)
        {
            if (rq == null || rq.pageIndex <= 0 || rq.pageSize <= 0)
                return new CustomerToolsRS { total = 0, list = null };
            return _service.GetTools(rq);
        }

        /// <summary>
        /// 获客助手：图片详情
        /// </summary>
        [HttpPost]
        public CustomerToolsItemRS GetDetailTool(CustomerToolsRQ rq)
        {
            return _service.GetDetailTool(rq);
        }

        /// <summary>
        /// 获客助手：图片保存
        /// </summary>
        [HttpPost]
        public ResultModel<string> SaveTools(SaveCustomerToolsRQ rq)
        {
            rq.CreatedByName = this.User.Identity.Name;
            return _service.SaveTools(rq);
        }

        /// <summary>
        /// 获客助手：发文章列表
        /// </summary>
        [HttpPost]
        public ArticleListRS GetArticles(ArticleListRQ rq)
        {
            if (rq == null || rq.pageIndex <= 0 || rq.pageSize <= 0)
                return new ArticleListRS { total = 0, list = null };
            return _service.GetArticles(rq);
        }

        /// <summary>
        /// 获客助手：发文章
        /// </summary>
        [HttpPost]
        public ResultModel<string> SaveArticles(SaveArticleRQ rq)
        {
            rq.createUid = Convert.ToInt32(this.User.Identity.Name);
            return _service.SaveArticles(rq);
        }

        /// <summary>
        /// 获客助手：发文章详情
        /// </summary>
        [HttpPost]
        public ArticleListItemRS GetDetailArticle(ArticleListRQ rq)
        {
            return _service.GetDetailArticle(rq);
        }

        /// <summary>
        /// 删除图片
        /// </summary>
        [HttpPost]
        public ResultModel<string> DeleteTool(CustomerToolsRQ rq)
        {
            return _service.DeleteTool(rq);
        }

        /// <summary>
        /// 删除文章
        /// </summary>
        [HttpPost]
        public ResultModel<string> DeleteArticle(ArticleListRQ rq)
        {
            return _service.DeleteArticle(rq);
        }
    }
}
