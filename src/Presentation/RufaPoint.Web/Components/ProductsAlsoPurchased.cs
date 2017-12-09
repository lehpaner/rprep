using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RufaPoint.Core;
using RufaPoint.Core.Caching;
using RufaPoint.Core.Domain.Catalog;
using RufaPoint.Services.Catalog;
using RufaPoint.Services.Orders;
using RufaPoint.Services.Security;
using RufaPoint.Services.Stores;
using RufaPoint.Web.Factories;
using RufaPoint.Web.Framework.Components;
using RufaPoint.Web.Infrastructure.Cache;

namespace RufaPoint.Web.Components
{
    public class ProductsAlsoPurchasedViewComponent : NopViewComponent
    {
        private readonly CatalogSettings _catalogSettings;
        private readonly IProductModelFactory _productModelFactory;
        private readonly IProductService _productService;
        private readonly IStoreContext _storeContext;
        private readonly IAclService _aclService;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IOrderReportService _orderReportService;
        private readonly IStaticCacheManager _cacheManager;

        public ProductsAlsoPurchasedViewComponent(CatalogSettings catalogSettings,
            IProductModelFactory productModelFactory,
            IProductService productService,
            IStoreContext storeContext,
            IAclService aclService,
            IStoreMappingService storeMappingService,
            IOrderReportService orderReportService,
            IStaticCacheManager cacheManager)
        {
            this._catalogSettings = catalogSettings;
            this._productModelFactory = productModelFactory;
            this._productService = productService;
            this._storeContext = storeContext;
            this._aclService = aclService;
            this._storeMappingService = storeMappingService;
            this._orderReportService = orderReportService;
            this._cacheManager = cacheManager;
        }

        public IViewComponentResult Invoke(int productId, int? productThumbPictureSize)
        {
            if (!_catalogSettings.ProductsAlsoPurchasedEnabled)
                return Content("");

            //load and cache report
            var productIds = _cacheManager.Get(string.Format(ModelCacheEventConsumer.PRODUCTS_ALSO_PURCHASED_IDS_KEY, productId, _storeContext.CurrentStore.Id),
                () => _orderReportService.GetAlsoPurchasedProductsIds(_storeContext.CurrentStore.Id, productId, _catalogSettings.ProductsAlsoPurchasedNumber)
            );

            //load products
            var products = _productService.GetProductsByIds(productIds);
            //ACL and store mapping
            products = products.Where(p => _aclService.Authorize(p) && _storeMappingService.Authorize(p)).ToList();
            //availability dates
            products = products.Where(p => p.IsAvailable()).ToList();

            if (!products.Any())
                return Content("");

            var model = _productModelFactory.PrepareProductOverviewModels(products, true, true, productThumbPictureSize).ToList();
            return View(model);
        }
    }
}
