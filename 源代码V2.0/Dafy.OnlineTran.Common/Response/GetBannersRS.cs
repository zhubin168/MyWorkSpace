using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dafy.OnlineTran.Common.Response
{
    public class GetBannersRS
    {
       public List<GetBannersRSModel> list { set; get; }
    }
    public class GetBannersRSModel
    {
        public string title { set; get; }
        public string imgUrl { set; get; }

        public string shareTitle { set; get;}

        public string shareImageUrl { set; get; }

        public string shareContent { set; get; }
        public string shareUrl { set; get; }
        public string contentUrl { get; set; }
    }
}
