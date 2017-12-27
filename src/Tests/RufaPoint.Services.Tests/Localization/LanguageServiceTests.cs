using System.Collections.Generic;
using System.Linq;
using RufaPoint.Core.Caching;
using RufaPoint.Core.Data;
using RufaPoint.Core.Domain.Localization;
using RufaPoint.Services.Configuration;
using RufaPoint.Services.Events;
using RufaPoint.Services.Localization;
using RufaPoint.Services.Stores;
using RufaPoint.Tests;
using Xunit;
using Moq;

namespace RufaPoint.Services.Tests.Localization
{

    public class LanguageServiceTests : ServiceTest
    {
        private Mock<IRepository<Language>> _languageRepo;
        private Mock<IStoreMappingService> _storeMappingService;
        private ILanguageService _languageService;
        private Mock<ISettingService> _settingService;
        private Mock<IEventPublisher> _eventPublisher;
        private LocalizationSettings _localizationSettings;


        public LanguageServiceTests()
        {
            _languageRepo = new Mock<IRepository<Language>>();
            var lang1 = new Language
            {
                Name = "English",
                LanguageCulture = "en-Us",
                FlagImageFileName = "us.png",
                Published = true,
                DisplayOrder = 1
            };
            var lang2 = new Language
            {
                Name = "Russian",
                LanguageCulture = "ru-Ru",
                FlagImageFileName = "ru.png",
                Published = true,
                DisplayOrder = 2
            };

            _languageRepo.Setup(x => x.Table).Returns(new List<Language> { lang1, lang2 }.AsQueryable());

            _storeMappingService = new Mock<IStoreMappingService>();

            var cacheManager = new NopNullCache();

            _settingService = new Mock<ISettingService>();

            _eventPublisher = new Mock<IEventPublisher>();
            _eventPublisher.Setup(x => x.Publish(It.IsAny<object>()));

            _localizationSettings = new LocalizationSettings();
            _languageService = new LanguageService(cacheManager, _languageRepo.Object, _storeMappingService.Object,
                _settingService.Object, _localizationSettings, _eventPublisher.Object);
        }

        [Fact]
        public void Can_get_all_languages()
        {
            var languages = _languageService.GetAllLanguages();
            languages.ShouldNotBeNull();
            (languages.Any()).ShouldBeTrue();
        }
    }
}
