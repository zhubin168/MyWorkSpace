using Dafy.OnlineTran.Common.Request;
using Dafy.OnlineTran.Common.Request.App;
using Dafy.OnlineTran.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.IService.App
{
    public interface IHomeService
    {
        WeixinUserItemRS InsertUser(WeixinUserItemRS rq);
        ResultModel<GetBannersRS> GetBanners(GetBannersRQ rq);

        ResultModel<List<ProductsItemRS>> GetHotProduct();

        ResultModel<ProductsRS> GetProducts(AppProductsRQ rq);
        /// <summary>
        /// 行业资讯
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<InformationRS> GetInformations(AppInformationRQ rq);
        /// <summary>
        /// 理财知识
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<KnowledgeRS> GetKnowledges(AppKnowledgeRQ rq);
    }
}
