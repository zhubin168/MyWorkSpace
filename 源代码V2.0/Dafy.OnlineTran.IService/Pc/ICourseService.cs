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
    /// 课程管理接口定义
    /// 创建人：朱斌
    /// 创建时间：2017-05-01
    /// </summary>
    public interface ICourseService
    {
        /// <summary>
        /// 资讯分类管理
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        InfoCategorysRS GetInfoCategorys(InfoCategorysRQ rq);

        /// <summary>
        /// 保存资讯分类
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<string> SaveInfoCategory(InfoCategorysItemRS rq);

        /// <summary>
        /// 删除资讯分类
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<string> DeleteCategory(InfoCategorysItemRS rq);

        /// <summary>
        /// 资讯管理
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        InformationRS GetInformations(InformationRQ rq);

        /// <summary>
        /// 保存资讯
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<string> SaveInformation(InformationItemRS rq);

        /// <summary>
        /// 资讯详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        InformationItemRS GetDetailInformation(InformationRQ rq);

        /// <summary>
        /// 删除资讯
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<string> DeleteInformation(InformationRQ rq);

        /// <summary>
        /// 小知识管理
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        KnowledgeRS GetKnowledges(KnowledgeRQ rq);

        /// <summary>
        /// 保存小知识
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<string> SaveKnowledge(KnowledgeItemRS rq);

        /// <summary>
        /// 小知识详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        KnowledgeItemRS GetDetailKnowledge(KnowledgeRQ rq);

        /// <summary>
        /// 删除小知识
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<string> DeleteKnowledge(KnowledgeRQ rq);

        /// <summary>
        /// 理财师充电站
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        CourseRS GetCourses(CourseRQ rq);

        /// <summary>
        /// 保存充电站
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<string> SaveCourse(CourseItemRS rq);

        /// <summary>
        /// 充电站详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        CourseItemRS GetDetailCourse(CourseRQ rq);

        /// <summary>
        /// 删除充电站
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<string> DeleteCourse(CourseRQ rq);

        /// <summary>
        /// 首页Banner管理
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        BannerRS GetBanners(BannerRQ rq);

        /// <summary>
        /// 保存Banner
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<string> SaveBanner(BannerItemRS rq);

        /// <summary>
        /// Banner详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        BannerItemRS GetDetailBanner(BannerRQ rq);

        /// <summary>
        /// 删除Banner
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<string> DeleteBanner(BannerRQ rq);
    }
}
