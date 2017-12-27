using System;
using System.Collections.Generic;
using RufaPoint.Core;
using RufaPoint.Core.Caching;
using RufaPoint.Core.Data;
using RufaPoint.Core.Domain.Catalog;
using RufaPoint.Core.Domain.Orders;
using RufaPoint.Core.Domain.Shipping;
using RufaPoint.Core.Domain.Stores;
using RufaPoint.Core.Plugins;
using RufaPoint.Services.Catalog;
using RufaPoint.Services.Common;
using RufaPoint.Services.Events;
using RufaPoint.Services.Localization;
using RufaPoint.Services.Logging;
using RufaPoint.Services.Orders;
using RufaPoint.Services.Shipping;
using RufaPoint.Tests;
using Xunit;
using Moq;

namespace RufaPoint.Services.Tests.Shipping
{

    public class CalculateDimensionsTests : ServiceTest
    {
        private Mock<IRepository<ShippingMethod>> _shippingMethodRepository;
        private Mock<IRepository<Warehouse>> _warehouseRepository;
        private ILogger _logger;
        private Mock<IProductAttributeParser> _productAttributeParser;
        private Mock<ICheckoutAttributeParser> _checkoutAttributeParser;
        private ShippingSettings _shippingSettings;
        private Mock<IEventPublisher> _eventPublisher;
        private Mock<ILocalizationService> _localizationService;
        private Mock<IAddressService> _addressService;
        private Mock<IGenericAttributeService> _genericAttributeService;
        private IShippingService _shippingService;
        private ShoppingCartSettings _shoppingCartSettings;
        private Mock<IProductService> _productService;
        private Store _store;
        private Mock<IStoreContext> _storeContext;

        public CalculateDimensionsTests()
        {
            _shippingSettings = new ShippingSettings
            {
                UseCubeRootMethod = true,
                ConsiderAssociatedProductsDimensions = true
            };

            _shippingMethodRepository = new Mock<IRepository<ShippingMethod>>();
            _warehouseRepository = new Mock<IRepository<Warehouse>>();
            _logger = new NullLogger();
            _productAttributeParser = new Mock<IProductAttributeParser>();
            _checkoutAttributeParser = new Mock<ICheckoutAttributeParser>();

            var cacheManager = new NopNullCache();

            var pluginFinder = new PluginFinder();
            _productService = new Mock<IProductService>();

            _eventPublisher = new Mock<IEventPublisher>();
            _eventPublisher.Setup(x => x.Publish(It.IsAny<object>()));

            _localizationService = new Mock<ILocalizationService>();
            _addressService = new Mock<IAddressService>();
            _genericAttributeService = new Mock<IGenericAttributeService>();

            _store = new Store { Id = 1 };
            _storeContext = new Mock<IStoreContext>();
            _storeContext.Setup(x => x.CurrentStore).Returns(_store);

            _shoppingCartSettings = new ShoppingCartSettings();
            _shippingService = new ShippingService(_shippingMethodRepository.Object,
                _warehouseRepository.Object,
                _logger,
                _productService.Object,
                _productAttributeParser.Object,
                _checkoutAttributeParser.Object,
                _genericAttributeService.Object,
                _localizationService.Object,
                _addressService.Object,
                _shippingSettings,
                pluginFinder,
                _storeContext.Object,
                _eventPublisher.Object,
                _shoppingCartSettings,
                cacheManager);
        }

        [Fact]
        public void should_return_zero_with_all_zero_dimensions()
        {
            var items = new List<GetShippingOptionRequest.PackageItem>
            {
                new GetShippingOptionRequest.PackageItem(new ShoppingCartItem
                    {
                        Quantity = 1,
                        Product = new Product
                        {
                            Length = 0,
                            Width = 0,
                            Height = 0
                        }
                    }),
            };

            _shippingService.GetDimensions(items, out decimal width, out decimal length, out decimal height);
            length.ShouldEqual(0);
            width.ShouldEqual(0);
            height.ShouldEqual(0);

            items = new List<GetShippingOptionRequest.PackageItem>
            {
                new GetShippingOptionRequest.PackageItem(new ShoppingCartItem
                    {
                        Quantity = 2,
                        Product = new Product
                        {
                            Length = 0,
                            Width = 0,
                            Height = 0
                        }
                    }),
            };

            _shippingService.GetDimensions(items, out width, out length, out height);
            length.ShouldEqual(0);
            width.ShouldEqual(0);
            height.ShouldEqual(0);
        }
        
        [Fact]
        public void can_calculate_with_single_item_and_qty_1_should_ignore_cubic_method()
        {
            var items = new List<GetShippingOptionRequest.PackageItem>
            {
                new GetShippingOptionRequest.PackageItem(new ShoppingCartItem
                {
                    Quantity = 1,
                    Product = new Product
                    {
                        Length = 2,
                        Width = 3,
                        Height = 4
                    }
                })
            };

            _shippingService.GetDimensions(items, out decimal width, out decimal length, out decimal height);
            length.ShouldEqual(2);
            width.ShouldEqual(3);
            height.ShouldEqual(4);
        }

        [Fact]
        public void can_calculate_with_single_item_and_qty_2()
        {
            var items = new List<GetShippingOptionRequest.PackageItem>
            {
                new GetShippingOptionRequest.PackageItem(new ShoppingCartItem
                {
                    Quantity = 2,
                    Product = new Product
                    {
                        Length = 2,
                        Width = 4,
                        Height = 4
                    }
                })
            };

            _shippingService.GetDimensions(items, out decimal width, out decimal length, out decimal height);
            length.ShouldEqual(4);
            width.ShouldEqual(4);
            height.ShouldEqual(4);
        }

        [Fact]
        public void can_calculate_with_cubic_item_and_multiple_qty()
        {
            var items = new List<GetShippingOptionRequest.PackageItem>
            {
                new GetShippingOptionRequest.PackageItem(new ShoppingCartItem
                {
                    Quantity = 3,
                    Product = new Product
                    {
                        Length = 2,
                        Width = 2,
                        Height = 2
                    }
                })
            };
            
            _shippingService.GetDimensions(items, out decimal width, out decimal length, out decimal height);
            Math.Round(length, 2).ShouldEqual(2.88);
            Math.Round(width, 2).ShouldEqual(2.88);
            Math.Round(height, 2).ShouldEqual(2.88);
        }

        [Fact]
        public void can_calculate_with_multiple_items_1()
        {
            var items = new List<GetShippingOptionRequest.PackageItem>
            {
                new GetShippingOptionRequest.PackageItem(new ShoppingCartItem
                                {
                                    Quantity = 3,
                                    Product = new Product
                                    {
                                        Length = 2,
                                        Width = 2,
                                        Height = 2
                                    }
                                }),
                new GetShippingOptionRequest.PackageItem(new ShoppingCartItem
                                {
                                    Quantity = 1,
                                    Product = new Product
                                    {
                                        Length = 3,
                                        Width = 5,
                                        Height = 2
                                    }
                                })
            };

            _shippingService.GetDimensions(items, out decimal width, out decimal length, out decimal height);
            Math.Round(length, 2).ShouldEqual(3.78);
            Math.Round(width, 2).ShouldEqual(5);    //preserve max width
            Math.Round(height, 2).ShouldEqual(3.78);
        }

        [Fact]
        public void can_calculate_with_multiple_items_2()
        {
            //take 8 cubes of 1x1x1 which is "packed" as 2x2x2 
            var items = new List<GetShippingOptionRequest.PackageItem>();
            for (var i = 0; i < 8; i++)
                items.Add(new GetShippingOptionRequest.PackageItem(new ShoppingCartItem
                        {
                            Quantity = 1,
                            Product = new Product
                                {
                                    Length = 1,
                                    Width = 1,
                                    Height = 1
                                }
                        }));

            _shippingService.GetDimensions(items, out decimal width, out decimal length, out decimal height);
            Math.Round(length, 2).ShouldEqual(2);
            Math.Round(width, 2).ShouldEqual(2);
            Math.Round(height, 2).ShouldEqual(2);
        }
    }
}
