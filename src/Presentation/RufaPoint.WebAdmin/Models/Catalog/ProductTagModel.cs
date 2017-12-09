using RufaPoint.Web.Framework.Mvc.Models;

namespace RufaPoint.Web.Models.Catalog
{
    public partial class ProductTagModel : BaseNopEntityModel
    {
        public string Name { get; set; }

        public string SeName { get; set; }

        public int ProductCount { get; set; }
    }
}