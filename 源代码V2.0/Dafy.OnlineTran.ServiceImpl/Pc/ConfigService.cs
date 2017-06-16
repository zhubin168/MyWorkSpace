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
    /// <summary>
    /// 数据配置实现类
    /// 创建人：朱斌
    /// 创建时间：2017-04-30
    /// </summary>
    public class ConfigService : IConfigService
    {
        /// <summary>
        /// 参数字典列表
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ParameterRS GetConfigs(ParameterRQ rq)
        {
            var result = new ParameterRS { total = 0, list = null };
            var query = (from a in Dictionary.FindAll().ToList()
                             select new
                             {
                                 a.id,
                                 a.para_name,
                                 a.para_code,
                                 a.para_group,
                                 a.para_value,
                                 a.status,
                                 a.remark,
                                 a.sort_order
                             }).AsQueryable();
                #region 过滤
                if (!string.IsNullOrWhiteSpace(rq.paraName))
                {
                    query = query.Where(q => q.para_name.Contains(rq.paraName) || q.para_group.Contains(rq.paraName));
                }
                #endregion
                query = query.OrderByDescending(q => q.id).ThenByDescending(q => q.para_code);
                result.total = query.Count();
                if (result.total == 0) return result;
                result.list = query.Select(a => new ParameterItemRS
                {
                    id = a.id,
                    sortOrder = a.sort_order,
                    paraName = a.para_name,
                    paraCode = a.para_code,
                    paraGroup = a.para_group,
                    paraValue = a.para_value,
                    status = a.status,
                    remark = a.remark
                }).Skip((rq.pageIndex - 1) * rq.pageSize).Take(rq.pageSize).ToList();
                return result;
        }

        /// <summary>
        /// 保存字典信息
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<string> SaveConfig(SaveParameterRQ rq)
        {
            return new ResultModel<string>
            {
                state = 0,
                message = "保存失败！",
                data = "0"
            };
        }

        /// <summary>
        /// 删除字典信息
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public ResultModel<string> DeleteConfig(DelParameterRQ rq)
        {
            return new ResultModel<string>
            {
                state = 0,
                message = "删除失败！",
                data = "0"
            };
        }
    }
}
