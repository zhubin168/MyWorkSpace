using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Response
{
    public class RoleListRs
    {
        public List<RoleListItemRs> list { get; set; }
    }
    public class RoleListItemRs
    {
        /// <summary></summary>
        public long roleId { get; set; }

        /// <summary>角色名称</summary>
        public string roleName { get; set; }
    }
}
