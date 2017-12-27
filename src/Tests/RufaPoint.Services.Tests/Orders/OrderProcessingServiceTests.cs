using System;
using System.Collections.Generic;
using RufaPoint.Core;
using RufaPoint.Core.Caching;
using RufaPoint.Core.Data;
using RufaPoint.Core.Domain.Catalog;
using RufaPoint.Core.Domain.Common;
using RufaPoint.Core.Domain.Customers;
using RufaPoint.Core.Domain.Directory;
using RufaPoint.Core.Domain.Localization;
using RufaPoint.Core.Domain.Orders;
using RufaPoint.Core.Domain.Payments;
using RufaPoint.Core.Domain.Shipping;
using RufaPoint.Core.Domain.Stores;
using RufaPoint.Core.Domain.Tax;
using RufaPoint.Core.Plugins;
using RufaPoint.Services.Affiliates;
using RufaPoint.Services.Catalog;
using RufaPoint.Services.Common;
using RufaPoint.Services.Customers;
using RufaPoint.Services.Directory;
using RufaPoint.Services.Discounts;
using RufaPoint.Services.Events;
using RufaPoint.Services.Localization;
using RufaPoint.Services.Logging;
using RufaPoint.Services.Messages;
using RufaPoint.Services.Orders;
using RufaPoint.Services.Payments;
using RufaPoint.Services.Security;
using RufaPoint.Services.Shipping;
using RufaPoint.Services.Tax;
using RufaPoint.Services.Vendors;
using RufaPoint.Tests;
using Xunit;
using Moq;

namespace RufaPoint.Services.Tests.Orders
{
    public class OrderProcessingServiceTests : ServiceTest
    {
        private IWorkContext _workContext;
        private Mock<IStoreContext> _storeContext;
        private ITaxService _taxService;
        private IShippingService _shippingService;
        private Mock<IShipmentService> _shipmentService;
        private Mock<IPaymentService> _paymentService;
        private Mock<ICheckoutAttributeParser> _checkoutAttributeParser;
        private Mock<IDiscountService> _discountService;
        private Mock<IGiftCardService> _giftCardService;
        private Mock<IGenericAttributeService> _genericAttributeService;
        private TaxSettings _taxSettings;
        private RewardPointsSettings _rewardPointsSettings;
        private Mock<ICategoryService> _categoryService;
        private Mock<IManufacturerService> _manufacturerService;
        private Mock<IProductAttributeParser> _productAttributeParser;
        private IPriceCalculationService _priceCalcService;
        private IOrderTotalCalculationService _orderTotalCalcService;
        private Mock<IAddressService> _addressService;
        private ShippingSettings _shippingSettings;
        private ILogger _logger;
        private Mock<IRepository<ShippingMethod>> _shippingMethodRepository;
        private Mock<IRepository<Warehouse>> _warehouseRepository;
        private Mock<IOrderService> _orderService;
        private Mock<IWebHelper> _webHelper;
        private Mock<ILocalizationService> _localizationService;
        private Mock<ILanguageService> _languageService;
        private Mock<IProductService> _productService;
        private Mock<IPriceFormatter> _priceFormatter;
        private Mock<IProductAttributeFormatter> _productAttributeFormatter;
        private Mock<IShoppingCartService> _shoppingCartService;
        private Mock<ICheckoutAttributeFormatter> _checkoutAttributeFormatter;
        private Mock<ICustomerService> _customerService;
        private Mock<IEncryptionService> _encryptionService;
        private Mock<IWorkflowMessageService> _workflowMessageService;
        private Mock<ICustomerActivityService> _customerActivityService;
        private Mock<ICurrencyService> _currencyService;
        private PaymentSettings _paymentSettings;
        private OrderSettings _orderSettings;
        private LocalizationSettings _localizationSettings;
        private ShoppingCartSettings _shoppingCartSettings;
        private CatalogSettings _catalogSettings;
        private IOrderProcessingService _orderProcessingService;
        private Mock<IEventPublisher> _eventPublisher;
        private CurrencySettings _currencySettings;
        private Mock<IAffiliateService> _affiliateService;
        private Mock<IVendorService> _vendorService;
        private Mock<IPdfService> _pdfService;
        private Mock<IRewardPointService> _rewardPointService;

        private Mock<IGeoLookupService> _geoLookupService;
        private Mock<ICountryService> _countryService;
        private Mock<IStateProvinceService> _stateProvinceService;
        private CustomerSettings _customerSettings;
        private AddressSettings _addressSettings;
        private Mock<ICustomNumberFormatter> _customNumberFormatter;

        private Store _store;


        public OrderProcessingServiceTests()
        {
            _workContext = null;

            _store = new Store { Id = 1 };
            _storeContext = new Mock<IStoreContext>();
            _storeContext.Setup(x => x.CurrentStore).Returns(_store);

            var pluginFinder = new PluginFinder();

            _shoppingCartSettings = new ShoppingCartSettings();
            _catalogSettings = new CatalogSettings();
            
            var cacheManager = new DummyCacheManager();

            _productService = new Mock<IProductService>();

            //price calculation service
            _discountService = new Mock<IDiscountService>();
            _categoryService = new Mock<ICategoryService>();
            _manufacturerService = new Mock<IManufacturerService>();

            _productAttributeParser = new Mock<IProductAttributeParser>();
            _priceCalcService = new PriceCalculationService(_workContext, _storeContext.Object,
                _discountService.Object, _categoryService.Object, _manufacturerService.Object,
                _productAttributeParser.Object, _productService.Object, 
                cacheManager, _shoppingCartSettings, _catalogSettings);

            _eventPublisher = new Mock<IEventPublisher>();
            _eventPublisher.Setup(x => x.Publish(It.IsAny<object>()));

            _localizationService = new Mock<ILocalizationService>();

            //shipping
            _shippingSettings = new ShippingSettings
            {
                ActiveShippingRateComputationMethodSystemNames = new List<string>()
            };
            _shippingSettings.ActiveShippingRateComputationMethodSystemNames.Add("FixedRateTestShippingRateComputationMethod");
            _shippingMethodRepository = new Mock<IRepository<ShippingMethod>>();
            _warehouseRepository = new Mock<IRepository<Warehouse>>();
            _logger = new NullLogger();
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
            _shipmentService = new Mock<IShipmentService>();
            

            _paymentService = new Mock<IPaymentService>();
            _checkoutAttributeParser = new Mock<ICheckoutAttributeParser>();
            _giftCardService = new Mock<IGiftCardService>();
            _genericAttributeService = new Mock<IGenericAttributeService>();

            _geoLookupService = new Mock<IGeoLookupService>();
            _countryService = new Mock<ICountryService>();
            _stateProvinceService = new Mock<IStateProvinceService>();
            _customerSettings = new CustomerSettings();
            _addressSettings = new AddressSettings();

            //tax
            _taxSettings = new TaxSettings
            {
                ShippingIsTaxable = true,
                PaymentMethodAdditionalFeeIsTaxable = true,
                DefaultTaxAddressId = 10
            };
            _addressService = new Mock<IAddressService>();
            _addressService.Setup(x => x.GetAddressById(_taxSettings.DefaultTaxAddressId)).Returns(new Address { Id = _taxSettings.DefaultTaxAddressId });
            _taxService = new TaxService(_addressService.Object, _workContext, _storeContext.Object, _taxSettings,
                pluginFinder, _geoLookupService.Object, _countryService.Object, _stateProvinceService.Object, _logger, _webHelper.Object,
                _customerSettings, _shippingSettings, _addressSettings);

            _rewardPointService = new Mock<IRewardPointService>();
            _rewardPointsSettings = new RewardPointsSettings();

            _orderTotalCalcService = new OrderTotalCalculationService(_workContext, _storeContext.Object,
                _priceCalcService, _productService.Object, _productAttributeParser.Object, _taxService, _shippingService, _paymentService.Object,
                _checkoutAttributeParser.Object, _discountService.Object, _giftCardService.Object,
                _genericAttributeService.Object, _rewardPointService.Object,
                _taxSettings, _rewardPointsSettings, _shippingSettings, _shoppingCartSettings, _catalogSettings);

            _orderService = new Mock<IOrderService>();
            _webHelper = new Mock<IWebHelper>();
            _languageService = new Mock<ILanguageService>();
            _priceFormatter= new Mock<IPriceFormatter>();
            _productAttributeFormatter= new Mock<IProductAttributeFormatter>();
            _shoppingCartService= new Mock<IShoppingCartService>();
            _checkoutAttributeFormatter= new Mock<ICheckoutAttributeFormatter>();
            _customerService= new Mock<ICustomerService>();
            _encryptionService = new Mock<IEncryptionService>();
            _workflowMessageService = new Mock<IWorkflowMessageService>();
            _customerActivityService = new Mock<ICustomerActivityService>();
            _currencyService = new Mock<ICurrencyService>();
            _affiliateService = new Mock<IAffiliateService>();
            _vendorService = new Mock<IVendorService>();
            _pdfService = new Mock<IPdfService>();
            _customNumberFormatter = new Mock<ICustomNumberFormatter>();

            _paymentSettings = new PaymentSettings
            {
                ActivePaymentMethodSystemNames = new List<string>
                {
                    "Payments.TestMethod"
                }
            };
            _orderSettings = new OrderSettings();

            _localizationSettings = new LocalizationSettings();

            _eventPublisher = new Mock<IEventPublisher>();
            _eventPublisher.Setup(x => x.Publish(It.IsAny<object>()));

            _rewardPointService = new Mock<IRewardPointService>();
            _currencySettings = new CurrencySettings();

            _orderProcessingService = new OrderProcessingService(_orderService.Object, _webHelper.Object,
                _localizationService.Object, _languageService.Object,
                _productService.Object, _paymentService.Object, _logger,
                _orderTotalCalcService, _priceCalcService, _priceFormatter.Object,
                _productAttributeParser.Object, _productAttributeFormatter.Object,
                _giftCardService.Object, _shoppingCartService.Object, _checkoutAttributeFormatter.Object,
                _shippingService, _shipmentService.Object, _taxService,
                _customerService.Object, _discountService.Object,
                _encryptionService.Object, _workContext, 
                _workflowMessageService.Object, _vendorService.Object,
                _customerActivityService.Object, _currencyService.Object, _affiliateService.Object,
                _eventPublisher.Object, _pdfService.Object, _rewardPointService.Object,
                _genericAttributeService.Object,
                _countryService.Object, _stateProvinceService.Object,
                _shippingSettings, _paymentSettings, _rewardPointsSettings,
                _orderSettings, _taxSettings, _localizationSettings,
                _currencySettings, _customNumberFormatter.Object);
        }
        
        [Fact]
        public void Ensure_order_can_only_be_cancelled_when_orderStatus_is_not_cancelled_yet()
        {
            var order = new Order();
            foreach (OrderStatus os in Enum.GetValues(typeof(OrderStatus)))
                foreach (PaymentStatus ps in Enum.GetValues(typeof(PaymentStatus)))
                    foreach (ShippingStatus ss in Enum.GetValues(typeof(ShippingStatus)))
                    {
                        order.OrderStatus = os;
                        order.PaymentStatus = ps;
                        order.ShippingStatus = ss;
                        if (os != OrderStatus.Cancelled)
                            _orderProcessingService.CanCancelOrder(order).ShouldBeTrue();
                        else
                            _orderProcessingService.CanCancelOrder(order).ShouldBeFalse();
                    }
        }

        [Fact]
        public void Ensure_order_can_only_be_marked_as_authorized_when_orderStatus_is_not_cancelled_and_paymentStatus_is_pending()
        {
            var order = new Order();
            foreach (OrderStatus os in Enum.GetValues(typeof(OrderStatus)))
                foreach (PaymentStatus ps in Enum.GetValues(typeof(PaymentStatus)))
                    foreach (ShippingStatus ss in Enum.GetValues(typeof(ShippingStatus)))
                    {
                        order.OrderStatus = os;
                        order.PaymentStatus = ps;
                        order.ShippingStatus = ss;
                        if (os != OrderStatus.Cancelled && ps == PaymentStatus.Pending)
                            _orderProcessingService.CanMarkOrderAsAuthorized(order).ShouldBeTrue();
                        else
                            _orderProcessingService.CanMarkOrderAsAuthorized(order).ShouldBeFalse();
                    }
        }

        [Fact]
        public void Ensure_order_can_only_be_captured_when_orderStatus_is_not_cancelled_or_pending_and_paymentstatus_is_authorized_and_paymentModule_supports_capture()
        {
            _paymentService.Setup(ps => ps.SupportCapture("paymentMethodSystemName_that_supports_capture")).Returns(true);
            _paymentService.Setup(ps => ps.SupportCapture("paymentMethodSystemName_that_doesn't_support_capture")).Returns(false);
            var order = new Order
            {
                PaymentMethodSystemName = "paymentMethodSystemName_that_supports_capture"
            };
            foreach (OrderStatus os in Enum.GetValues(typeof(OrderStatus)))
                foreach (PaymentStatus ps in Enum.GetValues(typeof(PaymentStatus)))
                    foreach (ShippingStatus ss in Enum.GetValues(typeof(ShippingStatus)))
                    {
                        order.OrderStatus = os;
                        order.PaymentStatus = ps;
                        order.ShippingStatus = ss;

                        if ((os != OrderStatus.Cancelled && os != OrderStatus.Pending)
                            && (ps == PaymentStatus.Authorized))
                            _orderProcessingService.CanCapture(order).ShouldBeTrue();
                        else
                            _orderProcessingService.CanCapture(order).ShouldBeFalse();
                    }


            order.PaymentMethodSystemName = "paymentMethodSystemName_that_doesn't_support_capture";
            foreach (OrderStatus os in Enum.GetValues(typeof(OrderStatus)))
                foreach (PaymentStatus ps in Enum.GetValues(typeof(PaymentStatus)))
                    foreach (ShippingStatus ss in Enum.GetValues(typeof(ShippingStatus)))
                    {
                        order.OrderStatus = os;
                        order.PaymentStatus = ps;
                        order.ShippingStatus = ss;

                        _orderProcessingService.CanCapture(order).ShouldBeFalse();
                    }
        }
        
        [Fact]
        public void Ensure_order_cannot_be_marked_as_paid_when_orderStatus_is_cancelled_or_paymentStatus_is_paid_or_refunded_or_voided()
        {
            var order = new Order();
            foreach (OrderStatus os in Enum.GetValues(typeof(OrderStatus)))
                foreach (PaymentStatus ps in Enum.GetValues(typeof(PaymentStatus)))
                    foreach (ShippingStatus ss in Enum.GetValues(typeof(ShippingStatus)))
                    {
                        order.OrderStatus = os;
                        order.PaymentStatus = ps;
                        order.ShippingStatus = ss;
                        if (os == OrderStatus.Cancelled
                            || (ps == PaymentStatus.Paid || ps == PaymentStatus.Refunded || ps == PaymentStatus.Voided))
                            _orderProcessingService.CanMarkOrderAsPaid(order).ShouldBeFalse();
                        else
                            _orderProcessingService.CanMarkOrderAsPaid(order).ShouldBeTrue();
                    }
        }

        [Fact]
        public void Ensure_order_can_only_be_refunded_when_paymentstatus_is_paid_and_paymentModule_supports_refund()
        {
            _paymentService.Setup(ps => ps.SupportRefund("paymentMethodSystemName_that_supports_refund")).Returns(true);
            _paymentService.Setup(ps => ps.SupportRefund("paymentMethodSystemName_that_doesn't_support_refund")).Returns(false);
            var order = new Order
            {
                OrderTotal = 1,
                PaymentMethodSystemName = "paymentMethodSystemName_that_supports_refund"
            };

            foreach (OrderStatus os in Enum.GetValues(typeof(OrderStatus)))
                foreach (PaymentStatus ps in Enum.GetValues(typeof(PaymentStatus)))
                    foreach (ShippingStatus ss in Enum.GetValues(typeof(ShippingStatus)))
                    {
                        order.OrderStatus = os;
                        order.PaymentStatus = ps;
                        order.ShippingStatus = ss;

                        if (ps == PaymentStatus.Paid)
                            _orderProcessingService.CanRefund(order).ShouldBeTrue();
                        else
                            _orderProcessingService.CanRefund(order).ShouldBeFalse();
                    }



            order.PaymentMethodSystemName = "paymentMethodSystemName_that_doesn't_support_refund";
            foreach (OrderStatus os in Enum.GetValues(typeof(OrderStatus)))
                foreach (PaymentStatus ps in Enum.GetValues(typeof(PaymentStatus)))
                    foreach (ShippingStatus ss in Enum.GetValues(typeof(ShippingStatus)))
                    {
                        order.OrderStatus = os;
                        order.PaymentStatus = ps;
                        order.ShippingStatus = ss;

                        _orderProcessingService.CanRefund(order).ShouldBeFalse();
                    }
        }

        [Fact]
        public void Ensure_order_cannot_be_refunded_when_orderTotal_is_zero()
        {
            _paymentService.Setup(ps => ps.SupportRefund("paymentMethodSystemName_that_supports_refund")).Returns(true);
            var order = new Order
            {
                PaymentMethodSystemName = "paymentMethodSystemName_that_supports_refund"
            };

            foreach (OrderStatus os in Enum.GetValues(typeof(OrderStatus)))
                foreach (PaymentStatus ps in Enum.GetValues(typeof(PaymentStatus)))
                    foreach (ShippingStatus ss in Enum.GetValues(typeof(ShippingStatus)))
                    {
                        order.OrderStatus = os;
                        order.PaymentStatus = ps;
                        order.ShippingStatus = ss;

                        _orderProcessingService.CanRefund(order).ShouldBeFalse();
                    }
        }
        
        [Fact]
        public void Ensure_order_can_only_be_refunded_offline_when_paymentstatus_is_paid()
        {
            var order = new Order
            {
                OrderTotal = 1,
            };
            foreach (OrderStatus os in Enum.GetValues(typeof(OrderStatus)))
                foreach (PaymentStatus ps in Enum.GetValues(typeof(PaymentStatus)))
                    foreach (ShippingStatus ss in Enum.GetValues(typeof(ShippingStatus)))
                    {
                        order.OrderStatus = os;
                        order.PaymentStatus = ps;
                        order.ShippingStatus = ss;

                        if (ps == PaymentStatus.Paid)
                            _orderProcessingService.CanRefundOffline(order).ShouldBeTrue();
                        else
                            _orderProcessingService.CanRefundOffline(order).ShouldBeFalse();
                    }
        }

        [Fact]
        public void Ensure_order_cannot_be_refunded_offline_when_orderTotal_is_zero()
        {
            var order = new Order();

            foreach (OrderStatus os in Enum.GetValues(typeof(OrderStatus)))
                foreach (PaymentStatus ps in Enum.GetValues(typeof(PaymentStatus)))
                    foreach (ShippingStatus ss in Enum.GetValues(typeof(ShippingStatus)))
                    {
                        order.OrderStatus = os;
                        order.PaymentStatus = ps;
                        order.ShippingStatus = ss;

                        _orderProcessingService.CanRefundOffline(order).ShouldBeFalse();
                    }
        }

        [Fact]
        public void Ensure_order_can_only_be_voided_when_paymentstatus_is_authorized_and_paymentModule_supports_void()
        {
            _paymentService.Setup(ps => ps.SupportVoid("paymentMethodSystemName_that_supports_void")).Returns(true);
            _paymentService.Setup(ps => ps.SupportVoid("paymentMethodSystemName_that_doesn't_support_void")).Returns(false);
            var order = new Order
            {
                OrderTotal = 1,
                PaymentMethodSystemName = "paymentMethodSystemName_that_supports_void"
            };

            foreach (OrderStatus os in Enum.GetValues(typeof(OrderStatus)))
                foreach (PaymentStatus ps in Enum.GetValues(typeof(PaymentStatus)))
                    foreach (ShippingStatus ss in Enum.GetValues(typeof(ShippingStatus)))
                    {
                        order.OrderStatus = os;
                        order.PaymentStatus = ps;
                        order.ShippingStatus = ss;

                        if (ps == PaymentStatus.Authorized)
                            _orderProcessingService.CanVoid(order).ShouldBeTrue();
                        else
                            _orderProcessingService.CanVoid(order).ShouldBeFalse();
                    }



            order.PaymentMethodSystemName = "paymentMethodSystemName_that_doesn't_support_void";
            foreach (OrderStatus os in Enum.GetValues(typeof(OrderStatus)))
                foreach (PaymentStatus ps in Enum.GetValues(typeof(PaymentStatus)))
                    foreach (ShippingStatus ss in Enum.GetValues(typeof(ShippingStatus)))
                    {
                        order.OrderStatus = os;
                        order.PaymentStatus = ps;
                        order.ShippingStatus = ss;

                        _orderProcessingService.CanVoid(order).ShouldBeFalse();
                    }
        }

        [Fact]
        public void Ensure_order_cannot_be_voided_when_orderTotal_is_zero()
        {
            _paymentService.Setup(ps => ps.SupportVoid("paymentMethodSystemName_that_supports_void")).Returns(true);
            var order = new Order
            {
                PaymentMethodSystemName = "paymentMethodSystemName_that_supports_void"
            };

            foreach (OrderStatus os in Enum.GetValues(typeof(OrderStatus)))
                foreach (PaymentStatus ps in Enum.GetValues(typeof(PaymentStatus)))
                    foreach (ShippingStatus ss in Enum.GetValues(typeof(ShippingStatus)))
                    {
                        order.OrderStatus = os;
                        order.PaymentStatus = ps;
                        order.ShippingStatus = ss;

                        _orderProcessingService.CanVoid(order).ShouldBeFalse();
                    }
        }

        [Fact]
        public void Ensure_order_can_only_be_voided_offline_when_paymentstatus_is_authorized()
        {
            var order = new Order
            {
                OrderTotal = 1,
            };
            foreach (OrderStatus os in Enum.GetValues(typeof(OrderStatus)))
                foreach (PaymentStatus ps in Enum.GetValues(typeof(PaymentStatus)))
                    foreach (ShippingStatus ss in Enum.GetValues(typeof(ShippingStatus)))
                    {
                        order.OrderStatus = os;
                        order.PaymentStatus = ps;
                        order.ShippingStatus = ss;

                        if (ps == PaymentStatus.Authorized)
                            _orderProcessingService.CanVoidOffline(order).ShouldBeTrue();
                        else
                            _orderProcessingService.CanVoidOffline(order).ShouldBeFalse();
                    }
        }

        [Fact]
        public void Ensure_order_cannot_be_voided_offline_when_orderTotal_is_zero()
        {
            var order = new Order();

            foreach (OrderStatus os in Enum.GetValues(typeof(OrderStatus)))
                foreach (PaymentStatus ps in Enum.GetValues(typeof(PaymentStatus)))
                    foreach (ShippingStatus ss in Enum.GetValues(typeof(ShippingStatus)))
                    {
                        order.OrderStatus = os;
                        order.PaymentStatus = ps;
                        order.ShippingStatus = ss;

                        _orderProcessingService.CanVoidOffline(order).ShouldBeFalse();
                    }
        }

        [Fact]
        public void Ensure_order_can_only_be_partially_refunded_when_paymentstatus_is_paid_or_partiallyRefunded_and_paymentModule_supports_partialRefund()
        {
            _paymentService.Setup(ps => ps.SupportPartiallyRefund("paymentMethodSystemName_that_supports_partialrefund")).Returns(true);
            _paymentService.Setup(ps => ps.SupportPartiallyRefund("paymentMethodSystemName_that_doesn't_support_partialrefund")).Returns(false);
            var order = new Order
            {
                OrderTotal = 100,
                PaymentMethodSystemName = "paymentMethodSystemName_that_supports_partialrefund"
            };

            foreach (OrderStatus os in Enum.GetValues(typeof(OrderStatus)))
                foreach (PaymentStatus ps in Enum.GetValues(typeof(PaymentStatus)))
                    foreach (ShippingStatus ss in Enum.GetValues(typeof(ShippingStatus)))
                    {
                        order.OrderStatus = os;
                        order.PaymentStatus = ps;
                        order.ShippingStatus = ss;

                        if (ps == PaymentStatus.Paid || order.PaymentStatus == PaymentStatus.PartiallyRefunded)
                            _orderProcessingService.CanPartiallyRefund(order, 10).ShouldBeTrue();
                        else
                            _orderProcessingService.CanPartiallyRefund(order, 10).ShouldBeFalse();
                    }



            order.PaymentMethodSystemName = "paymentMethodSystemName_that_doesn't_support_partialrefund";
            foreach (OrderStatus os in Enum.GetValues(typeof(OrderStatus)))
                foreach (PaymentStatus ps in Enum.GetValues(typeof(PaymentStatus)))
                    foreach (ShippingStatus ss in Enum.GetValues(typeof(ShippingStatus)))
                    {
                        order.OrderStatus = os;
                        order.PaymentStatus = ps;
                        order.ShippingStatus = ss;

                        _orderProcessingService.CanPartiallyRefund(order, 10).ShouldBeFalse();
                    }
        }

        [Fact]
        public void Ensure_order_cannot_be_partially_refunded_when_amountToRefund_is_greater_than_amount_that_can_be_refunded()
        {
            _paymentService.Setup(ps => ps.SupportPartiallyRefund("paymentMethodSystemName_that_supports_partialrefund")).Returns(true);
            var order = new Order
            {
                OrderTotal = 100,
                RefundedAmount = 30, //100-30=70 can be refunded
            };
            order.PaymentMethodSystemName = "paymentMethodSystemName_that_supports_partialrefund";

            foreach (OrderStatus os in Enum.GetValues(typeof(OrderStatus)))
                foreach (PaymentStatus ps in Enum.GetValues(typeof(PaymentStatus)))
                    foreach (ShippingStatus ss in Enum.GetValues(typeof(ShippingStatus)))
                    {
                        order.OrderStatus = os;
                        order.PaymentStatus = ps;
                        order.ShippingStatus = ss;

                        _orderProcessingService.CanPartiallyRefund(order, 80).ShouldBeFalse();
                    }
        }

        [Fact]
        public void Ensure_order_can_only_be_partially_refunded_offline_when_paymentstatus_is_paid_or_partiallyRefunded()
        {
            var order = new Order
            {
                OrderTotal = 100
            };

            foreach (OrderStatus os in Enum.GetValues(typeof(OrderStatus)))
                foreach (PaymentStatus ps in Enum.GetValues(typeof(PaymentStatus)))
                    foreach (ShippingStatus ss in Enum.GetValues(typeof(ShippingStatus)))
                    {
                        order.OrderStatus = os;
                        order.PaymentStatus = ps;
                        order.ShippingStatus = ss;

                        {
                            order.OrderStatus = os;
                            order.PaymentStatus = ps;
                            order.ShippingStatus = ss;

                            if (ps == PaymentStatus.Paid || order.PaymentStatus == PaymentStatus.PartiallyRefunded)
                                _orderProcessingService.CanPartiallyRefundOffline(order, 10).ShouldBeTrue();
                            else
                                _orderProcessingService.CanPartiallyRefundOffline(order, 10).ShouldBeFalse();
                        }
                    }
        }

        [Fact]
        public void Ensure_order_cannot_be_partially_refunded_offline_when_amountToRefund_is_greater_than_amount_that_can_be_refunded()
        {
            var order = new Order
            {
                OrderTotal = 100,
                RefundedAmount = 30, //100-30=70 can be refunded
            };

            foreach (OrderStatus os in Enum.GetValues(typeof(OrderStatus)))
                foreach (PaymentStatus ps in Enum.GetValues(typeof(PaymentStatus)))
                    foreach (ShippingStatus ss in Enum.GetValues(typeof(ShippingStatus)))
                    {
                        order.OrderStatus = os;
                        order.PaymentStatus = ps;
                        order.ShippingStatus = ss;

                        _orderProcessingService.CanPartiallyRefundOffline(order, 80).ShouldBeFalse();
                    }
        }
        
        //TODO write unit tests for the following methods:
        //PlaceOrder
        //CanCancelRecurringPayment, ProcessNextRecurringPayment, CancelRecurringPayment
    }
}
