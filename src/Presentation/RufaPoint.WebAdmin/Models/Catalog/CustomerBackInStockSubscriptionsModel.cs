﻿using System.Collections.Generic;
using RufaPoint.Web.Framework.Mvc.Models;
using RufaPoint.Web.Models.Common;

namespace RufaPoint.Web.Models.Catalog
{
    public partial class CustomerBackInStockSubscriptionsModel : BaseNopModel
    {
        public CustomerBackInStockSubscriptionsModel()
        {
            this.Subscriptions = new List<BackInStockSubscriptionModel>();
        }

        public IList<BackInStockSubscriptionModel> Subscriptions { get; set; }
        public PagerModel PagerModel { get; set; }

        #region Nested classes

        public partial class BackInStockSubscriptionModel : BaseNopEntityModel
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string SeName { get; set; }
        }

        #endregion
    }
}