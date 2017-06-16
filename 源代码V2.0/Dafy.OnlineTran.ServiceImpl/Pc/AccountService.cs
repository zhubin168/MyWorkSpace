using Dafy.OnlineTran.Common.Helpers;
using Dafy.OnlineTran.Common.Request;
using Dafy.OnlineTran.Common.Response;
using Dafy.OnlineTran.Entity.Models;
using Dafy.OnlineTran.IService.Pc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.ServiceImpl.Pc
{
    public class AccountService : IAccountService
    {
        /// <summary>
        /// 登录认证
        /// </summary>
        /// <param name="loginRQ"></param>
        /// <returns></returns>
        public SysUserList Login(LoginRQ loginRQ)
        {
            var pwd = DesCryptoUtil.Encrypt(loginRQ.password);
            var data = Users.Find(string.Format(" uname='{0}' and Password='{1}' and loginPC=1 and status=1 and auditStatus=2 ", loginRQ.userId, pwd));
            if (data == null)
            {
                return null;
            }
            //记录登录日志
            var record = new LoginRecord()
            {
                loginTime=DateTime.Now,
                uid=data.uid,
                loginMode="P",
                weixinID=data.weixinId
            };
            record.Save();
            return new SysUserList()
            { 
                Id=data.uid,
                Headimgurl=data.headerUrl,
                Nickname=data.nickName,
                Open_Id=data.weixinId,
                Password=data.password,
                RoleId=data.roleId,
                TelePhone=data.phone,
                Username=data.uname
            };
        }

        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public bool FindPassword(FindPasswordRQ rq)
        {
            var newEncryptedPassword = DesCryptoUtil.Encrypt(rq.newPassword);
            var user = Users.Find(new string[] { Users._.uname, Users._.phone }, new string[] { rq.saleId, rq.phone });
            if (user == null || user.uid <= 0)
            {
                return false;
            }
            user.password = newEncryptedPassword;
            int flag=user.Update();
            return flag > 0 ? true : false;
        }

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        public RoleListRs GetRoleList()
        {
            var roles = Roles.FindAll().ToList();
            return new RoleListRs
            {
                list = roles.Select(item => new RoleListItemRs() { 
                    roleId=item.roleId,
                    roleName=item.roleName
                }).ToList()
            };
        }

        /// <summary>
        /// 获取首页报表
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ReportRS GetReport(ReportRQ rq)
        {
            if (rq.Day != 0)
            {
                rq = new ReportRQ { StartDate = DateTime.Now.AddDays(-rq.Day).ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") };
            }
            var result = new ReportRS();
            #region 获取X轴数据
            List<string> lstDays = DateHelper.ConditionDays(rq.StartDate, rq.EndDate);
            string strDays = string.Empty;
            foreach (string day in lstDays)
            {
                strDays += "'" + day + "',";
            }
            if (string.Empty != strDays)
            {
                strDays = strDays.Substring(0, strDays.Length - 1);
                strDays = "[" + strDays + "]";
            }
            result.xDataSource = strDays;
            #endregion
            #region 获取总指标数据
            var lstNum1 = Users.FindAll(string.Format("select * from Users where roleId=0 and regTime>='{0}' and regTime<='{1}'", rq.StartDate, rq.EndDate));
            result.Num1 = lstNum1.Count;
            var lstNum2 =Users.FindAll(string.Format("select * from Users where roleId in(1,2) and regTime>='{0}' and regTime<='{1}'", rq.StartDate, rq.EndDate));
            result.Num2 = lstNum2.Count;
            var lstNum3 = Order.FindAll(string.Format("select * from [Order]  where createTime>='{0}' and createTime<='{1}'", rq.StartDate, rq.EndDate));
            result.Num3 = lstNum3.Count;
            var lstNum4 = Order.FindAll(string.Format("select * from [Order]  where createTime>='{0}' and createTime<='{1}'", rq.StartDate, rq.EndDate)).ToList();
            result.Num4 = lstNum4.Sum(q => q.total * q.prodcutPrice);

            result.Num5 = Users.FindAll("select * from Users where roleId=0 ").Count;
            result.Num6 = Users.FindAll("select * from Users where roleId in(1,2) ").Count;
            result.Num7 = Order.FindAll("select * from [Order] ").Count;
            result.Num8 = Order.FindAll("select * from [Order] ").ToList().Sum(q => q.total * q.prodcutPrice);
            #endregion
            #region 获取Y轴数据
            var yDataSource1 = "[";
            var yDataSource2 = "[";
            var yDataSource3 = "[";
            var yDataSource4 = "[";
            foreach (string day in lstDays)
            {
                yDataSource1 += lstNum1.ToList().Where(q => q.regTime.ToShortDateString() == Convert.ToDateTime(day).ToShortDateString()).Count()+",";
                yDataSource2 += lstNum2.ToList().Where(q => q.regTime.ToShortDateString() == Convert.ToDateTime(day).ToShortDateString()).Count() + ",";
                yDataSource3 += lstNum3.ToList().Where(q => q.createTime.ToShortDateString() == Convert.ToDateTime(day).ToShortDateString()).Count() + ",";
                yDataSource4 += lstNum4.ToList().Where(q => q.createTime.ToShortDateString() == Convert.ToDateTime(day).ToShortDateString()).Sum(q => q.total * q.prodcutPrice) + ",";
            }
            yDataSource1 = yDataSource1.TrimEnd(',');
            yDataSource2 = yDataSource2.TrimEnd(',');
            yDataSource3 = yDataSource3.TrimEnd(',');
            yDataSource4 = yDataSource4.TrimEnd(',');

            yDataSource1 += "]";
            yDataSource2 += "]";
            yDataSource3 += "]";
            yDataSource4 += "]";
            result.yDataSource1 = yDataSource1;
            result.yDataSource2 = yDataSource2;
            result.yDataSource3 = yDataSource3;
            result.yDataSource4 = yDataSource4;
            #endregion
            return result;
        }
    }
}
