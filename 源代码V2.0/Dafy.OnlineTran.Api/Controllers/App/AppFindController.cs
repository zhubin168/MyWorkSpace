using Dafy.OnlineTran.Common.Request.App;
using Dafy.OnlineTran.Common.Response;
using Dafy.OnlineTran.Common.Response.App;
using Dafy.OnlineTran.IService.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;

namespace Dafy.OnlineTran.Api.Controllers.App
{
    public class AppFindController : AuthController
    {
        IFindService _findService;
        public AppFindController(IFindService findService)
        {
            _findService = findService;
        }
        /// <summary>
        /// 获取个人信息
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultModel<GetUserInfoRS> GetUserInfo(GetUserInfoRQ rq)
        {
            return _findService.GetUserInfo(rq);
        }
        /// <summary>
        /// 保存个人信息
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultModel<string> SaveUserInfo(AppSaveUserInfoRQ rq)
        {
            var result = new ResultModel<string>
            {
                state = 0,
                data = "",
                message = ""
            };
            try
            {
                if (string.IsNullOrEmpty(rq.userName))
                {
                    result.message = "请输入姓名!";
                    return result;
                }
                if (string.IsNullOrEmpty(rq.phone))
                {
                    result.message = "请输入手机号码!";
                    return result;
                }
                else if (!Regex.IsMatch(rq.phone, @"^[1]+[3,5,4,7,8]+\d{9}"))
                {
                    result.message = "手机号码格式不正确!";
                    return result;
                }
                //var userId = 0;
                //int.TryParse(this.User.Identity.Name,out userId);
                //rq.uId = userId;
                return _findService.SaveUserInfo(rq);
            }
            catch (Exception ex)
            {
                result.state = 0;
                result.data = "";
                result.message = "预约出现异常,请稍后在试!";
            }
            return result;
        }
        /// <summary>
        /// 获客助手：发资讯、发小知识、发鸡汤详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ArticleListItemRS GetArticleDetail(AppGetArticleDetailRQ rq)
        {
            return _findService.GetArticleDetail(rq);
        }
        /// <summary>
        /// 获客助手：图片详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public CustomerToolsItemRS GetDetailTool(AppToolsDetailRQ rq)
        {
            return _findService.GetDetailTool(rq);
        }
        /// <summary>
        /// 获客助手：发资讯、发小知识、发鸡汤
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        [HttpPost]
        public ArticleListRS GetArticles(AppArticleListRQ rq)
        {
            if (rq == null || rq.pageIndex <= 0 || rq.pageSize <= 0)
                return new ArticleListRS { total = 0, list = null };
            return _findService.GetArticles(rq);
        }
        /// <summary>
        /// 获客助手：发图片
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public CustomerToolsRS GetTools(AppCustomerToolsRQ rq)
        {
            if (rq == null || rq.pageIndex <= 0 || rq.pageSize <= 0)
                return new CustomerToolsRS { total = 0, list = null };
            return _findService.GetTools(rq);
        }
        /// <summary>
        /// 获取历史订单记录
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultModel<AppGetOrderRS> GetOrder(AppGetOrderRQ rq)
        {
            var userId = 0;
            int.TryParse(this.User.Identity.Name, out userId);
            rq.uId = userId;
            return _findService.GetOrder(rq);
        }
        /// <summary>
        /// 预约产品
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultModel<string> AddOrder(AppAddOrderRQ rq)
        {
            var result = new ResultModel<string>
            {
                state = 0,
                data = "",
                message = ""
            };
            try
            {
                if (string.IsNullOrEmpty(rq.userName))
                {
                    result.message = "请输入姓名!";
                    return result;
                }
                if (string.IsNullOrEmpty(rq.phone))
                {
                    result.message = "请输入手机号码!";
                    return result;
                }else if(!Regex.IsMatch(rq.phone, @"^[1]+[3,5,4,7,8]+\d{9}")){
                    result.message = "手机号码格式不正确!";
                    return result;
                }
                var userId = 0;
                int.TryParse(this.User.Identity.Name, out userId);
                rq.uId = userId;
                return _findService.AddOrder(rq);
            }
            catch (Exception ex)
            {
                result.state = 0;
                result.data = "";
                result.message = "预约出现异常,请稍后在试!";
            }
            return result;
        }

        /// <summary>
        /// 理财知识详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ResultModel<KnowledgeItemRS> GetDetailKnowledge(AppKnowledgeDetailRQ rq)
        {
            var result = new ResultModel<KnowledgeItemRS>
            {
                state = 0,
                data = null,
                message = "获取理财知识详情失败!"
            };
            var model = _findService.GetDetailKnowledge(rq);
            if (model != null)
            {
                result.state = 1;
                result.data = model;
                result.message = "获取理财知识详情成功!";
            }
            return result;
        }
        /// <summary>
        /// 行业资讯详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ResultModel<InformationItemRS> GetDetailInformation(AppInformationDetailRQ rq)
        {
            var result = new ResultModel<InformationItemRS>
            {
                state = 0,
                data = null,
                message = "获取产品详情失败!"
            };
            var model = _findService.GetDetailInformation(rq);
            if (model != null)
            {
                result.state = 1;
                result.data = model;
                result.message = "获取资讯详情成功";
            }
            return result;
        }
        /// <summary>
        /// 理财师充电站
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultModel<CourseRS> GetCourses(AppCourseRQ rq)
        {
            return _findService.GetCourses(rq);
        }
        /// <summary>
        /// 热点理财师充电站
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultModel<List<CourseItemRS>> GetHotCourse()
        {
            return _findService.GetHotCourse();
        }
        /// <summary>
        /// 产品详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ResultModel<AppGetDetailProductRS> GetDetailProduct(AppGetDetailProductRQ rq)
        {
            var result = new ResultModel<AppGetDetailProductRS>
            {
                state = 0,
                data = null,
                message = "获取产品详情失败!"
            };
            try
            {
                var product = _findService.GetDetailProduct(rq);
                if (product != null)
                {
                    result.state = 1;
                    result.data = product;
                    result.message = "获取产品详情成功!";
                }
            }
            catch (Exception ex)
            {
                result.message = "获取产品详情出现异常!";
            }
            return result;
        }
    }
}