using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RufaPoint.Core;
using RufaPoint.Core.Caching;
using RufaPoint.Core.Domain.Catalog;
using RufaPoint.Services.Catalog;
using RufaPoint.Services.Security;
using RufaPoint.Services.Stores;
using RufaPoint.Web.Factories;
using RufaPoint.Web.Framework.Components;
using RufaPoint.Web.Infrastructure.Cache;

namespace RufaPoint.Web.Components
{
    public class RelatedProductsViewComponent : NopViewComponent
    {
        private readonly IProductModelFactory _productModelFactory;
        private readonly IProductService _productService;
        private readonly IStoreContext _storeContext;
        private readonly IAclService _aclService;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IStaticCacheManager _cacheManager;

        public RelatedProductsViewComponent(IProductModelFactory productModelFactory,
            IProductService productService,
            IStoreContext storeContext,
            IAclService aclService,
            IStoreMappingService storeMappingService,
            IStaticCacheManager cacheManager)
        {
            this._productModelFactory = productModelFactory;
            this._productService = productService;
            this._storeContext = storeContext;
            this._aclService = aclService;
            this._storeMappingService = storeMappingService;
            this._cacheManager = cacheManager;
        }

        public IViewComponentResult Invoke(int productId, int? productThumbPictureSize)
        {
            //load and cache report
            var productIds = _cacheManager.Get(string.Format(ModelCacheEventConsumer.PRODUCTS_RELATED_IDS_KEY, productId, _storeContext.CurrentStore.Id),
                () => _productService.GetRelatedProductsByProductId1(productId).Select(x => x.ProductId2).ToArray());

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
