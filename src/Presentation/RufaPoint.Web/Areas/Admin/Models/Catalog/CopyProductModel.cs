﻿using RufaPoint.Web.Framework.Mvc.ModelBinding;
using RufaPoint.Web.Framework.Mvc.Models;

namespace RufaPoint.Web.Areas.Admin.Models.Catalog
{
    public partial class CopyProductModel : BaseNopEntityModel
    {

        [NopResourceDisplayName("Admin.Catalog.Products.Copy.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Products.Copy.CopyImages")]
        public bool CopyImages { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Products.Copy.Published")]
        public bool Published { get; set; }
    }
}