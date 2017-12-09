using System.Collections.Generic;
using RufaPoint.Web.Framework.Mvc.Models;
using RufaPoint.Web.Models.Catalog;
using RufaPoint.Web.Models.Topics;

namespace RufaPoint.Web.Models.Common
{
    public partial class SitemapModel : BaseNopModel
    {
        public SitemapModel()
        {
            Products = new List<ProductOverviewModel>();
            Categories = new List<CategorySimpleModel>();
            Manufacturers = new List<ManufacturerBriefInfoModel>();
            Topics = new List<TopicModel>();
            ProductTags = new List<ProductTagModel>();
        }
        public IList<ProductOverviewModel> Products { get; set; }
        public IList<CategorySimpleModel> Categories { get; set; }
        public IList<ManufacturerBriefInfoModel> Manufacturers { get; set; }
        public IList<TopicModel> Topics { get; set; }
        public IList<ProductTagModel> ProductTags { get; set; }

        public bool NewsEnabled { get; set; }
        public bool BlogEnabled { get; set; }
        public bool ForumEnabled { get; set; }
    }
}