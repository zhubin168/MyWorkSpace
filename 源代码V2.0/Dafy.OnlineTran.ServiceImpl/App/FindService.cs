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
using XCode;

namespace Dafy.OnlineTran.ServiceImpl.App
{
    public class FindService : IFindService
    {
        /// <summary>
        /// 获取个人信息
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<GetUserInfoRS> GetUserInfo(GetUserInfoRQ rq)
        {
            var result = new ResultModel<GetUserInfoRS>
            {
                state = 0,
                data = null,
                message = "获取个人信息成功!"
            };
            var user = Users.FindByuid(rq.uId);
            var userInfoRS = new GetUserInfoRS();

            if (user == null)
            {
                result.message = "用户不存在!";
                return result;
            }
            userInfoRS.userName = user.nickName;
            userInfoRS.phone = user.phone;
            userInfoRS.rank = user.rank;
            userInfoRS.remark = user.remark;

            result.state = 1;
            result.data = userInfoRS;

            return result;
        }
        /// <summary>
        /// 保存个人信息
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<string> SaveUserInfo(AppSaveUserInfoRQ rq)
        {
            var result = new ResultModel<string>
            {
                state=0,
                data=null,
                message="保存失败"
            };

            var user = Users.FindByuid(rq.uId);
            if (user == null)
            {
                result.message = "用户不存在!";
                return result;
            }
            user.nickName = rq.userName;
            user.phone = rq.phone;
            user.rank = rq.rank;
            user.remark = rq.remark;
            user.updateTime = DateTime.Now;

            int nCount = user.Save();
            if (nCount > 0)
            {
                result.state = 1;
                result.message = "保存成功!";
            }
            else
            {
                result.message = "保存失败!";
            }
            return result;

        }
        /// <summary>
        /// 获客助手：发资讯、发小知识、发鸡汤详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ArticleListItemRS GetArticleDetail(AppGetArticleDetailRQ rq)
        {
            var result = new ArticleListItemRS();
            var model = Article.Find(Article._.id, rq.id);
            if (model != null)
            {
                result.content = model.content;
                result.contentUrl = model.contentUrl;
                result.createTime = model.createTime;
                result.createUid = model.createUid;
                result.id = model.id;
                result.listUrl = model.listUrl;
                result.modifyUid = model.modifyUid;
                result.publishTime = model.publishTime;
                result.shareTitle = model.shareTitle;
                result.shareUrl = model.shareUrl;
                result.status = model.status;
                result.title = model.title;
                result.type = model.type;
                result.updateTime = model.updateTime;
                result.modifyName = model.modifyName;
            }
            return result;
        }
        /// <summary>
        /// 获客助手：发资讯、发小知识、发鸡汤
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ArticleListRS GetArticles(AppArticleListRQ rq)
        {
            var result = new ArticleListRS { total = 0, list = null };
            var sql = " 1=1 and publishTime<=getdate() ";
            sql += string.Format(" and status='{0}' ",1);

            if (rq.type!=0)
            {
                sql += string.Format(" and type='{0}' ", rq.type);
            }

            var user = Article.FindAll(sql, "Id desc", null, (rq.pageIndex - 1) * rq.pageSize, rq.pageSize);
            var query = (from a in user.ToList()
                         select new
                         {
                             a.content,
                             a.contentUrl,
                             a.createTime,
                             a.createUid,
                             a.id,
                             a.listUrl,
                             a.modifyUid,
                             a.publishTime,
                             a.shareTitle,
                             a.shareUrl,
                             a.status,
                             a.title,
                             a.type,
                             a.updateTime,
                             a.modifyName
                         });
            result.total = Article.FindAll(sql, null, null, 0, 0).Count;
            if (result.total == 0) return result;
            result.list = query.Select(a => new ArticleListItemRS
            {
                content = a.content,
                contentUrl = a.contentUrl,
                createTime = a.createTime,
                createUid = a.createUid,
                id = a.id,
                listUrl = a.listUrl,
                modifyUid = a.modifyUid,
                publishTime = a.publishTime,
                shareTitle = a.shareTitle,
                shareUrl = a.shareUrl,
                status = a.status,
                title = a.title,
                type = a.type,
                updateTime = a.updateTime,
                modifyName = a.modifyName
            }).ToList();
            return result;
        }
        /// <summary>
        /// 获客助手：图片详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public CustomerToolsItemRS GetDetailTool(AppToolsDetailRQ rq)
        {
            var result = new CustomerToolsItemRS();
            var model = Picture.Find(Picture._.id, rq.id);
            if (model != null)
            {
                result.createTime = model.createTime;
                result.createUid = model.createUid;
                result.id = model.id;
                result.imageUrl = model.imageUrl;
                result.publishTime = model.publishTime.ToString("yyyy/MM/dd HH:mm:ss");
                result.sequence = model.sequence;
                result.status = model.status;
                result.title = model.title;
                result.type = model.type;
                result.updateTime = model.updateTime;
            }
            return result;
        }
        /// <summary>
        /// 获客助手：图片管理
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public CustomerToolsRS GetTools(AppCustomerToolsRQ rq)
        {
            var result = new CustomerToolsRS { total = 0, list = null };
            var sql = " 1=1 and publishTime<=getdate() ";
                sql += string.Format(" and status='{0}' ",1);
            if (rq.type!=0)
            {
                sql += string.Format(" and type='{0}' ", rq.type);
            }
            var user = Picture.FindAll(sql, "id desc", null, (rq.pageIndex - 1) * rq.pageSize, rq.pageSize);
            var query = (from a in user.ToList()
                         select new
                         {
                             a.createTime,
                             a.createUid,
                             a.id,
                             a.imageUrl,
                             a.modifyUid,
                             a.publishTime,
                             a.sequence,
                             a.status,
                             a.title,
                             a.type,
                             a.updateTime,
                         });
            result.total = Picture.FindAll(sql, null, null, 0, 0).Count;
            if (result.total == 0) return result;
            result.list = query.Select(a => new CustomerToolsItemRS
            {
                createTime = a.createTime,
                createUid = a.createUid,
                id = a.id,
                imageUrl = a.imageUrl,
                publishTime = a.publishTime.ToString("yyyy/MM/dd HH:mm:ss"),
                sequence = a.sequence,
                status = a.status,
                title = a.title,
                type = a.type,
                updateTime = a.updateTime,
            }).ToList();
            return result;
        }
        /// <summary>
        /// 获取历史订单记录
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<AppGetOrderRS> GetOrder(AppGetOrderRQ rq)
        {
            var result = new ResultModel<AppGetOrderRS>
            {
                state = 1,
                data = null,
                message = "获取订单信息成功"
            };

            var sql = " 1=1 ";
            sql += string.Format(" and clientUid='{0}' ", rq.uId);

            var user = Order.FindAll(sql, "oid desc", null, 0, 1).ToList().FirstOrDefault();
            var appGetOrderRS = new AppGetOrderRS();

            if (user != null)
            {
                appGetOrderRS.userName = user.clientName;
                appGetOrderRS.phone = user.clientPhone;
                appGetOrderRS.sex = user.sex;
            }
            else
            {
                result.state = 0;
                result.message = "暂无预约记录";
            }
            result.data = appGetOrderRS;

            return result;
        }
        /// <summary>
        /// 预约产品
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<string> AddOrder(AppAddOrderRQ rq)
        {
            var result = new ResultModel<string>
            {
                state = 0,
                data = "",
                message = ""
            };

            var user = Users.Find(Users._.uid, rq.uId);
            if (user == null)
            {
                result.message = "用户不存在";
                return result;
            }

            var sql = " 1=1 ";
            sql += string.Format(" and clientUid={0} ",rq.uId);
            sql += string.Format(" and productId='{0}' ",rq.productId);

            var oOrder = Order.FindAll(sql, "oid desc", null, 0,1).ToList().FirstOrDefault();
            if (oOrder != null)
            {
                result.message = "你已经预约了该产品,不需重复预约!";
                return result;
            }

            var product = Product.Find(Product._.pid, rq.productId);
            if (product == null)
            {
                result.message = "产品不存在!";
                return result;
            }

            EntityList<Order> orders = new EntityList<Order>();
            Order order = new Order();
            order.uid = user.uid;
            order.uname = user.nickName;
            order.productId = product.pid;
            order.productName = product.productName;
            order.productType = product.productType;
            order.prodcutPrice = product.price;
            order.total = 1;
            order.status = 0;

            var userRelation = UserRelation.Find(UserRelation._.uid, user.uid);
            if (userRelation != null)
            {
                order.uid = userRelation.pUid;
            }
            else
            {
                order.uid = 0;
            }
            order.clientUid = user.uid;
            order.clientName = rq.userName;
            order.clientPhone = rq.phone;
            order.sex = rq.sex;

            orders.Add(order);
            int nCount = orders.Save();
            result.message = nCount > 0 ? "预约成功！" : "预约失败！";

            return result;
        }
        /// <summary>
        /// 理财知识详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public KnowledgeItemRS GetDetailKnowledge(AppKnowledgeDetailRQ rq)
        {
            var model = Knowledge.Find(Knowledge._.id, rq.id);
            var result = new KnowledgeItemRS();

            if (model != null)
            {
                result.id = model.id;
                result.createTime = model.createTime;
                result.createUid = model.createUid;
                result.modifyUid = model.modifyUid;
                result.updateTime = model.updateTime;
                result.content = model.content;
                result.contentUrl = model.contentUrl;
                result.listUrl = model.listUrl;
                result.publishTime = model.publishTime;
                result.shareTitle = model.shareTitle;
                result.shareUrl = model.shareUrl;
                result.status = model.status;
                result.title = model.title;
                result.modifyName = model.modifyName;
            }
            return result;
        }
        /// <summary>
        /// 行业资讯详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public InformationItemRS GetDetailInformation(AppInformationDetailRQ rq)
        {
            var model = Information.Find(Information._.id, rq.id);
            var result = new InformationItemRS();

            if (model != null)
            {
                result.id = model.id;
                result.createTime = model.createTime;
                result.createUid = model.createUid;
                result.modifyUid = model.modifyUid;
                result.updateTime = model.updateTime;
                result.cid = model.cid;
                result.typeName = InfoCategory.FindByid(model.cid) == null ? string.Empty : InfoCategory.FindByid(model.cid).name;
                result.content = model.content;
                result.contentUrl = model.contentUrl;
                result.listUrl = model.listUrl;
                result.publishTime = model.publishTime;
                result.shareTitle = model.shareTitle;
                result.shareUrl = model.shareUrl;
                result.status = model.status;
                result.title = model.title;
                result.modifyName = model.modifyName;
            }
            return result;
        }
        /// <summary>
        /// 热点理财师充电站
        /// </summary>
        /// <returns></returns>
        public ResultModel<List<CourseItemRS>> GetHotCourse()
        {
            var result = new ResultModel<List<CourseItemRS>>
            {
                state = 1,
                data = null,
                message = ""
            };
            var sql = " 1=1 and publishTime<=getdate() ";
            sql += string.Format(" and position in ({0}) ", "1,2,3");
            sql += string.Format(" and status='{0}' ", 1);

            var user = Course.FindAll(sql, "publishTime desc", null, 0, 3);
            var query = (from a in user.ToList()
                         select new
                         {
                             a.id,
                             a.createTime,
                             a.createUid,
                             a.modifyUid,
                             a.updateTime,
                             a.content,
                             a.contentUrl,
                             a.listUrl,
                             a.publishTime,
                             a.shareTitle,
                             a.shareUrl,
                             a.status,
                             a.title,
                             a.position,
                             a.subTitle,
                             a.modifyName
                         });

            result.data = query.Select(a => new CourseItemRS
            {
                id = a.id,
                createTime = a.createTime,
                createUid = a.createUid,
                modifyUid = a.modifyUid,
                updateTime = a.updateTime,
                content = a.content,
                contentUrl = a.contentUrl,
                listUrl = a.listUrl,
                publishTime = a.publishTime,
                shareTitle = a.shareTitle,
                shareUrl = a.shareUrl,
                status = a.status,
                title = a.title,
                position = a.position,
                subTitle = a.subTitle,
                modifyName = a.modifyName
            }).OrderBy(p => p.position).ToList();

            return result;
        }
        /// <summary>
        /// 理财师充电站
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<CourseRS> GetCourses(AppCourseRQ rq)
        {
            var result = new ResultModel<CourseRS>
            {
                state = 1,
                data = null,
                message = ""
            };
            var courseRS = new CourseRS { total = 0, list = null };
            var sql = " 1=1 and publishTime<=getdate() ";
            sql += string.Format(" and status='{0}' ", 1);

            var user = Course.FindAll(sql, "publishTime desc", null, (rq.pageIndex - 1) * rq.pageSize, rq.pageSize);
            var query = (from a in user.ToList()
                         select new
                         {
                             a.id,
                             a.createTime,
                             a.createUid,
                             a.modifyUid,
                             a.updateTime,
                             a.content,
                             a.contentUrl,
                             a.listUrl,
                             a.publishTime,
                             a.shareTitle,
                             a.shareUrl,
                             a.status,
                             a.title,
                             a.position,
                             a.subTitle,
                             a.modifyName
                         });
            courseRS.total = Course.FindAll(sql, null, null, 0, 0).Count;
            if (courseRS.total == 0) return result;
            courseRS.list = query.Select(a => new CourseItemRS
            {
                id = a.id,
                createTime = a.createTime,
                createUid = a.createUid,
                modifyUid = a.modifyUid,
                updateTime = a.updateTime,
                content = a.content,
                contentUrl = a.contentUrl,
                listUrl = a.listUrl,
                publishTime = a.publishTime,
                shareTitle = a.shareTitle,
                shareUrl = a.shareUrl,
                status = a.status,
                title = a.title,
                position = a.position,
                subTitle = a.subTitle,
                modifyName = a.modifyName
            }).ToList();
            result.data = courseRS;

            return result;
        }

        /// <summary>
        /// 产品详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public AppGetDetailProductRS GetDetailProduct(AppGetDetailProductRQ rq)
        {
            var product = Product.Find(Product._.pid, rq.productId);
            var result = new AppGetDetailProductRS();

            if (product != null)
            {
                result.companyId = product.companyId;
                result.companyLogo = product.companyLogo;
                result.companyName = product.companyName;
                result.content = product.content;
                result.demoContent = product.demoContent;
                result.description = product.description;
                result.detailTopUrl = product.detailTopUrl;

                if (!string.IsNullOrEmpty(product.docUrl))
                {
                    var ary = product.docUrl.Split(';');

                    if (ary.Length > 0)
                    {
                        List<docModel> listDoc = new List<docModel>();
                        foreach (var url in ary)
                        {
                            listDoc.Add(new docModel { url = url });
                        }
                        result.docUrlList = listDoc;
                    }
                }
                result.guideContent = product.guideContent;
                result.hotPosition = product.hotPosition;
                result.pid = product.pid;
                result.position = product.position;
                result.price = product.price;
                result.proAge = product.proAge;
                result.problemContent = product.problemContent;
                result.productName = product.productName;
                result.productType = product.productType;//.Replace("1", "保险类").Replace("2", "投融类").Replace("3", "其他类");
                result.reasonContent = product.reasonContent;
                result.publishTime = product.publishTime;
            }
            return result;
        }
    }
}
