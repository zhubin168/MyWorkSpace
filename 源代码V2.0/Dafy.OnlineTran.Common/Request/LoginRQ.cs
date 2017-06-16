using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Request
{
    public class LoginRQ
    {
        /// <summary>
        /// 账号id
        /// </summary>
        public int userId { get; set; }
        /// <summary>
        /// 账号密码
        /// </summary>
        public string password { get; set; }
    }

    /// <summary>
    /// 找回密码
    /// </summary>
    public class FindPasswordRQ
    {
        /// <summary>
        /// 新密码
        /// </summary>
        public string newPassword { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        public string saleId { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string phone { get; set; }
    }
}
