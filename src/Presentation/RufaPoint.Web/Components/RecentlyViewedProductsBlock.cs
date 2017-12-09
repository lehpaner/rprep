using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RufaPoint.Core.Domain.Catalog;
using RufaPoint.Services.Catalog;
using RufaPoint.Services.Security;
using RufaPoint.Services.Stores;
using RufaPoint.Web.Factories;
using RufaPoint.Web.Framework.Components;
using RufaPoint.Web.Models.Catalog;

namespace RufaPoint.Web.Components
{
    public class RecentlyViewedProductsBlockViewComponent : NopViewComponent
    {
        private readonly IAclService _aclService;
        private readonly CatalogSettings _catalogSettings;
        private readonly IProductModelFactory _productModelFactory;
        private readonly IRecentlyViewedProductsService _recentlyViewedProductsService;
        private readonly IStoreMappingService _storeMappingService;

        public RecentlyViewedProductsBlockViewComponent(IAclService aclService,
            CatalogSettings catalogSettings,
            IProductModelFactory productModelFactory,
            IRecentlyViewedProductsService recentlyViewedProductsService,
            IStoreMappingService storeMappingService)
        {
            this._aclService = aclService;
            this._catalogSettings = catalogSettings;
            this._productModelFactory = productModelFactory;
            this._recentlyViewedProductsService = recentlyViewedProductsService;
            this._storeMappingService = storeMappingService;
        }

        public IViewComponentResult Invoke(int? productThumbPictureSize, bool? preparePriceModel)
        {
            if (!_catalogSettings.RecentlyViewedProductsEnabled)
                return Content("");

            var preparePictureModel = productThumbPictureSize.HasValue;
            var products = _recentlyViewedProductsService.GetRecentlyViewedProducts(_catalogSettings.RecentlyViewedProductsNumber);

            //ACL and store mapping
            products = products.Where(p => _aclService.Authorize(p) && _storeMappingService.Authorize(p)).ToList();
            //availability dates
            products = products.Where(p => p.IsAvailable()).ToList();

            if (!products.Any())
                return Content("");

            //prepare model
            var model = new List<ProductOverviewModel>();
            model.AddRange(_productModelFactory.PrepareProductOverviewModels(products,
                preparePriceModel.GetValueOrDefault(),
                preparePictureModel,
                productThumbPictureSize));

            return View(model);
        }
    }
}
