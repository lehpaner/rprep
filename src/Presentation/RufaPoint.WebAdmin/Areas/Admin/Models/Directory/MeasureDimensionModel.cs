﻿using FluentValidation.Attributes;
using RufaPoint.Web.Areas.Admin.Validators.Directory;
using RufaPoint.Web.Framework.Mvc.ModelBinding;
using RufaPoint.Web.Framework.Mvc.Models;

namespace RufaPoint.Web.Areas.Admin.Models.Directory
{
    [Validator(typeof(MeasureDimensionValidator))]
    public partial class MeasureDimensionModel : BaseNopEntityModel
    {
        [NopResourceDisplayName("Admin.Configuration.Shipping.Measures.Dimensions.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Shipping.Measures.Dimensions.Fields.SystemKeyword")]
        public string SystemKeyword { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Shipping.Measures.Dimensions.Fields.Ratio")]
        public decimal Ratio { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Shipping.Measures.Dimensions.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Shipping.Measures.Dimensions.Fields.IsPrimaryDimension")]
        public bool IsPrimaryDimension { get; set; }
    }
}