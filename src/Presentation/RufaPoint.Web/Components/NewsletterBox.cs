using Microsoft.AspNetCore.Mvc;
using RufaPoint.Core.Domain.Customers;
using RufaPoint.Web.Factories;
using RufaPoint.Web.Framework.Components;

namespace RufaPoint.Web.Components
{
    public class NewsletterBoxViewComponent : NopViewComponent
    {
        private readonly INewsletterModelFactory _newsletterModelFactory;

        private readonly CustomerSettings _customerSettings;

        public NewsletterBoxViewComponent(INewsletterModelFactory newsletterModelFactory,
            CustomerSettings customerSettings)
        {
            this._newsletterModelFactory = newsletterModelFactory;
            this._customerSettings = customerSettings;
        }

        public IViewComponentResult Invoke()
        {
            if (_customerSettings.HideNewsletterBlock)
                return Content("");

            var model = _newsletterModelFactory.PrepareNewsletterBoxModel();
            return View(model);
        }
    }
}
