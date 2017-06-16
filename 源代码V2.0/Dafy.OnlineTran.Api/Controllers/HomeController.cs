using System;
using Dafy.OnlineTran.Common;
using Dafy.OnlineTran.IService;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using System.Net.Http;
using Dafy.OnlineTran.Common.Helpers;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security;
using Dafy.OnlineTran.Entity.Models;
using Dafy.OnlineTran.Common.Request;
using Dafy.OnlineTran.Common.Response;
using Dafy.OnlineTran.IService.Pc;

namespace Dafy.OnlineTran.Api.Controllers
{
    /// <summary>
    /// 用户认证中心
    /// </summary>
    public class HomeController : AuthController
    {
        private IAccountService _service;

        /// <summary>
        /// 注入service
        /// </summary>
        /// <param name="service"></param>
        public HomeController(IAccountService service)
        {
            _service = service;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginRQ"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResultModel<SysUserRS> Login(LoginRQ loginRQ)
        {
            var sysUserRs = new SysUserRS() { role = "", token = "", userName = "" };

            if (loginRQ == null || loginRQ.userId <= 0 || string.IsNullOrWhiteSpace(loginRQ.password))
            {
                return new ResultModel<SysUserRS> { message = "用户名和密码都不能为空", state = 0, data = sysUserRs };
            }
            var user = _service.Login(loginRQ);
            if (user == null)
            {
                return new ResultModel<SysUserRS> { message = "用户名或密码错误,请重新输入", state = 0, data = sysUserRs };
            }

            var accessToken = DesCryptoUtil.Encrypt(loginRQ.userId.ToString());

            sysUserRs.role = user.RoleId.ToString();
            sysUserRs.userName = user.Username;
            sysUserRs.token = accessToken;
            sysUserRs.userId = user.Id;

            return new ResultModel<SysUserRS> { message = "登录成功", state = 1, data = sysUserRs };
        }

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        /// <summary>
        /// 用户注销
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        public object Logout()
        {
            if (this.User == null || !this.User.Identity.IsAuthenticated)
            {
                return new { state = 1, message = "退出成功" };
            }
            else
            {
                Authentication.SignOut(OAuthDefaults.AuthenticationType);
                return new { state = 1, message = "退出成功" };
            }
        }

        /// <summary>
        /// 获取菜单接口权限
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        public AuthorityMenuRS GetAuthorityMeun()
        {
            //系统菜单
            var lstmainSystemMenu = new List<MenuAdminList>();
            lstmainSystemMenu.Add(new MenuAdminList()
            {
                id = "1",
                name = "字典管理",
                location = string.Empty,
                parentID = string.Empty
            });
            var lstchildSystemMenu = new List<MenuItemList>();
            lstchildSystemMenu.Add(new MenuItemList()
            {
                id = string.Empty,
                name = "字典列表",
                location = "/api/config/getConfigs",
                parentID = "1"
            });

            //遍历获取权限
            var menuAdminList = new List<MenuAdminList>();
            foreach (MenuAdminList main in lstmainSystemMenu)
            {
                //var menuItemList =
                //    lstchildSystemMenu.Where(q => q.parentID == main.id.ToString())
                //        .ToList();
                main.menuItemList = lstchildSystemMenu;
                menuAdminList.Add(main);
            }
            return new AuthorityMenuRS()
            {
                menuAdminList = menuAdminList
            };
        }

        /// <summary>
        /// 找回密码
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        public ResultModel<string> FindPassword(FindPasswordRQ rq)
        {
            var resultModel = new ResultModel<string>
            {
                state = 0,
                message = "",
                data = "-1"
            };
            var result = _service.FindPassword(rq);
            if (result)
            {
                resultModel.state = 1;
                resultModel.message = "设置成功";
                return resultModel;
            }
            resultModel.message = "找不到该用户";
            return resultModel;
        }

        /// <summary>
        /// 获取所有角色
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        public RoleListRs GetRoleList()
        {
            return _service.GetRoleList();
        }

        /// <summary>
        /// 获取首页报表
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        public ReportRS GetReport(ReportRQ rq)
        {
            return _service.GetReport(rq);
        }

        /// <summary>
        /// 获取快速查询的起始日期
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ReportRQ GeMyDate(ReportDateType rq)
        {
            return new ReportRQ { StartDate = DateTime.Now.AddDays(-rq.day).ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") };
        }
    }
}
