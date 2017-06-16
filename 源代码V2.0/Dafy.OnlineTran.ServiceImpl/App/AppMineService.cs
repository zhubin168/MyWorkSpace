using Dafy.OnlineTran.Common.Helpers;
using Dafy.OnlineTran.Common.Request;
using Dafy.OnlineTran.Common.Request.App;
using Dafy.OnlineTran.Common.Response;
using Dafy.OnlineTran.Common.Response.App;
using Dafy.OnlineTran.Entity.Models;
using Dafy.OnlineTran.IService.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.ServiceImpl.App
{
    public class AppMineService : IAppMineService
    {
        /// <summary>
        /// 个人中心信息
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public WeixinUserItemRS GetPersonCenter(SaleRecordRQ rq)
        {
            var data = Users.Find(Users._.uid,rq.uid);
            if (data == null)
            {
                return null;
            }
            var sumOrder = Order.FindAll("select * from [Order] where uid=" + rq.uid).ToList();
            return new WeixinUserItemRS() {
                Id = data.uid,
                Headimgurl = data.headerUrl,
                Nickname = data.nickName,
                OpenId = data.weixinId,
                Password = data.password,
                RoleId = data.roleId,
                TelePhone = data.phone,
                Username = data.uname,
                Position=data.rank,
                sumSales = sumOrder.Sum(q=>(q.prodcutPrice*q.total)),
                sumIncome = sumOrder.Sum(q => q.income)
            };
        }


        /// <summary>
        /// 设置个人头像
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<string> SetIcon(WeixinUserMineRQ rq)
        {
            var data = Users.Find(Users._.uid, rq.uid);
            data.headerUrl = rq.HeaderUrl;
            data.updateTime = DateTime.Now;
            int nCount = data.Save();
            return new ResultModel<string>
            {
                state = nCount,
                message = nCount > 0 ? "设置成功！" : "设置失败！",
                data = nCount.ToString()
            };
        }

        /// <summary>
        /// 绑定银行卡信息
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<string> SetBank(SetBankRQ rq)
        {
            try
            {
                var record = Users.Find(Users._.uid, rq.uid);
                record.idNumber = rq.ident;
                record.bankNumber = rq.cardNo;
                record.bankName = rq.bankName;
                record.bankPerson = rq.bankPerson;
                record.phone = rq.phone;
                record.updateTime = DateTime.Now;
                int nCount = record.Save();
                return new ResultModel<string>
                {
                    state = nCount,
                    message = nCount > 0 ? "设置成功！" : "设置失败！",
                    data = nCount.ToString()
                };
            }
            catch (Exception ex)
            {
                return new ResultModel<string>
                {
                    state = 0,
                    message = "设置异常：" + ex.ToString(),
                    data = "-1"
                };
            }
        }

        /// <summary>
        /// 获取所有银行
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ParameterRS GetBankNames()
        {
            var data = Dictionary.FindAll("select * from Dictionary where status=1 and para_group='bank'");
            return new ParameterRS()
            {
                list = data.ToList().Select(item => new ParameterItemRS() { 
                    paraCode=item.para_code,
                    paraName=item.para_name
                }).ToList()
            };
        }

        /// <summary>
        /// 我的销售记录 CustormDetailRS
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public SaleRecordRS SaleRecord(SaleRecordRQ rq)
        {
            var data = Order.FindAll(string.Format("select * from [Order] where uid={0}  order by createTime desc", rq.uid));
            if (data.ToList().Count == 0)
            {
                return new SaleRecordRS()
                {
                    list = null,
                    total = 0,
                    monthSumSales =0
                };
            }
            var list=data.ToList().Select(item => new SaleRecordItemRS()
                {
                    createTime=item.createTime,
                    prodcutPrice=item.prodcutPrice*item.total,
                    productName=item.productName,
                    productType=item.productType
                }).ToList();
            var startDate=DateTime.Now.AddDays(-(DateTime.Now.Day-1));
            var monthSumSales = list.Where(q => q.createTime <= DateTime.Now && q.createTime >= startDate);
            return new SaleRecordRS()
            {
                list = list,
                total=list.Count,
                monthSumSales = monthSumSales.Sum(q=>q.prodcutPrice)
            };
        }

        /// <summary>
        /// 客户详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public CustormDetailRS CustormDetail(SaleRecordRQ rq)
        {
            var user = Users.FindByuid(rq.uid);
            var data = new List<Order>();
            if (rq.roleId == 0)
            {
                data = Order.FindAll(string.Format("select * from [Order] where clientUid={0}  order by createTime desc", rq.uid));
            }
            else
            {
                data = Order.FindAll(string.Format("select * from [Order] where uid={0}  order by createTime desc", rq.uid));
            }
            if (data.ToList().Count == 0)
            {
                return new CustormDetailRS()
                {
                    list = null,
                    total = 0,
                    monthSumSales = 0,
                    Headimgurl = user.headerUrl,
                    Nickname=user.nickName,
                    regTime=user.regTime,
                    TelePhone=user.phone
                };
            }
            var list = data.ToList().Select(item => new CustormDetailItemRS()
            {
                createTime = item.createTime,
                prodcutPrice = item.prodcutPrice * item.total,
                productName = item.productName,
                productType = item.productType,
                status = item.status.ToString().Replace("0", "已预约")
               .Replace("1", "已受理")
               .Replace("2", "安排购买中")
               .Replace("3", "已完成")
               .Replace("4", "不受理")
               .Replace("5", "已中止")
            }).ToList();
            var startDate = DateTime.Now.AddDays(-(DateTime.Now.Day - 1));
            var monthSumSales = list.Where(q => q.createTime <= DateTime.Now && q.createTime >= startDate);
            return new CustormDetailRS()
            {
                list = list,
                total = list.Count,
                monthSumSales = monthSumSales.Sum(q => q.prodcutPrice),
                Headimgurl = user.headerUrl,
                Nickname = user.nickName,
                regTime = user.regTime,
                TelePhone = user.phone
            };
        }

        /// <summary>
        /// 我的预约记录
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public OrderRecordRS OrderRecord(SaleRecordRQ rq)
        {
            var data = Order.FindAll(string.Format("select * from [Order] where clientUid={0} order by createTime desc", rq.uid));
            if (data.ToList().Count == 0)
            {
                return new OrderRecordRS()
                {
                    list = null,
                    total = 0
                };
            }
            //已预约-1，已受理-2，安排购买中-3，已完成-4，不受理-5，已终止-6
            var list = data.ToList().Select(item => new OrderRecordItemRS()
            {
                createTime = item.createTime,
                prodcutPrice = item.prodcutPrice * item.total,
                productName = item.productName,
                productType = item.productType,
                status = item.status.ToString().Replace("0", "已预约")
                .Replace("1", "已受理")
                .Replace("2", "安排购买中")
                .Replace("3", "已完成")
                .Replace("4", "不受理")
                .Replace("5", "已中止")
            }).ToList();
            return new OrderRecordRS()
            {
                list = list,
                total = list.Count
            };
        }

        /// <summary>
        /// 我的理财师团队
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public MineTeamRS GetMineTeam(SaleRecordRQ rq)
        {
            var result = new MineTeamRS { total = 0, list = null,directNum=0,undirectNum=0 };
            try
            {
                var sql = " uid in(select uid from UserRelation where puid=" + rq.uid + ")";
                if (!string.IsNullOrWhiteSpace(rq.paraName))
                {
                    sql += string.Format(" and (uname like '%{0}%' or nickName like '%{0}%' or phone like '%{0}%') ", rq.paraName);
                }
                var user = Users.FindAll(sql, "uid desc", null, 0, 0);
                var query = (from a in user.ToList()
                             select new
                             {
                                 a.auditStatus,
                                 a.bankName,
                                 a.bankNumber,
                                 a.companyId,
                                 a.headerUrl,
                                 a.idNumber,
                                 a.isHasAllowance,
                                 a.loginPC,
                                 a.loginTime,
                                 a.nickName,
                                 a.password,
                                 a.phone,
                                 a.rank,
                                 a.regTime,
                                 a.roleId,
                                 a.status,
                                 a.uid,
                                 a.uname,
                                 a.updateTime,
                                 a.upgradeTime,
                                 a.weixinId,
                                 a.Company,
                                 a.PUsers,
                                 //a.ChildUsers
                             });
                result.total = Users.FindAll(sql, null, null, 0, 0).Count;
                if (result.total == 0) return result;
                result.directNum = UserRelation.FindAll("select * from UserRelation where puid=" + rq.uid).Count;
                result.undirectNum = UserRelation.FindAll("select * from UserRelation where puid in(select uid from UserRelation where puid=" + rq.uid + ")").Count;
                result.list = query.Select(a => new MineTeamItemRS
                {
                    uid=a.uid,
                    Nickname = a.nickName,
                    TelePhone = a.phone,
                    Username = a.uname,
                    Headimgurl = a.headerUrl,
                    ChildNum = UserRelation.FindAll("select * from UserRelation where puid=" + a.uid).Count
                }).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }

        /// <summary>
        /// 我的客户
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public MineCustomerRS GetMineCustomer(SaleRecordRQ rq)
        {
            var result = new MineCustomerRS { total = 0, list = null };
            try
            {
                var sql = " roleId=0 and uid in(select uid from UserRelation where puid=" + rq.uid + ")";
                if (!string.IsNullOrWhiteSpace(rq.paraName))
                {
                    sql += string.Format(" and (uname like '%{0}%' or nickName like '%{0}%' or phone like '%{0}%') ", rq.paraName);
                }
                var user = Users.FindAll(sql, "uid desc", null, 0, 0);
                var query = (from a in user.ToList()
                             select new
                             {
                                 a.auditStatus,
                                 a.bankName,
                                 a.bankNumber,
                                 a.companyId,
                                 a.headerUrl,
                                 a.idNumber,
                                 a.isHasAllowance,
                                 a.loginPC,
                                 a.loginTime,
                                 a.nickName,
                                 a.password,
                                 a.phone,
                                 a.rank,
                                 a.regTime,
                                 a.roleId,
                                 a.status,
                                 a.uid,
                                 a.uname,
                                 a.updateTime,
                                 a.upgradeTime,
                                 a.weixinId,
                                 a.Company,
                                 a.PUsers,
                                 //a.ChildUsers
                             });
                result.total = Users.FindAll(sql, null, null, 0, 0).Count;
                if (result.total == 0) return result;
                var list = query.Select(a => new MineCustomerItemRS
                {
                    Ping = EcanConvertToCh.HztoPySimple(a.nickName).ToUpper(),
                    Nickname = a.nickName,
                    TelePhone = a.phone,
                    Username = a.uname,
                    Headimgurl = a.headerUrl,
                    Uid = a.uid,
                    Number=Order.FindAll("select * from [Order] where clientUid="+a.uid).Count
                }).OrderBy(q => q.Ping).ToList();
                var lstPings = list.Select(q => q.Ping.ToUpper()).OrderBy(q => q).Distinct().ToDictionary(ping => ping, ping => list.Where(q => q.Ping == ping).Select(item => new MineCustomerItemRS
                {
                    Nickname = item.Nickname,
                    TelePhone = item.TelePhone,
                    Username = item.Username,
                    Headimgurl = item.Headimgurl,
                    Number=item.Number,
                    Uid = item.Uid
                }).ToList());
                result.list = lstPings;
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }


        /// <summary>
        /// 申请理财师认证
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<string> ApplyManager(ApplyManagerRQ rq)
        {
            try
            {
                var record = AuditRecord.Find(" auditTime is null and requestUid=" + rq.uid);
                if (record != null)
                {
                    return new ResultModel<string>
                    {
                        state =1,
                        message = "我们已收到您的申请，请耐心等待后台审核。",
                        data = "-1"
                    };
                }
                else
                {
                    record = new AuditRecord();
                }
                record.auditUid = rq.uid;
                record.auditTime = DateTime.Now;
                record.applyContent = "来自微信端申请理财师认证";

                var user = Users.FindByuid(rq.uid);
                user.auditStatus = 0;
                user.uname = rq.name;
                user.phone = rq.phone;
                user.updateTime = DateTime.Now;
                user.Save();

                int nCount = record.Save();
                return new ResultModel<string>
                {
                    state = nCount,
                    message = nCount > 0 ? "设置成功！" : "设置失败！",
                    data = nCount.ToString()
                };
            }
            catch (Exception ex)
            {
                return new ResultModel<string>
                {
                    state = 0,
                    message = "设置异常：" + ex.ToString(),
                    data = "-1"
                };
            }
        }

        /// <summary>
        /// 我的理财师（上级信息）
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public MineParentItemRS GetMineParent(SaleRecordRQ rq)
        {
            var sql = " uid =(select puid from UserRelation where uid=" + rq.uid + ")";
            var user = Users.Find(sql);
            if (null == user)
            {
                return null;
            }
            return new MineParentItemRS()
            {
                Headimgurl=user.headerUrl,
                Nickname=user.nickName,
                Rank=user.rank,
                RoleId=user.roleId,
                TelePhone=user.phone,
                Remark=user.remark
            };
        }

        /// <summary>
        /// 帮助中心
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ParameterRS GetHelperQuestion()
        {
            var data = Dictionary.FindAll("select * from Dictionary where status=1 and para_group='question'");
            return new ParameterRS()
            {
                list = data.ToList().Select(item => new ParameterItemRS()
                {
                    paraCode = item.para_code,
                    paraName = item.para_name
                }).ToList()
            };
        }

        /// <summary>
        /// 收益明细
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public IncomeRecordRS IncomeRecord(SaleRecordRQ rq)
        {
            var user = Users.FindByuid(rq.uid);
            var data = Order.FindAll(string.Format("select sum(rate1) rate1,sum(rate2) rate2,sum(rate3) rate3,sum(rate4) rate4,sum(income) income,month(createTime) record from [Order] where  year(createTime)=year(GETDATE()) and uid={0} group by month(createTime)", rq.uid));
            if (data.ToList().Count == 0)
            {
                return new IncomeRecordRS()
                {
                    list = null,
                    total = 0,
                    sumIncomes=0
                };
            }
            var list = data.ToList().Select(item => new IncomeRecordItemRS()
            {
                moth=DateTime.Now.Year+"年"+item.record,
                rate1=item.rate1,
                rate2=item.rate2,
                rate3=item.rate3,
                rate4=item.rate4,
                income=item.income
            }).ToList();
            return new IncomeRecordRS()
            {
                list = list,
                total = list.Count,
                sumIncomes = list.Sum(q=>q.income)
            };
        }
    }
}
