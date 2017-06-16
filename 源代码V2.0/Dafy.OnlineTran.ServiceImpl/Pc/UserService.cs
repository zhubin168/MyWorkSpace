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
using XCode;
using System.Configuration;

namespace Dafy.OnlineTran.ServiceImpl.Pc
{
    /// <summary>
    /// 理财师管理仓储实现
    /// 创建人：朱斌
    /// 创建时间：2017-04-30
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// 理财师管理列表
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>

        public WeixinUserRS GetUsers(WeixinUserRQ rq)
        {
            var result = new WeixinUserRS { total = 0, list = null };
            try
            {
                var sql = " roleId= "+rq.roleId;
                if (!string.IsNullOrWhiteSpace(rq.paraName))
                {
                    sql += string.Format(" and (uname like '%{0}%' or nickName like '%{0}%' or phone like '%{0}%') ", rq.paraName);
                }
                var user = Users.FindAll(sql, "uid desc", null, (rq.pageIndex - 1) * rq.pageSize, rq.pageSize);
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
                                 a.PUsers
                             });
                result.total = Users.FindAll(sql, null, null, 0, 0).Count;
                if (result.total == 0) return result;
                result.list = query.Select(a => new WeixinUserItemRS
                {
                    Headimgurl = a.headerUrl,
                    Id = a.uid,
                    Nickname = a.nickName,
                    OpenId = a.weixinId,
                    Password = a.password,
                    RoleId = a.roleId,
                    TelePhone = a.phone,
                    Username = a.uname,
                    Ident = a.idNumber,
                    CardNo = a.bankNumber,
                    BankName = a.bankName,
                    Company =a.Company==null?string.Empty: a.Company.CompanyName,
                    CompCity = a.Company == null ? string.Empty : a.Company.CityId,
                    Department = a.Company == null ? string.Empty : a.Company.DepartmentName,
                    Position = a.Company == null ? string.Empty : a.Company.Postion,
                    RegisterTime = a.regTime,
                    LogTime = a.loginTime,
                    PUsername = a.PUsers==null?string.Empty:a.PUsers.uname,
                    PTelePhone = a.PUsers == null ? string.Empty : a.PUsers.phone
                }).ToList();
            }
            catch (Exception ex)
            {
                
                throw;
            }
            return result;
        }

        /// <summary>
        /// 设为理财师
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<string> SetUsers(UpdateWeixinUserRQ rq)
        {
            try
            {
                //var record = AuditRecord.Find(" auditTime is null and requestUid=" + rq.Id);
                //if (null == record)
                //{
                //    record = new AuditRecord()
                //    {
                //        requestUid = rq.Id,
                //        createTime = DateTime.Now,
                //        applyContent = "申请理财师",
                //    };
                //}
                //else
                //{
                //     record.requestUid = rq.Id;
                //     record.createTime = DateTime.Now;
                //     record.applyContent = "申请理财师";
                //}
                //int nCount =record.Save();
                var user = Users.FindByuid(rq.Id);
                user.auditStatus = 1;
                user.roleId = 1;
                user.updateTime = DateTime.Now;
                var nCount=user.Save();
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
                    message = "设置异常："+ex.ToString(),
                    data = "-1"
                };
            }
        }

        /// <summary>
        /// 理财师管理列表
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public WeixinUserRS GetManagers(WeixinUserRQ rq)
        {
            var result = new WeixinUserRS { total = 0, list = null };
            try
            {
                var sql = " roleId= " + rq.roleId;
                if (!string.IsNullOrWhiteSpace(rq.paraName))
                {
                    sql += string.Format(" and (uname like '%{0}%' or nickName like '%{0}%' or phone like '%{0}%') ", rq.paraName);
                }
                if (!string.IsNullOrEmpty(rq.regStartDate) && !string.IsNullOrEmpty(rq.regEndDate))
                {
                    sql += string.Format(" and (regTime>='{0}' and regTime<='{1}') ", rq.regStartDate,rq.regEndDate);
                }
                var user = Users.FindAll(sql, "uid desc", null, (rq.pageIndex - 1) * rq.pageSize, rq.pageSize);
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
                result.list = query.Select(a => new WeixinUserItemRS
                {
                    Headimgurl = a.headerUrl,
                    Id = a.uid,
                    Nickname = a.nickName,
                    OpenId = a.weixinId,
                    Password = a.password,
                    RoleId = a.roleId,
                    TelePhone = a.phone,
                    Username = a.uname,
                    Ident = a.idNumber,
                    CardNo = a.bankNumber,
                    BankName = a.bankName,
                    Company = a.Company == null ? string.Empty : a.Company.CompanyName,
                    CompCity = a.Company == null ? string.Empty : a.Company.CityId,
                    Department = a.Company == null ? string.Empty : a.Company.DepartmentName,
                    Position = a.Company == null ? string.Empty : a.Company.Postion,
                    RegisterTime = a.regTime,
                    LogTime = a.loginTime,
                    PUsername = a.PUsers == null ? string.Empty : a.PUsers.uname,
                    PTelePhone = a.PUsers == null ? string.Empty : a.PUsers.phone,
                    Rank=a.rank,
                    isHasAllowance=a.isHasAllowance,
                    //CustormNums = (a.ChildUsers != null && a.ChildUsers.Where(q => q.roleId == 0)!=null) ? a.ChildUsers.Where(q => q.roleId == 0).Count():0,
                    //MemberNums =(a.ChildUsers != null && a.ChildUsers.Where(q => q.roleId != 0)!=null) ?  a.ChildUsers.Where(q => q.roleId != 0).Count():0
                }).ToList();
                var resultLst = new List<WeixinUserItemRS>();
                foreach (var item in result.list)
                {
                    var childUsers = Users.FindAll(string.Format("select * from Users where roleId=0 and uid in(select uid from UserRelation where pUid={0})", item.Id));
                    var childUsers2 = Users.FindAll(string.Format("select * from Users where roleId>0 and uid in(select uid from UserRelation where pUid={0})", item.Id));
                    item.CustormNums =childUsers==null?0:childUsers.ToList().Count;
                    item.MemberNums = childUsers2 == null ? 0 : childUsers2.ToList().Count;
                    resultLst.Add(item);
                }
                result.list = resultLst;
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }

        /// <summary>
        /// 渠道管理列表
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public WeixinUserRS GetChannels(WeixinUserRQ rq)
        {
            var result = new WeixinUserRS { total = 0, list = null };
            try
            {
                var sql = " roleId= " + rq.roleId;
                if (!string.IsNullOrWhiteSpace(rq.paraName))
                {
                    sql += string.Format(" and (uname like '%{0}%' or nickName like '%{0}%' or phone like '%{0}%') ", rq.paraName);
                }
                if (!string.IsNullOrEmpty(rq.regStartDate) && !string.IsNullOrEmpty(rq.regEndDate))
                {
                    sql += string.Format(" and (regTime>='{0}' and regTime<='{1}') ", rq.regStartDate, rq.regEndDate);
                }
                var user = Users.FindAll(sql, "uid desc", null, (rq.pageIndex - 1) * rq.pageSize, rq.pageSize);
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
                result.list = query.Select(a => new WeixinUserItemRS
                {
                    Headimgurl = a.headerUrl,
                    Id = a.uid,
                    Nickname = a.nickName,
                    OpenId = a.weixinId,
                    Password = a.password,
                    RoleId = a.roleId,
                    TelePhone = a.phone,
                    Username = a.uname,
                    Ident = a.idNumber,
                    CardNo = a.bankNumber,
                    BankName = a.bankName,
                    CompanyId=a.companyId,
                    Company = a.Company == null ? string.Empty : a.Company.CompanyName,
                    CompCity = a.Company == null ? string.Empty : a.Company.CityId,
                    Department = a.Company == null ? string.Empty : a.Company.DepartmentName,
                    Position = a.Company == null ? string.Empty : a.Company.Postion,
                    RegisterTime = a.regTime,
                    LogTime = a.loginTime,
                    PUsername = a.PUsers == null ? string.Empty : a.PUsers.uname,
                    PTelePhone = a.PUsers == null ? string.Empty : a.PUsers.phone,
                    Rank = a.rank,
                    isHasAllowance = a.isHasAllowance,
                }).ToList();
                var resultLst = new List<WeixinUserItemRS>();
                foreach (var item in result.list)
                {
                    var childUsers = Users.FindAll(string.Format("select * from Users where roleId=0 and uid in(select uid from UserRelation where pUid={0})", item.Id));
                    var childUsers2 = Users.FindAll(string.Format("select * from Users where roleId>0 and uid in(select uid from UserRelation where pUid={0})", item.Id));
                    item.CustormNums = childUsers == null ? 0 : childUsers.ToList().Count;
                    item.MemberNums = childUsers2 == null ? 0 : childUsers2.ToList().Count;
                    resultLst.Add(item);
                }
                result.list = resultLst;
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }

        /// <summary>
        /// 理财师详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public WeixinUserItemRS DetailManager(DetailUserRQ rq)
        {
            var condition=new WeixinUserRQ(){
                pageIndex=1,
                pageSize=Int32.MaxValue,
                roleId=rq.roleId
            };
            var list=GetChannels(condition).list;
            var result = list == null ? new WeixinUserItemRS() : list.Where(q => q.Id == rq.id).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// 渠道详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public WeixinUserItemRS DetailChannel(DetailUserRQ rq)
        {
            var condition = new WeixinUserRQ()
            {
                pageIndex = 1,
                pageSize = Int32.MaxValue,
                roleId = rq.roleId
            };
            var list = GetChannels(condition).list;
            var result =list==null?new WeixinUserItemRS():list.Where(q => q.Id == rq.id).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// 编辑任务津贴
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<string> SetAllowance(DetailUserRQ rq)
        {
            try
            {
                var record = Users.FindByuid(rq.id);
                record.isHasAllowance = rq.isHasAllowance;
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
        /// 编辑银行卡信息
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<string> SetBank(DetailUserRQ rq)
        {
            try
            {
                var record = Users.FindByuid(rq.id);
                record.idNumber = rq.ident;
                record.bankNumber = rq.cardNo;
                record.bankName = rq.bankName;
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
        /// 更改上级
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<string> SetRelation(DetailUserRQ rq)
        {
            try
            {
                var record = Users.Find(Users._.uname,rq.userName);
                if (record == null)
                {
                    return new ResultModel<string>
                    {
                        state = 0,
                        message = "理财师不存在",
                        data = "-1"
                    };
                }
                var relation = new UserRelation()
                {
                    uid=rq.id,
                    pUid=record.uid,
                    bindSource="P",
                    bingTime=DateTime.Now,
                    createTime=DateTime.Now,
                    updateTime=DateTime.Now
                };
                int nCount = relation.Save();
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
        /// 获取绑定操作记录
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public BindRecordRS GetBindRecord(BindRecordRQ rq)
        {
            var record = UserRelation.FindAll("select * from UserRelation where uid="+rq.uid).ToList();
            return new BindRecordRS()
            {
                list = record.Select(a => new BindRecordItemRS
                {
                    pUid=a.pUid,
                    pUserName=Users.FindByuid(a.pUid).nickName,
                    bingTime=a.bingTime,
                    unbindTime=a.unbindTime
                }).ToList()
            };
        }

        /// <summary>
        /// 理财师机构修改
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<string> SetCompany(DetailUserRQ rq)
        {
            try
            {
                var record = Users.FindByuid(rq.id);
                var company = Company.FindById(rq.companyId);
                if (null == company)
                {
                    return new ResultModel<string>
                    {
                        state = 0,
                        message = "找不到该公司",
                        data = "-1"
                    };
                }

                if (company.CompanyName == ConfigurationManager.AppSettings["CompanyName"])
                {
                    record.roleId = 1;
                }
                else
                {
                    record.roleId = 2;
                }
                record.companyId = rq.companyId;
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
        /// 客户详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public CustormerUserRS DetailCustomer(DetailUserRQ rq)
        {
            var result = new CustormerUserRS { total = 0, list = null };
            try
            {
                var sql = " roleId=0 and uid in(select uid from UserRelation where puid="+rq.id+")";
                if (!string.IsNullOrWhiteSpace(rq.paraName))
                {
                    sql += string.Format(" and (uname like '%{0}%' or nickName like '%{0}%' or phone like '%{0}%') ", rq.paraName);
                }
                var user = Users.FindAll(sql, "uid desc", null, (rq.pageIndex - 1) * rq.pageSize, rq.pageSize);
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
                result.list = query.Select(a => new CustormerUserItemRS
                {
                    Id = a.uid,
                    Nickname = a.nickName,
                    TelePhone = a.phone,
                    Username = a.uname,
                    Ident = a.idNumber,
                    Resource =UserRelation.Find(" uid="+a.uid)==null?string.Empty:UserRelation.Find(" uid="+a.uid).bindSource,
                    BindDate = a.upgradeTime,
                    Nums1 = Order.FindAll("select * from [Order] where uid=" + a.uid).ToList().Sum(q => (q.prodcutPrice * q.total)),
                    Nums2 = Order.FindAll("select * from [Order] where uid=" + a.uid).ToList().Count,
                    Nums3 = Order.FindAll("select * from [Order] where status<3 and uid=" + a.uid).ToList().Sum(q => (q.prodcutPrice * q.total)),
                    Nums4 = Order.FindAll("select * from [Order] where status<3 and uid=" + a.uid).ToList().Count,
                    Nums5 = Order.FindAll("select * from [Order] where uid=" + a.uid).ToList().Sum(q => (q.prodcutPrice * q.total)),
                }).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }

        /// <summary>
        /// 团队详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public DetailMemberRS DetailMember(DetailMemberRQ rq)
        {
            var result = new DetailMemberRS { total = 0, list = null };
            try
            {
                var sql = " roleId= " + rq.roleId;
                if (!string.IsNullOrWhiteSpace(rq.paraName))
                {
                    sql += string.Format(" and (uname like '%{0}%' or nickName like '%{0}%' or phone like '%{0}%') ", rq.paraName);
                }
                var user = Users.FindAll(sql, "uid desc", null, (rq.pageIndex - 1) * rq.pageSize, rq.pageSize);
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
                result.list = query.Select(a => new DetailMemberItemRS
                {
                    telePhone = a.phone,
                    username = a.uname,
                    bindDate = a.upgradeTime,
                    relation="",
                    nums1 = Order.FindAll("select * from [Order] where uid=" + a.uid).ToList().Sum(q => (q.prodcutPrice * q.total)),
                    nums2 = Order.FindAll("select * from [Order] where uid=" + a.uid).ToList().Count,
                    nums3 = Order.FindAll("select * from [Order] where uid=" + a.uid).ToList().Sum(q => (q.prodcutPrice * q.total)),
                }).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }

        /// <summary>
        /// 公司详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public CompanyRs DetailCompany(CompanyRQ rq)
        {
            var obj = Company.FindById(rq.Id);
            if (null == obj)
            {
                return null;
            }
            //var city= BaseCity.FindByCityID(Convert.ToInt32(obj.CityId));
            return new CompanyRs() {
                Id=obj.Id,
                CompanyName=obj.CompanyName,
                DepartmentName=obj.DepartmentName,
                CityId=obj.CityId,
                Postion=obj.Postion,
            };
        }

        /// <summary>
        /// 理财师业绩
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public AllowanceRs GetAllowances(AllowanceRQ rq)
        {
            var result = new AllowanceRs { total = 0, list = null };
            try
            {
                var sql = " roleId= " + rq.roleId;
                if (!string.IsNullOrWhiteSpace(rq.paraName))
                {
                    sql += string.Format(" and (uname like '%{0}%' or nickName like '%{0}%' or phone like '%{0}%') ", rq.paraName);
                }
                var user = Users.FindAll(sql, "uid desc", null, (rq.pageIndex - 1) * rq.pageSize, rq.pageSize);
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
                result.list = query.Select(a => new AllowanceItemRs
                {
                    id=a.uid,
                    userName=a.uname,
                    telphone=a.phone,
                    salesNums = Order.FindAll("select * from [Order] where uid=" + a.uid).ToList().Sum(q => (q.prodcutPrice * q.total)),
                    monthNums = Order.FindAll("select * from [Order] where datediff(Month,createTime,getdate())=0 and uid=" + a.uid).ToList().Sum(q => (q.prodcutPrice * q.total))
                }).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }

        /// <summary>
        /// 理财师业绩详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public AllowanceDetailRs GetDetailAllowances(AllowanceDetailRQ rq)
        {
            var result = new AllowanceDetailRs { total = 0, list = null };
            try
            {
                var sql = " uid in(select uid from UserRelation where puid=" + rq.id + ")";
                if (!string.IsNullOrWhiteSpace(rq.paraName))
                {
                    sql += string.Format(" and (uname like '%{0}%' or nickName like '%{0}%' or phone like '%{0}%') ", rq.paraName);
                }
                var user = Users.FindAll(sql, "uid desc", null, (rq.pageIndex - 1) * rq.pageSize, rq.pageSize);
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
                result.list = query.Select(a => new AllowanceDetailItemRs
                {
                    userName = a.uname,
                    telphone = a.phone,
                    salesNums = Order.FindAll("select * from [Order] where uid=" + a.uid).ToList().Sum(q => (q.prodcutPrice * q.total)),
                    productName="",
                    productType="",
                    buyTime=DateTime.Now
                }).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }

        /// <summary>
        /// 理财师收益
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public AllowanceRs GetIncomes(AllowanceRQ rq)
        {
            var result = new AllowanceRs { total = 0, list = null };
            try
            {
                var sql = " roleId= " + rq.roleId;
                if (!string.IsNullOrWhiteSpace(rq.paraName))
                {
                    sql += string.Format(" and (uname like '%{0}%' or nickName like '%{0}%' or phone like '%{0}%') ", rq.paraName);
                }
                var user = Users.FindAll(sql, "uid desc", null, (rq.pageIndex - 1) * rq.pageSize, rq.pageSize);
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
                result.list = query.Select(a => new AllowanceItemRs
                {
                    id = a.uid,
                    userName = a.uname,
                    telphone = a.phone,
                    salesNums = Order.FindAll("select * from [Order] where  uid=" + a.uid).ToList().Sum(q => q.income),
                    monthNums = Order.FindAll("select * from [Order] where datediff(Month,createTime,getdate())=0 and uid=" + a.uid).ToList().Sum(q => q.income)
                }).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }

        /// <summary>
        /// 理财师收益详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public AllowanceDetailRs GetDetailIncomes(AllowanceDetailRQ rq)
        {
            var result = new AllowanceDetailRs { total = 0, list = null };
            try
            {
                var sql = " uid in(select uid from UserRelation where puid=" + rq.id + ")";
                if (!string.IsNullOrWhiteSpace(rq.paraName))
                {
                    sql += string.Format(" and (uname like '%{0}%' or nickName like '%{0}%' or phone like '%{0}%') ", rq.paraName);
                }
                var user = Users.FindAll(sql, "uid desc", null, (rq.pageIndex - 1) * rq.pageSize, rq.pageSize);
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
                result.list = query.Select(a => new AllowanceDetailItemRs
                {
                    userName = a.uname,
                    telphone = a.phone,
                    salesNums = Order.FindAll("select * from [Order] where uid=" + a.uid).ToList().Sum(q => q.income),
                    productName = "",
                    productType = "",
                    buyTime = DateTime.Now
                }).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }

        /// <summary>
        /// 认证审核
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public CheckUsersRS GetCheckUsers(CheckUsersRQ rq)
        {
            var result = new CheckUsersRS { total = 0, list = null };
            try
            {
                var sql = " auditStatus in(0,1) and uid in(select requestUid from AuditRecord) ";
                if (!string.IsNullOrWhiteSpace(rq.paraName))
                {
                    sql += string.Format(" and (uname like '%{0}%' or nickName like '%{0}%' or phone like '%{0}%') ", rq.paraName);
                }
                var user = Users.FindAll(sql, "uid desc", null, (rq.pageIndex - 1) * rq.pageSize, rq.pageSize);
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
                result.list = query.Select(a => new CheckUsersItemRS
                {
                    userName = a.nickName,
                    telphone = a.phone,
                    applyTime=a.regTime,
                    status=a.auditStatus,
                    reason=string.Empty,
                    checkTime=a.updateTime,
                    uid=a.uid
                }).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }

        /// <summary>
        /// 审核理财师
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<string> CheckUser(CheckUserRQ rq)
        {
            try
            {
                var user = Users.FindByuid(rq.id);
                user.auditStatus = rq.status;
                user.roleId = rq.status == 2 ? 1 : user.roleId;
                user.updateTime = DateTime.Now;
                user.Save();

                var record = AuditRecord.Find(" auditTime is null and requestUid=" + rq.id);
                if (null == record)
                {
                    record = new AuditRecord();
                }
                record.auditUid = rq.auditUid;
                record.auditTime = DateTime.Now;
                record.applyContent = rq.reason;
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
        /// 获取公司下拉列表
        /// </summary>
        /// <returns></returns>
        public List<CompanyRs> GetCompanys()
        {
            var data = Company.FindAll();
            return data.ToList().Select(item => new CompanyRs()
            {
                Id=item.Id,
                CityId=item.CityId,
                //CityName=item.CityId,
                CompanyName=item.CompanyName,
                DepartmentName=item.DepartmentName,
                Postion=item.Postion
            }).ToList();
        }
    }
}
