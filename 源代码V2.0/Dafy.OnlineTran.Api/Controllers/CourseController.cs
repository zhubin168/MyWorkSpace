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
    /// 内容管理
    /// 创建人：朱斌
    /// 创建时间：2017-04-30
    /// </summary>
    [AllowAnonymous]
    public class CourseController : AuthController
    {
        private readonly ICourseService _service;
        /// <summary>
        /// 注入service
        /// </summary>
        public CourseController(ICourseService service)
        {
            _service = service;
        }

        /// <summary>
        /// 资讯分类管理
        /// </summary>
        [HttpPost]
        public InfoCategorysRS GetInfoCategorys(InfoCategorysRQ rq)
        {
            if (rq == null || rq.pageIndex <= 0 || rq.pageSize <= 0)
                return new InfoCategorysRS { total = 0, list = null };
            return _service.GetInfoCategorys(rq);
        }

        /// <summary>
        /// 保存资讯分类
        /// </summary>
        [HttpPost]
        public ResultModel<string> SaveInfoCategory(InfoCategorysItemRS rq)
        {
            rq.createUid =Convert.ToInt32(this.User.Identity.Name);
            return _service.SaveInfoCategory(rq);
        }

        /// <summary>
        /// 资讯管理
        /// </summary>
        [HttpPost]
        public InformationRS GetInformations(InformationRQ rq)
        {
            if (rq == null || rq.pageIndex <= 0 || rq.pageSize <= 0)
                return new InformationRS { total = 0, list = null };
            return _service.GetInformations(rq);
        }

        /// <summary>
        /// 保存资讯
        /// </summary>
        [HttpPost]
        public ResultModel<string> SaveInformation(InformationItemRS rq)
        {
            rq.createUid = Convert.ToInt32(this.User.Identity.Name);
            return _service.SaveInformation(rq);
        }

        /// <summary>
        /// 资讯详情
        /// </summary>
        [HttpPost]
        public InformationItemRS GetDetailInformation(InformationRQ rq)
        {
            return _service.GetDetailInformation(rq);
        }

        /// <summary>
        /// 小知识管理
        /// </summary>
        [HttpPost]
        public KnowledgeRS GetKnowledges(KnowledgeRQ rq)
        {
            if (rq == null || rq.pageIndex <= 0 || rq.pageSize <= 0)
                return new KnowledgeRS { total = 0, list = null };
            return _service.GetKnowledges(rq);
        }

        /// <summary>
        /// 保存小知识
        /// </summary>
        [HttpPost]
        public ResultModel<string> SaveKnowledge(KnowledgeItemRS rq)
        {
            rq.createUid = Convert.ToInt32(this.User.Identity.Name);
            return _service.SaveKnowledge(rq);
        }

        /// <summary>
        /// 小知识详情
        /// </summary>
        [HttpPost]
        public KnowledgeItemRS GetDetailKnowledge(KnowledgeRQ rq)
        {
            return _service.GetDetailKnowledge(rq);
        }

        /// <summary>
        /// 理财师充电站
        /// </summary>
        [HttpPost]
        public CourseRS GetCourses(CourseRQ rq)
        {
            if (rq == null || rq.pageIndex <= 0 || rq.pageSize <= 0)
                return new CourseRS { total = 0, list = null };
            return _service.GetCourses(rq);
        }

        /// <summary>
        /// 保存充电站
        /// </summary>
        [HttpPost]
        public ResultModel<string> SaveCourse(CourseItemRS rq)
        {
            rq.createUid = Convert.ToInt32(this.User.Identity.Name);
            return _service.SaveCourse(rq);
        }

        /// <summary>
        /// 充电站详情
        /// </summary>
        [HttpPost]
        public CourseItemRS GetDetailCourse(CourseRQ rq)
        {
            return _service.GetDetailCourse(rq);
        }

        /// <summary>
        /// Banner管理
        /// </summary>
        [HttpPost]
        public BannerRS GetBanners(BannerRQ rq)
        {
            if (rq == null || rq.pageIndex <= 0 || rq.pageSize <= 0)
                return new BannerRS { total = 0, list = null };
            return _service.GetBanners(rq);
        }

        /// <summary>
        /// 保存Banner
        /// </summary>
        [HttpPost]
        public ResultModel<string> SaveBanner(BannerItemRS rq)
        {
            rq.createUid = Convert.ToInt32(this.User.Identity.Name);
            return _service.SaveBanner(rq);
        }

        /// <summary>
        /// Banner详情
        /// </summary>
        [HttpPost]
        public BannerItemRS GetDetailBanner(BannerRQ rq)
        {
            return _service.GetDetailBanner(rq);
        }

        /// <summary>
        /// 删除资讯分类
        /// </summary>
        [HttpPost]
        public ResultModel<string> DeleteCategory(InfoCategorysItemRS rq)
        {
            return _service.DeleteCategory(rq);
        }

        /// <summary>
        /// 删除资讯
        /// </summary>
        [HttpPost]
        public ResultModel<string> DeleteInformation(InformationRQ rq)
        {
            return _service.DeleteInformation(rq);
        }

        /// <summary>
        /// 删除小知识
        /// </summary>
        [HttpPost]
        public ResultModel<string> DeleteKnowledge(KnowledgeRQ rq)
        {
            return _service.DeleteKnowledge(rq);
        }

        /// <summary>
        /// 删除充电站
        /// </summary>
        [HttpPost]
        public ResultModel<string> DeleteCourse(CourseRQ rq)
        {
            return _service.DeleteCourse(rq);
        }

        /// <summary>
        /// 删除Banner
        /// </summary>
        [HttpPost]
        public ResultModel<string> DeleteBanner(BannerRQ rq)
        {
            return _service.DeleteBanner(rq);
        }
    }
}
