using Dafy.OnlineTran.Common.Request;
using Dafy.OnlineTran.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.IService.Pc
{
    /// <summary>
    /// 数据配置接口定义
    /// 创建人：朱斌
    /// 创建时间：2017-04-30
    /// </summary>
    public interface IConfigService
    {
        /// <summary>
        /// 参数字典列表
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ParameterRS GetConfigs(ParameterRQ rq);

        /// <summary>
        /// 保存字典信息
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<string> SaveConfig(SaveParameterRQ rq);

        /// <summary>
        /// 删除字典信息
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        ResultModel<string> DeleteConfig(DelParameterRQ rq);
    }
}
