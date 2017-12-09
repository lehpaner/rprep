﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using RufaPoint.Plugin.Payments.Square.Validators;
using RufaPoint.Web.Framework.Mvc.ModelBinding;
using RufaPoint.Web.Framework.Mvc.Models;

namespace RufaPoint.Plugin.Payments.Square.Models
{
    [Validator(typeof(ConfigurationModelValidator))]
    public class ConfigurationModel : BaseNopModel
    {
        #region Ctor

        public ConfigurationModel()
        {
            Locations = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Plugins.Payments.Square.Fields.ApplicationId")]
        public string ApplicationId { get; set; }

        [NopResourceDisplayName("Plugins.Payments.Square.Fields.SandboxApplicationId")]
        public string SandboxApplicationId { get; set; }

        [NopResourceDisplayName("Plugins.Payments.Square.Fields.ApplicationSecret")]
        [DataType(DataType.Password)]
        [NoTrim]
        public string ApplicationSecret { get; set; }

        [NopResourceDisplayName("Plugins.Payments.Square.Fields.AccessToken")]
        [DataType(DataType.Password)]
        [NoTrim]
        public string AccessToken { get; set; }

        [NopResourceDisplayName("Plugins.Payments.Square.Fields.SandboxAccessToken")]
        public string SandboxAccessToken { get; set; }

        [NopResourceDisplayName("Plugins.Payments.Square.Fields.UseSandbox")]
        public bool UseSandbox { get; set; }

        [NopResourceDisplayName("Plugins.Payments.Square.Fields.TransactionMode")]
        public int TransactionModeId { get; set; }
        public SelectList TransactionModes { get; set; }

        [NopResourceDisplayName("Plugins.Payments.Square.Fields.Location")]
        public string LocationId { get; set; }
        public IList<SelectListItem> Locations { get; set; }

        [NopResourceDisplayName("Plugins.Payments.Square.Fields.AdditionalFee")]
        public decimal AdditionalFee { get; set; }

        [NopResourceDisplayName("Plugins.Payments.Square.Fields.AdditionalFeePercentage")]
        public bool AdditionalFeePercentage { get; set; }

        #endregion
    }
}