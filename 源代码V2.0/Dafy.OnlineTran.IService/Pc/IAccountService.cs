using Dafy.OnlineTran.Common.Request;
using Dafy.OnlineTran.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.IService.Pc
{
    public interface IAccountService
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginRQ"></param>
        /// <returns></returns>
        SysUserList Login(LoginRQ loginRQ);

        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        bool FindPassword(FindPasswordRQ rq);

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        RoleListRs GetRoleList();

        /// <summary>
        /// 获取首页报表
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ReportRS GetReport(ReportRQ rq);
    }
}
