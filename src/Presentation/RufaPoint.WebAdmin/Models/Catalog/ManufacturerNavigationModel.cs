using System.Collections.Generic;
using RufaPoint.Web.Framework.Mvc.Models;

namespace RufaPoint.Web.Models.Catalog
{
    public partial class ManufacturerNavigationModel : BaseNopModel
    {
        public ManufacturerNavigationModel()
        {
            this.Manufacturers = new List<ManufacturerBriefInfoModel>();
        }

        public IList<ManufacturerBriefInfoModel> Manufacturers { get; set; }

        public int TotalManufacturers { get; set; }
    }

    public partial class ManufacturerBriefInfoModel : BaseNopEntityModel
    {
        public string Name { get; set; }

        public string SeName { get; set; }
        
        public bool IsActive { get; set; }
    }
}