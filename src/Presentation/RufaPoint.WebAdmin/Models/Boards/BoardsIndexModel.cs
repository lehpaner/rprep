using System.Collections.Generic;
using RufaPoint.Web.Framework.Mvc.Models;

namespace RufaPoint.Web.Models.Boards
{
    public partial class BoardsIndexModel : BaseNopModel
    {
        public BoardsIndexModel()
        {
            this.ForumGroups = new List<ForumGroupModel>();
        }
        
        public IList<ForumGroupModel> ForumGroups { get; set; }
    }
}