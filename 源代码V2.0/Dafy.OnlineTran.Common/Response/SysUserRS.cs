using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Response
{
    public class SysUserRS
    {
        public string role { set; get; }
        public string token { set; get; }
        public string userName { set; get; }
        public long userId { set; get; }
    }

    public class SysUserList
    {
        /// <summary></summary>
        public Int64 Id { get; set; }

        /// <summary></summary>
        public String Open_Id { get; set; }

        /// <summary></summary>
        public String Nickname { get; set; }

        /// <summary></summary>
        public Int32 Sex { get; set; }

        /// <summary></summary>
        public String City { get; set; }

        /// <summary></summary>
        public String Country { get; set; }

        /// <summary></summary>
        public String Province { get; set; }

        /// <summary></summary>
        public String Headimgurl { get; set; }

        /// <summary></summary>
        public DateTime Subscribe_time { get; set; }

        /// <summary></summary>
        public String Unionid { get; set; }

        /// <summary>注册时间</summary>
        public DateTime Create_time { get; set; }

        /// <summary></summary>
        public String Username { get; set; }

        /// <summary>密码（初始密码为随机生成的6位数字），后台也可修改</summary>
        public String Password { get; set; }

        /// <summary>最后一次登录时间</summary>
        public DateTime LoginTime { get; set; }

        /// <summary>(0:客户；1：理财师)</summary>
        public long RoleId { get; set; }

        /// <summary>电话</summary>
        public String TelePhone { get; set; }

        /// <summary></summary>
        public String Remark { get; set; }
    }
}
