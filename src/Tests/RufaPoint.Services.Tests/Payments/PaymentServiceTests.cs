using System.Collections.Generic;
using System.Linq;
using RufaPoint.Core.Domain.Orders;
using RufaPoint.Core.Domain.Payments;
using RufaPoint.Core.Plugins;
using RufaPoint.Services.Configuration;
using RufaPoint.Services.Payments;
using RufaPoint.Tests;
using Xunit;
using Moq;

namespace RufaPoint.Services.Tests.Payments
{

    public class PaymentServiceTests : ServiceTest
    {
        private PaymentSettings _paymentSettings;
        private ShoppingCartSettings _shoppingCartSettings;
        private Mock<ISettingService> _settingService;
        private IPaymentService _paymentService;
        

        public PaymentServiceTests()
        {
            _paymentSettings = new PaymentSettings
            {
                ActivePaymentMethodSystemNames = new List<string>()
            };
            _paymentSettings.ActivePaymentMethodSystemNames.Add("Payments.TestMethod");

            var pluginFinder = new PluginFinder();

            _shoppingCartSettings = new ShoppingCartSettings();
            _settingService = new Mock<ISettingService>();

            _paymentService = new PaymentService(_paymentSettings, pluginFinder, _settingService.Object, _shoppingCartSettings);
        }

        [Fact]
        public void Can_load_paymentMethods()
        {
            var srcm = _paymentService.LoadAllPaymentMethods();
            srcm.ShouldNotBeNull();
            (srcm.Any()).ShouldBeTrue();
        }

        [Fact]
        public void Can_load_paymentMethod_by_systemKeyword()
        {
            var srcm = _paymentService.LoadPaymentMethodBySystemName("Payments.TestMethod");
            srcm.ShouldNotBeNull();
        }

        [Fact]
        public void Can_load_active_paymentMethods()
        {
            var srcm = _paymentService.LoadActivePaymentMethods();
            srcm.ShouldNotBeNull();
            (srcm.Any()).ShouldBeTrue();
        }

        [Fact]
        public void Can_get_masked_credit_card_number()
        {
            _paymentService.GetMaskedCreditCardNumber("").ShouldEqual("");
            _paymentService.GetMaskedCreditCardNumber("123").ShouldEqual("123");
            _paymentService.GetMaskedCreditCardNumber("1234567890123456").ShouldEqual("************3456");
        }
    }
}
