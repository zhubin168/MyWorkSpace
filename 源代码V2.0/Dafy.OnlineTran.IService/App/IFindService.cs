using Dafy.OnlineTran.Common.Request.App;
using Dafy.OnlineTran.Common.Response;
using Dafy.OnlineTran.Common.Response.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.IService.App
{
    public interface IFindService
    {
        /// <summary>
        /// 获取个人信息
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<GetUserInfoRS> GetUserInfo(GetUserInfoRQ rq);
        /// <summary>
        /// 保存个人信息
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<string> SaveUserInfo(AppSaveUserInfoRQ rq);
        /// <summary>
        /// 获客助手：发资讯、发小知识、发鸡汤详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ArticleListItemRS GetArticleDetail(AppGetArticleDetailRQ rq);
        /// <summary>
        /// 获客助手：图片详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        CustomerToolsItemRS GetDetailTool(AppToolsDetailRQ rq);
        /// <summary>
        /// 获客助手：发资讯、发小知识、发鸡汤
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ArticleListRS GetArticles(AppArticleListRQ rq);
        /// <summary>
        /// 获客助手：图片管理
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        CustomerToolsRS GetTools(AppCustomerToolsRQ rq);
        /// <summary>
        /// 获取历史订单记录
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<AppGetOrderRS> GetOrder(AppGetOrderRQ rq);
        /// <summary>
        /// 预约产品
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<string> AddOrder(AppAddOrderRQ rq);
        /// <summary>
        /// 理财知识详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        KnowledgeItemRS GetDetailKnowledge(AppKnowledgeDetailRQ rq);
        /// <summary>
        /// 行业资讯详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        InformationItemRS GetDetailInformation(AppInformationDetailRQ rq);
        /// <summary>
        /// 热点理财师充电站
        /// </summary>
        /// <returns></returns>
        ResultModel<List<CourseItemRS>> GetHotCourse();

        /// <summary>
        /// 理财师充电站
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<CourseRS> GetCourses(AppCourseRQ rq);
        /// <summary>
        /// 产品详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        AppGetDetailProductRS GetDetailProduct(AppGetDetailProductRQ rq);
    }
}
