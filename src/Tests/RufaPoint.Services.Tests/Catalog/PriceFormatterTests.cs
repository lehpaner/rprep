﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RufaPoint.Core;
using RufaPoint.Core.Caching;
using RufaPoint.Core.Data;
using RufaPoint.Core.Domain.Directory;
using RufaPoint.Core.Domain.Localization;
using RufaPoint.Core.Domain.Tax;
using RufaPoint.Core.Infrastructure;
using RufaPoint.Core.Plugins;
using RufaPoint.Services.Catalog;
using RufaPoint.Services.Directory;
using RufaPoint.Services.Localization;
using RufaPoint.Services.Stores;
using RufaPoint.Tests;
using Xunit;
using Moq;

namespace RufaPoint.Services.Tests.Catalog
{
    public class PriceFormatterTests : ServiceTest
    {
        private Mock<IRepository<Currency>> _currencyRepo;
        private Mock<IStoreMappingService> _storeMappingService;
        private ICurrencyService _currencyService;
        private CurrencySettings _currencySettings;
        private Mock<IWorkContext> _workContext;
        private Mock<ILocalizationService> _localizationService;
        private TaxSettings _taxSettings;
        private IPriceFormatter _priceFormatter;
        

        public PriceFormatterTests()
        {
            var cacheManager = new DummyCacheManager();

            _workContext = new Mock<IWorkContext>();
            _workContext.Setup(w => w.WorkingCurrency).Returns(new Currency { RoundingType = RoundingType.Rounding001 });

            _currencySettings = new CurrencySettings();
            var currency1 = new Currency
            {
                Id = 1,
                Name = "Euro",
                CurrencyCode = "EUR",
                DisplayLocale =  "",
                CustomFormatting = "€0.00",
                DisplayOrder = 1,
                Published = true,
                CreatedOnUtc = DateTime.UtcNow,
                UpdatedOnUtc= DateTime.UtcNow
            };
            var currency2 = new Currency
            {
                Id = 1,
                Name = "US Dollar",
                CurrencyCode = "USD",
                DisplayLocale = "en-US",
                CustomFormatting = "",
                DisplayOrder = 2,
                Published = true,
                CreatedOnUtc = DateTime.UtcNow,
                UpdatedOnUtc= DateTime.UtcNow
            };            
            _currencyRepo = new Mock<IRepository<Currency>>();
            _currencyRepo.Setup(x => x.Table).Returns(new List<Currency> { currency1, currency2 }.AsQueryable());

            _storeMappingService = new Mock<IStoreMappingService>();

            var pluginFinder = new PluginFinder();
            _currencyService = new CurrencyService(cacheManager, _currencyRepo.Object, _storeMappingService.Object,
                _currencySettings, pluginFinder, null);

            _taxSettings = new TaxSettings();

            _localizationService = new Mock<ILocalizationService>();
            _localizationService.Setup(x => x.GetResource("Products.InclTaxSuffix", 1, false, "Default value", true)).Returns("{0} incl tax");
            _localizationService.Setup(x => x.GetResource("Products.ExclTaxSuffix", 1, false, "Default value", true)).Returns("{0} excl tax");
            
            _priceFormatter = new PriceFormatter(_workContext.Object, _currencyService,_localizationService.Object, 
                _taxSettings, _currencySettings);

            var nopEngine = new Mock<CoreAppEngine>();
            var serviceProvider = new Mock<IServiceProvider>();
            var httpContextAccessor =new Mock<IHttpContextAccessor>();
            serviceProvider.Setup(x => x.GetRequiredService(typeof(IHttpContextAccessor))).Returns(httpContextAccessor);
            serviceProvider.Setup(x => x.GetRequiredService(typeof(IWorkContext))).Returns(_workContext);
            nopEngine.Setup(x => x.ServiceProvider).Returns(serviceProvider.Object);
            EngineContext.Replace(nopEngine.Object);
        }

      
        public void TearDown()
        {
            EngineContext.Replace(null);
        }

        [Fact]
        public void Can_formatPrice_with_custom_currencyFormatting()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            var currency = new Currency
            {
                Id = 1,
                Name = "Euro",
                CurrencyCode = "EUR",
                DisplayLocale =  "",
                CustomFormatting = "€0.00"
            };
            var language = new Language
            {
                Id = 1,
                Name = "English",
                LanguageCulture = "en-US"
            };
            _priceFormatter.FormatPrice(1234.5M, false, currency, language, false, false).ShouldEqual("€1234.50");
        }

        [Fact]
        public void Can_formatPrice_with_distinct_currencyDisplayLocale()
        {
            var usd_currency = new Currency
            {
                Id = 1,
                Name = "US Dollar",
                CurrencyCode = "USD",
                DisplayLocale = "en-US",
            };
            var gbp_currency = new Currency
            {
                Id = 2,
                Name = "great british pound",
                CurrencyCode = "GBP",
                DisplayLocale = "en-GB",
            };
            var language = new Language
            {
                Id = 1,
                Name = "English",
                LanguageCulture = "en-US"
            };
            _priceFormatter.FormatPrice(1234.5M, false, usd_currency, language, false, false).ShouldEqual("$1,234.50");
            _priceFormatter.FormatPrice(1234.5M, false, gbp_currency, language, false, false).ShouldEqual("£1,234.50");
        }

        [Fact]
        public void Can_formatPrice_with_showTax()
        {
            var currency = new Currency
            {
                Id = 1,
                Name = "US Dollar",
                CurrencyCode = "USD",
                DisplayLocale = "en-US",
            };
            var language = new Language
            {
                Id = 1,
                Name = "English",
                LanguageCulture = "en-US"
            };
            _priceFormatter.FormatPrice(1234.5M, false, currency, language, true, true).ShouldEqual("$1,234.50 incl tax");
            _priceFormatter.FormatPrice(1234.5M, false, currency, language, false, true).ShouldEqual("$1,234.50 excl tax");

        }

        [Fact]
        public void Can_formatPrice_with_showCurrencyCode()
        {
            var currency = new Currency
            {
                Id = 1,
                Name = "US Dollar",
                CurrencyCode = "USD",
                DisplayLocale = "en-US",
            };
            var language = new Language
            {
                Id = 1,
                Name = "English",
                LanguageCulture = "en-US"
            };
            _currencySettings.DisplayCurrencyLabel = true;
            _priceFormatter.FormatPrice(1234.5M, true, currency, language, false, false).ShouldEqual("$1,234.50 (USD)");
            
            _currencySettings.DisplayCurrencyLabel = false;
            _priceFormatter.FormatPrice(1234.5M, true, currency, language, false, false).ShouldEqual("$1,234.50");
        }
    }
}