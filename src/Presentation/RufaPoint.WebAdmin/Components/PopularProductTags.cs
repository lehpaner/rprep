using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RufaPoint.Web.Factories;
using RufaPoint.Web.Framework.Components;

namespace RufaPoint.Web.Components
{
    public class PopularProductTagsViewComponent : NopViewComponent
    {
        private readonly ICatalogModelFactory _catalogModelFactory;

        public PopularProductTagsViewComponent(ICatalogModelFactory catalogModelFactory)
        {
            this._catalogModelFactory = catalogModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _catalogModelFactory.PreparePopularProductTagsModel();

            if (!model.Tags.Any())
                return Content("");

            return View(model);
        }
    }
}
