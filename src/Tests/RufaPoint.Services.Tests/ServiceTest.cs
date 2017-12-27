using System.Collections.Generic;
using RufaPoint.Core.Plugins;
using RufaPoint.Services.Tests.Directory;
using RufaPoint.Services.Tests.Discounts;
using RufaPoint.Services.Tests.Payments;
using RufaPoint.Services.Tests.Shipping;
using RufaPoint.Services.Tests.Tax;
using Xunit;

namespace RufaPoint.Services.Tests
{

    public abstract class ServiceTest
    {
        public ServiceTest()
        {
            InitPlugins();
        }

        private void InitPlugins()
        {
            PluginManager.ReferencedPlugins = new List<PluginDescriptor>
            {
                new PluginDescriptor(typeof(FixedRateTestTaxProvider).Assembly)
                {
                    PluginType = typeof(FixedRateTestTaxProvider),
                    SystemName = "FixedTaxRateTest",
                    FriendlyName = "Fixed tax test rate provider",
                    Installed = true,
                },
                new PluginDescriptor(typeof(FixedRateTestShippingRateComputationMethod).Assembly)
                {
                    PluginType = typeof(FixedRateTestShippingRateComputationMethod),
                    SystemName = "FixedRateTestShippingRateComputationMethod",
                    FriendlyName = "Fixed rate test shipping computation method",
                    Installed = true,
                },
                new PluginDescriptor(typeof(TestPaymentMethod).Assembly)
                {
                    PluginType = typeof(TestPaymentMethod),
                    SystemName = "Payments.TestMethod",
                    FriendlyName = "Test payment method",
                    Installed = true,
                },
                new PluginDescriptor(typeof(TestDiscountRequirementRule).Assembly)
                {
                    PluginType = typeof(TestDiscountRequirementRule),
                    SystemName = "TestDiscountRequirementRule",
                    FriendlyName = "Test discount requirement rule",
                    Installed = true,
                },
                new PluginDescriptor(typeof(TestExchangeRateProvider).Assembly)
                {
                    PluginType = typeof(TestExchangeRateProvider),
                    SystemName = "CurrencyExchange.TestProvider",
                    FriendlyName = "Test exchange rate provider",
                    Installed = true,
                }
            };
        }
    }
}
