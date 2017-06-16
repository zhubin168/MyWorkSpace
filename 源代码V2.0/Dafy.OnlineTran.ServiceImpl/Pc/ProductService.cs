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


namespace Dafy.OnlineTran.ServiceImpl.Pc
{
    /// <summary>
    /// 产品管理实现类 
    /// 创建人：朱斌
    /// 创建时间：2017-05-01
    /// </summary>
    public class ProductService : IProductService
    {
        /// <summary>
        /// 产品管理列表
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ProductsRS GetProducts(ProductsRQ rq)
        {

            var result = new ProductsRS { total = 0, list = null };
            var sql = " 1=1 ";
            if (!string.IsNullOrWhiteSpace(rq.paraName))
            {
                sql += string.Format(" and (productName like '%{0}%' or companyName like '%{0}%') ", rq.paraName);
            }
            if (!string.IsNullOrWhiteSpace(rq.productType))
            {
                sql += string.Format(" and productType='{0}' ", rq.productType);
            }
            if (!string.IsNullOrWhiteSpace(rq.status))
            {
                sql += string.Format(" and status='{0}' ", rq.status);
            }
            if (rq.pid>0)
            {
                sql += string.Format(" and pid='{0}' ", rq.pid);
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
            result.total = Product.FindAll(sql, null, null, 0, 0).Count;
            if (result.total == 0) return result;
            result.list = query.Select(a => new ProductsItemRS
            {
                companyId=a.companyId,
                companyLogo=a.companyLogo,
                companyName=a.companyName,
                content=a.content,
                demoContent=a.demoContent,
                description=a.description,
                detailTopUrl = a.detailTopUrl,
                docUrl=a.docUrl,
                guideContent=a.guideContent,
                hotPosition=a.hotPosition,
                pid=a.pid,
                position=a.position,
                price=a.price,
                proAge=a.proAge,
                problemContent=a.problemContent,
                productName=a.productName,
                productType = a.productType.Replace("1", "保险类").Replace("2", "投融类").Replace("3", "其他类"),
                reasonContent=a.reasonContent,
                status = a.status.ToString().Replace("1", "上架").Replace("2", "下架").Replace("3", "草稿"),
                publishTime=a.publishTime
            }).ToList();
            return result;
        }

        /// <summary>
        /// 保存产品信息
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<string> SaveProducts(SaveProductRQ rq)
        {
            EntityList<Product> users = new EntityList<Product>();
            var user = Product.FindBypid(rq.pid);
            if (null == user)
            {
                user = new Product();
                user.createUid =Convert.ToInt32(rq.CreatedByName);
                user.createTime = DateTime.Now;
                user.publishTime = DateTime.Now;
            }
            user.companyId = rq.companyId;
            user.companyLogo = rq.companyLogo;
            user.companyName = rq.companyName;
            user.content = rq.content;
            user.demoContent = rq.demoContent;
            user.description = rq.description;
            user.detailTopUrl = rq.detailTopUrl;
            user.docUrl = rq.docUrl.TrimEnd(';');
            user.guideContent = rq.guideContent;
            user.hotPosition = rq.hotPosition;
            user.position = rq.position;
            user.price = rq.price;
            user.proAge = rq.proAge;
            user.problemContent = rq.problemContent;
            user.productName = rq.productName;
            user.productType = rq.productType;
            user.reasonContent = rq.reasonContent;
            user.status = rq.status;
            users.Add(user);
            int nCount = users.Save();
            return new ResultModel<string>
            {
                state = nCount,
                message = nCount > 0 ? "保存成功！" : "操作失败！",
                data = nCount.ToString()
            };
        }

        /// <summary>
        /// 产品详情
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ProductsItemRS GetDetailProduct(SaveProductRQ rq)
        {
            var condition = new ProductsRQ()
            {
                pageIndex = 1,
                pageSize = Int32.MaxValue,
                pid=rq.pid
            };
            var list = GetProducts(condition).list;
            var result = list == null ? new ProductsItemRS() : list.Where(q => q.pid == rq.pid).FirstOrDefault();
            return result;
        }
    }
}
