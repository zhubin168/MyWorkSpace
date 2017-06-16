using Dafy.OnlineTran.Common.Request;
using Dafy.OnlineTran.Common.Request.App;
using Dafy.OnlineTran.Common.Response;
using Dafy.OnlineTran.Entity.Models;
using Dafy.OnlineTran.IService.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.ServiceImpl.App
{
    public class HomeService : IHomeService
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public WeixinUserItemRS InsertUser(WeixinUserItemRS rq)
        {
            var user =Users.Find(Users._.weixinId, rq.OpenId);
            if (user == null)
            {
                user = new Users();
                user.roleId = 0;
                user.weixinId = rq.OpenId;
                user.headerUrl = rq.Headimgurl;
                user.nickName = rq.Nickname;
                user.regTime = DateTime.Now;
                user.status = 1;
                user.rank = "客户";
            }
            user.loginTime = DateTime.Now;
            int nCount = user.Save();

            if (rq.pId > 0)
            {
               // var sql = " 1=1 and unbindTime is not null and unbindTime>getdate() ";
                var  sql = string.Format(" uid='{0}' ", user.uid);
         
                var userRelationList = UserRelation.Find(sql);
                if (userRelationList == null)
                {
                    var userRelation = new UserRelation();
                    userRelation.pUid = rq.pId;
                    userRelation.uid = user.uid;
                    userRelation.bindSource = "w";
                    userRelation.bingTime = DateTime.Now;
                    userRelation.createTime = DateTime.Now;

                    int rCount = userRelation.Save();
                }
            }

            var wxUser = new WeixinUserItemRS();
            wxUser.Nickname = user.nickName;
            wxUser.OpenId = user.weixinId;
            wxUser.RoleId = user.roleId;
            //wxUser.Headimgurl = user.headerUrl;
            wxUser.Id = user.uid;
            return wxUser;
        }
        /// <summary>
        /// 理财知识
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<KnowledgeRS> GetKnowledges(AppKnowledgeRQ rq)
        {
            var result = new ResultModel<KnowledgeRS>()
            {
                state = 1,
                data = null,
                message = ""
            };
            var knowledgeRS = new KnowledgeRS { total = 0, list = null };
            var sql = " 1=1 and publishTime<=getdate() ";
                sql += string.Format(" and status='{0}' ",1);

            var user = Knowledge.FindAll(sql, "publishTime desc", null, (rq.pageIndex - 1) * rq.pageSize, rq.pageSize);
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
                             a.modifyName
                         });
            knowledgeRS.total = Knowledge.FindAll(sql, null, null, 0, 0).Count;
            if (knowledgeRS.total == 0) return result;
            knowledgeRS.list = query.Select(a => new KnowledgeItemRS
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
                modifyName = a.modifyName
            }).ToList();
            result.data = knowledgeRS;

            return result;
        }
        /// <summary>
        /// 行业资讯
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<InformationRS> GetInformations(AppInformationRQ rq)
        {
            var result = new ResultModel<InformationRS>()
            {
                state = 1,
                data = null,
                message = ""
            };
            var informationRS = new InformationRS { total = 0, list = null };
            var sql = " 1=1 and publishTime<=getdate() ";
                sql += string.Format(" and status='{0}' ",1);

            var user = Information.FindAll(sql, "publishTime desc", null, (rq.pageIndex - 1) * rq.pageSize, rq.pageSize);
            var query = (from a in user.ToList()
                         select new
                         {
                             a.id,
                             a.createTime,
                             a.createUid,
                             a.modifyUid,
                             a.updateTime,
                             a.cid,
                             a.content,
                             a.contentUrl,
                             a.listUrl,
                             a.publishTime,
                             a.shareTitle,
                             a.shareUrl,
                             a.status,
                             a.title,
                             a.modifyName
                         });
            informationRS.total = Information.FindAll(sql, null, null, 0, 0).Count;
            if (informationRS.total == 0) return result;
            informationRS.list = query.Select(a => new InformationItemRS
            {
                id = a.id,
                createTime = a.createTime,
                createUid = a.createUid,
                modifyUid = a.modifyUid,
                updateTime = a.updateTime,
                cid = a.cid,
                typeName = InfoCategory.FindByid(a.cid) == null ? string.Empty : InfoCategory.FindByid(a.cid).name,
                content = a.content,
                contentUrl = a.contentUrl,
                listUrl = a.listUrl,
                publishTime = a.publishTime,
                shareTitle = a.shareTitle,
                shareUrl = a.shareUrl,
                status = a.status,
                title = a.title,
                modifyName = a.modifyName
            }).ToList();
            result.data = informationRS;

            return result;
        }
        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<ProductsRS> GetProducts(AppProductsRQ rq)
        {
            var result = new ResultModel<ProductsRS>()
            {
                state = 1,
                data = null,
                message = ""
            };
            var productsRS = new ProductsRS { total = 0, list = null };
            var sql = " 1=1 and publishTime<=getdate()";
                sql += string.Format(" and status='1' ",1);

            if (rq.productType != 0)
            {
                sql += string.Format(" and productType={0} ",rq.productType);
            }

            var user = Product.FindAll(sql, "pid desc,publishTime desc", null, (rq.pageIndex - 1) * rq.pageSize, rq.pageSize);
            var query = (from a in user.ToList()
                         select new
                         {
                             //a.Company,
                             a.companyId,
                             a.companyLogo,
                             a.companyName,
                             a.content,
                             a.createTime,
                             a.createUid,
                             a.demoContent,
                             a.description,
                             a.detailTopUrl,
                             a.docUrl,
                             a.guideContent,
                             a.hotPosition,
                             a.modifyUid,
                             a.pid,
                             a.position,
                             a.price,
                             a.proAge,
                             a.problemContent,
                             a.productName,
                             a.productType,
                             a.publishTime,
                             a.reasonContent,
                             a.status,
                             a.updateTime,
                         });
            productsRS.total = Product.FindAll(sql, null, null, 0, 0).Count;
            if (productsRS.total == 0) return result;
            productsRS.list = query.Select(a => new ProductsItemRS
            {
                companyId = a.companyId,
                companyLogo = a.companyLogo,
                companyName = a.companyName,
                content = a.content,
                demoContent = a.demoContent,
                description = a.description,
                detailTopUrl = a.detailTopUrl,
                docUrl = a.docUrl,
                guideContent = a.guideContent,
                hotPosition = a.hotPosition,
                pid = a.pid,
                position = a.position,
                price = a.price,
                proAge = a.proAge,
                problemContent = a.problemContent,
                productName = a.productName,
                productType = a.productType,//.Replace("1", "保险类").Replace("2", "投融类").Replace("3", "其他类"),
                reasonContent = a.reasonContent,
                status = a.status.ToString().Replace("1", "上架").Replace("2", "下架").Replace("3", "草稿"),
                publishTime = a.publishTime
            }).ToList();
            result.data = productsRS;

            return result;
        }
        /// <summary>
        /// 获取热点产品
        /// </summary>
        /// <returns></returns>
        public ResultModel<List<ProductsItemRS>> GetHotProduct()
        {
            var result = new ResultModel<List<ProductsItemRS>> {
                state=1,
                data=null,
                message=""
            };
            var sql = " 1=1 and publishTime<=getdate()";
                sql += string.Format(" and status='{0}' ",1);
                sql += string.Format(" and hotPosition in ({0}) ","1,2,3");
  
            var user = Product.FindAll(sql, "pid desc,publishTime desc", null,0,3);
            var query = (from a in user.ToList()
                         select new
                         {
                             //a.Company,
                             a.companyId,
                             a.companyLogo,
                             a.companyName,
                             a.content,
                             a.createTime,
                             a.createUid,
                             a.demoContent,
                             a.description,
                             a.detailTopUrl,
                             a.docUrl,
                             a.guideContent,
                             a.hotPosition,
                             a.modifyUid,
                             a.pid,
                             a.position,
                             a.price,
                             a.proAge,
                             a.problemContent,
                             a.productName,
                             a.productType,
                             a.publishTime,
                             a.reasonContent,
                             a.status,
                             a.updateTime,
                         });

            result.data = query.Select(a => new ProductsItemRS
            {
                companyId = a.companyId,
                companyLogo = a.companyLogo,
                companyName = a.companyName,
                content = a.content,
                demoContent = a.demoContent,
                description = a.description,
                detailTopUrl = a.detailTopUrl,
                docUrl = a.docUrl,
                guideContent = a.guideContent,
                hotPosition = a.hotPosition,
                pid = a.pid,
                position = a.position,
                price = a.price,
                proAge = a.proAge,
                problemContent = a.problemContent,
                productName = a.productName,
                productType = a.productType.Replace("1", "保险类").Replace("2", "投融类").Replace("3", "其他类"),
                reasonContent = a.reasonContent,
                status = a.status.ToString().Replace("1", "上架").Replace("2", "下架").Replace("3", "草稿"),
                publishTime = a.publishTime
            }).OrderBy(p=>p.hotPosition).ToList();

            return result;
        }
        /// <summary>
        /// 获取Banner列表
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<GetBannersRS> GetBanners(GetBannersRQ rq)
        {
            var result = new ResultModel<GetBannersRS>()
            {
                state = 1,
                data = null,
                message = ""
            };
            var sql = " 1=1 and status='1'";
            if (!string.IsNullOrEmpty(rq.visiableUid))
            {
                sql += string.Format(" and visiableUid like '%{0}%' ", rq.visiableUid);
            }
            var banners = Banner.FindAll(sql, "orderNum asc", null, 0, 3);
            var query = (from a in banners.ToList()
                         select new GetBannersRSModel
                         {
                             title = a.title,
                             imgUrl = a.imageUrl,
                             shareTitle = a.shareTitle,
                             shareContent = a.shareContent,
                             shareImageUrl = a.shareImageUrl,
                             contentUrl=a.contentUrl,
                             shareUrl=a.shareUrl
                         }).ToList<GetBannersRSModel>();

            var getBannersRS = new GetBannersRS();
            getBannersRS.list = query;

            result.data = getBannersRS;
            return result;
        }
    }
}
