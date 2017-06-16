using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Response
{
    public class WeixinUserRS
    {
        public List<WeixinUserItemRS> list { get; set; }
        public int total { get; set; }
    }
    public class WeixinUserItemRS
    {
        public int CompanyId { get; set; }
        public int pId { set; get; }
        /// <summary></summary>
        public long Id { get; set; }

        /// <summary></summary>
        public string OpenId { get; set; }

        /// <summary></summary>
        public string Nickname { get; set; }

        /// <summary></summary>
        public string Headimgurl { get; set; }

        /// <summary></summary>
        public string Username { get; set; }
        public string PUsername { get; set; }

        /// <summary>密码（初始密码为随机生成的6位数字），后台也可修改</summary>
        public string Password { get; set; }
  
        /// <summary>(0:客户；1：理财师)</summary>
        public int RoleId { get; set; }

        /// <summary>电话</summary>
        public string TelePhone { get; set; }
        public string PTelePhone { get; set; }

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
        public DateTime RegisterTime { get; set; }
        public DateTime LogTime { get; set; }
        /// <summary>
        /// 职级
        /// </summary>
        public string Rank { get; set; }
        /// <summary>
        /// 名下客户数
        /// </summary>
        public int CustormNums { get; set; }
        /// <summary>
        /// 团队人数
        /// </summary>
        public int MemberNums { get; set; }
        public int isHasAllowance { get; set; }

        public decimal sumSales { get; set; }
        public decimal sumIncome { get; set; }
    }

    public class CustormerUserRS
    {
        public List<CustormerUserItemRS> list { get; set; }
        public int total { get; set; }
    }
    public class CustormerUserItemRS
    {
        /// <summary></summary>
        public long Id { get; set; }

        /// <summary></summary>
        public string Nickname { get; set; }

        /// <summary></summary>
        public string Username { get; set; }

        /// <summary>电话</summary>
        public string TelePhone { get; set; }

        /// <summary></summary>
        public string Ident { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public string Resource { get; set; }
        /// <summary>
        /// 绑定时间
        /// </summary>
        public DateTime? BindDate { get; set; }

        /// <summary>
        /// 总投资额（元）
        /// </summary>
        public decimal Nums1 { get; set; }
        /// <summary>
        /// 投资笔数
        /// </summary>
        public int Nums2 { get; set; }
        /// <summary>
        /// 在投总额（元）
        /// </summary>
        public decimal Nums3 { get; set; }
        /// <summary>
        /// 在投笔数
        /// </summary>
        public int Nums4 { get; set; }
        /// <summary>
        /// 贡献佣金（元）
        /// </summary>
        public decimal Nums5 { get; set; }
    }

    public class CompanyRs
    {
        public long Id { get; set; }

        public string CompanyName { get; set; }

        public string DepartmentName { get; set; }

        public string Postion { get; set; }

        public string CityId { get; set; }
        public string CityName { get; set; }
    }
    public class CompanyRQ
    {
        public int Id { get; set; }
    }
}
