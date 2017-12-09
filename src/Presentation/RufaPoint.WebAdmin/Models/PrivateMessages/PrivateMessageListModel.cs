using System.Collections.Generic;
using RufaPoint.Web.Framework.Mvc.Models;
using RufaPoint.Web.Models.Common;

namespace RufaPoint.Web.Models.PrivateMessages
{
    public partial class PrivateMessageListModel : BaseNopModel
    {
        public IList<PrivateMessageModel> Messages { get; set; }
        public PagerModel PagerModel { get; set; }
    }
}