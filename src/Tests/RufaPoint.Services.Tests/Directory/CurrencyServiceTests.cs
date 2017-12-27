﻿using System;
using System.Collections.Generic;
using System.Linq;
using RufaPoint.Core.Caching;
using RufaPoint.Core.Data;
using RufaPoint.Core.Domain.Directory;
using RufaPoint.Core.Plugins;
using RufaPoint.Services.Directory;
using RufaPoint.Services.Events;
using RufaPoint.Services.Stores;
using RufaPoint.Tests;
using Xunit;
using Moq;

namespace RufaPoint.Services.Tests.Directory
{

    public class CurrencyServiceTests : ServiceTest
    {
        private Mock<IRepository<Currency>> _currencyRepository;
        private Mock<IStoreMappingService> _storeMappingService;
        private CurrencySettings _currencySettings;
        private Mock<IEventPublisher> _eventPublisher;
        private ICurrencyService _currencyService;

        private Currency currencyUSD, currencyRUR, currencyEUR;
        
        public CurrencyServiceTests()
        {
            currencyUSD = new Currency
            {
                Id = 1,
                Name = "US Dollar",
                CurrencyCode = "USD",
                Rate = 1.2M,
                DisplayLocale = "en-US",
                CustomFormatting = "",
                Published = true,
                DisplayOrder = 1,
                CreatedOnUtc = DateTime.UtcNow,
                UpdatedOnUtc = DateTime.UtcNow,
                RoundingType = RoundingType.Rounding001
            };
            currencyEUR = new Currency
            {
                Id = 2,
                Name = "Euro",
                CurrencyCode = "EUR",
                Rate = 1,
                DisplayLocale = "",
                CustomFormatting = "€0.00",
                Published = true,
                DisplayOrder = 2,
                CreatedOnUtc = DateTime.UtcNow,
                UpdatedOnUtc = DateTime.UtcNow,
                RoundingType = RoundingType.Rounding001
            };
            currencyRUR = new Currency
            {
                Id = 3,
                Name = "Russian Rouble",
                CurrencyCode = "RUB",
                Rate = 34.5M,
                DisplayLocale = "ru-RU",
                CustomFormatting = "",
                Published = true,
                DisplayOrder = 3,
                CreatedOnUtc = DateTime.UtcNow,
                UpdatedOnUtc = DateTime.UtcNow,
                RoundingType = RoundingType.Rounding001
            };
            _currencyRepository = new Mock<IRepository<Currency>>();
            _currencyRepository.Setup(x => x.Table).Returns(new List<Currency> { currencyUSD, currencyEUR, currencyRUR }.AsQueryable());
            _currencyRepository.Setup(x => x.GetById(currencyUSD.Id)).Returns(currencyUSD);
            _currencyRepository.Setup(x => x.GetById(currencyEUR.Id)).Returns(currencyEUR);
            _currencyRepository.Setup(x => x.GetById(currencyRUR.Id)).Returns(currencyRUR);

            _storeMappingService = new Mock<IStoreMappingService>();

            var cacheManager = new DummyCacheManager();

            _currencySettings = new CurrencySettings
            {
                PrimaryStoreCurrencyId = currencyUSD.Id,
                PrimaryExchangeRateCurrencyId = currencyEUR.Id
            };

            _eventPublisher = new Mock<IEventPublisher>();
            _eventPublisher.Setup(x => x.Publish(It.IsAny<object>()));


            var pluginFinder = new PluginFinder();
            _currencyService = new CurrencyService(cacheManager,
                _currencyRepository.Object, _storeMappingService.Object, 
                _currencySettings, pluginFinder, _eventPublisher.Object);
        }
        
        [Fact]
        public void Can_load_exchangeRateProviders()
        {
            var providers = _currencyService.LoadAllExchangeRateProviders();
            providers.ShouldNotBeNull();
            (providers.Any()).ShouldBeTrue();
        }

        [Fact]
        public void Can_load_exchangeRateProvider_by_systemKeyword()
        {
            var provider = _currencyService.LoadExchangeRateProviderBySystemName("CurrencyExchange.TestProvider");
            provider.ShouldNotBeNull();
        }

        [Fact]
        public void Can_load_active_exchangeRateProvider()
        {
            var provider = _currencyService.LoadActiveExchangeRateProvider();
            provider.ShouldNotBeNull();
        }

        [Fact]
        public void Can_convert_currency_1()
        {
            _currencyService.ConvertCurrency(10.1M, 1.5M).ShouldEqual(15.15M);
            _currencyService.ConvertCurrency(10.1M, 1).ShouldEqual(10.1M);
            _currencyService.ConvertCurrency(10.1M, 0).ShouldEqual(0);
            _currencyService.ConvertCurrency(0, 5).ShouldEqual(0);
        }

        [Fact]
        public void Can_convert_currency_2()
        {
            _currencyService.ConvertCurrency(10M, currencyEUR, currencyRUR).ShouldEqual(345M);
            _currencyService.ConvertCurrency(10.1M, currencyEUR, currencyEUR).ShouldEqual(10.1M);
            _currencyService.ConvertCurrency(10.1M, currencyRUR, currencyRUR).ShouldEqual(10.1M);
            _currencyService.ConvertCurrency(12M, currencyUSD, currencyRUR).ShouldEqual(345M);
            _currencyService.ConvertCurrency(345M, currencyRUR, currencyUSD).ShouldEqual(12M);
        }
    }
}
