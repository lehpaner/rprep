﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using RufaPoint.Web.Framework.Mvc.ModelBinding;
using RufaPoint.Web.Framework.Mvc.Models;

namespace RufaPoint.Web.Areas.Admin.Models.Orders
{
    public partial class GiftCardListModel : BaseNopModel
    {
        public GiftCardListModel()
        {
            ActivatedList = new List<SelectListItem>();
        }

        [NopResourceDisplayName("Admin.GiftCards.List.CouponCode")]
        public string CouponCode { get; set; }

        [NopResourceDisplayName("Admin.GiftCards.List.RecipientName")]
        public string RecipientName { get; set; }

        [NopResourceDisplayName("Admin.GiftCards.List.Activated")]
        public int ActivatedId { get; set; }
        [NopResourceDisplayName("Admin.GiftCards.List.Activated")]
        public IList<SelectListItem> ActivatedList { get; set; }
    }
}