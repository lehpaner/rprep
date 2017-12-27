using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RufaPoint.Core.Infrastructure;
using RufaPoint.Services.Localization;
using RufaPoint.Web.Areas.Admin.Validators.Common;
using Xunit;
using Moq;

namespace RufaPoint.Web.MVC.Tests.Public.Validators
{

    public abstract class BaseValidatorTests
    {
        protected Mock<ILocalizationService> _localizationService;
        public BaseValidatorTests()
        {
            var nopEngine = new Mock<CoreAppEngine>();
            var serviceProvider = new Mock<IServiceProvider>();
            var httpContextAccessor = new Mock<IHttpContextAccessor>();
            serviceProvider.Setup(x => x.GetRequiredService(typeof(IHttpContextAccessor))).Returns(httpContextAccessor);
            //set up localziation service used by almost all validators
            _localizationService = new Mock<ILocalizationService>();
            _localizationService.Setup(l => l.GetResource("")).Returns("Invalid");//Pekmez.IgnoreArguments();
            serviceProvider.Setup(x => x.GetRequiredService(typeof(ILocalizationService))).Returns(_localizationService.Object);
            nopEngine.Setup(x => x.ServiceProvider).Returns(serviceProvider.Object);
            nopEngine.Setup(x => x.ResolveUnregistered(typeof(AddressValidator))).Returns(new AddressValidator(_localizationService.Object));
            EngineContext.Replace(nopEngine.Object);
        }
    }
}
