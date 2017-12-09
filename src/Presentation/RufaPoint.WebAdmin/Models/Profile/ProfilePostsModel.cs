using System.Collections.Generic;
using RufaPoint.Web.Framework.Mvc.Models;
using RufaPoint.Web.Models.Common;

namespace RufaPoint.Web.Models.Profile
{
    public partial class ProfilePostsModel : BaseNopModel
    {
        public IList<PostsModel> Posts { get; set; }
        public PagerModel PagerModel { get; set; }
    }
}