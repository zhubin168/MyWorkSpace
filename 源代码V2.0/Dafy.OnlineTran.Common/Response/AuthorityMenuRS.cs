using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Response
{
    public class AuthorityMenuRS
    {
        /// <summary>
        /// 主菜单列表
        /// </summary>
        public List<MenuAdminList> menuAdminList { get; set; }
    }

    public class MenuAdminList
    {
        public string id { get; set; }
        /// <summary>
        /// 页面路径
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 父菜单id
        /// </summary>
        public string parentID { get; set; }
        /// <summary>
        /// 子菜单列表
        /// </summary>
        public List<MenuItemList> menuItemList { get; set; }
    }

    /// <summary>
    /// 子菜单列表
    /// </summary>
    public class MenuItemList
    {
        public string id { get; set; }
        /// <summary>
        /// 页面路径
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 父菜单id
        /// </summary>
        public string parentID { get; set; }
    }
}
