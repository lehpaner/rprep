using System;
using Microsoft.AspNetCore.Mvc;
using RufaPoint.Core;
using RufaPoint.Core.Domain;
using RufaPoint.Core.Domain.Customers;
using RufaPoint.Services.Common;
using RufaPoint.Web.Framework.Components;

namespace RufaPoint.Web.Components
{
    public class EuCookieLawViewComponent : NopViewComponent
    {
        private readonly StoreInformationSettings _storeInformationSettings;
        private readonly IWorkContext _workContext;
        private readonly IStoreContext _storeContext;

        public EuCookieLawViewComponent(StoreInformationSettings storeInformationSettings,
            IWorkContext workContext,
            IStoreContext storeContext)
        {
            this._storeInformationSettings = storeInformationSettings;
            this._workContext = workContext;
            this._storeContext = storeContext;
        }

        public IViewComponentResult Invoke()
        {
            if (!_storeInformationSettings.DisplayEuCookieLawWarning)
                //disabled
                return Content("");

            //ignore search engines because some pages could be indexed with the EU cookie as description
            if (_workContext.CurrentCustomer.IsSearchEngineAccount())
                return Content("");

            if (_workContext.CurrentCustomer.GetAttribute<bool>(SystemCustomerAttributeNames.EuCookieLawAccepted, _storeContext.CurrentStore.Id))
                //already accepted
                return Content("");

            //ignore notification?
            //right now it's used during logout so popup window is not displayed twice
            if (TempData["nop.IgnoreEuCookieLawWarning"] != null && Convert.ToBoolean(TempData["nop.IgnoreEuCookieLawWarning"]))
                return Content("");

            return View();
        }
    }
}
