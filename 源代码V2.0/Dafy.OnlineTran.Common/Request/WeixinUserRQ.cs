using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Request
{
    public class WeixinUserRQ
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        /// <summary>
        /// 搜索词：电话或者姓名
        /// </summary>
        public string paraName { get; set; }
        public int roleId { get; set; }
        public string regStartDate { get; set; }
        public string regEndDate { get; set; }
    }
    public class DetailUserRQ
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        /// <summary>
        /// 搜索词：电话或者姓名
        /// </summary>
        public string paraName { get; set; }
        public int id { get; set; }
        public int roleId { get; set; }
        /// <summary>
        /// 是否有任务津贴
        /// </summary>
        public int isHasAllowance { get; set; }
        /// <summary></summary>
        public string ident { get; set; }

        /// <summary></summary>
        public string cardNo { get; set; }

        /// <summary></summary>
        public string bankName { get; set; }

        public string userName { get; set; }
        public int companyId { get; set; }
        public string bankPerson { get; set; }

    }
    public class UpdateWeixinUserRQ
    {
        public int Id { get; set; }

        /// <summary></summary>
        public string Open_Id { get; set; }

        /// <summary></summary>
        public string Nickname { get; set; }

        /// <summary></summary>
        public int Sex { get; set; }

        /// <summary></summary>
        public string City { get; set; }

        /// <summary></summary>
        public string Country { get; set; }

        /// <summary></summary>
        public string Province { get; set; }

        /// <summary></summary>
        public string Headimgurl { get; set; }

        /// <summary></summary>
        public string Unionid { get; set; }

        /// <summary></summary>
        public string Username { get; set; }

        /// <summary>密码（初始密码为随机生成的6位数字），后台也可修改</summary>
        public string Password { get; set; }

        /// <summary>(0:客户；1：理财师)</summary>
        public int RoleId { get; set; }

        /// <summary>电话</summary>
        public string TelePhone { get; set; }

        /// <summary></summary>
        public string Remark { get; set; }

        /// <summary></summary>
        public int IsPrice { get; set; }

        /// <summary></summary>
        public string Ident { get; set; }

        /// <summary></summary>
        public string CardNo { get; set; }

        /// <summary></summary>
        public string BankName { get; set; }

        /// <summary></summary>
        public string Company { get; set; }

        /// <summary></summary>
        public string CompCity { get; set; }

        /// <summary></summary>
        public string Department { get; set; }

        /// <summary></summary>
        public string Position { get; set; }
    }

    public class WeixinUserMineRQ
    {
        public int uid { get; set; }
        public string HeaderUrl { get; set; }
    }

    public class SetBankRQ
    {
        public int uid { get; set; }
        /// <summary></summary>

        /// <summary></summary>
        public string cardNo { get; set; }

        /// <summary></summary>
        public string bankName { get; set; }
        public string ident { get; set; }
        public string phone { get; set; }
        public string bankPerson { get; set; }

    }
}
