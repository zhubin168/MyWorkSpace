using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Response
{
    /// <summary>
    /// 公共返回类型基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultModel<T> where T : class
    {
        public string message { get; set; }
        public int state { get; set; }
        public T data { get; set; }
    }
}
