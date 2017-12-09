using System.Collections.Generic;
using RufaPoint.Web.Framework.Mvc.Models;

namespace RufaPoint.Web.Models.Boards
{
    public partial  class ForumGroupModel : BaseNopModel
    {
        public ForumGroupModel()
        {
            this.Forums = new List<ForumRowModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string SeName { get; set; }

        public IList<ForumRowModel> Forums { get; set; }
    }
}