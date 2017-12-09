using FluentValidation;
using RufaPoint.Web.Areas.Admin.Models.Messages;
using RufaPoint.Services.Localization;
using RufaPoint.Web.Framework.Validators;

namespace RufaPoint.Web.Areas.Admin.Validators.Messages
{
    public partial class TestMessageTemplateValidator : BaseNopValidator<TestMessageTemplateModel>
    {
        public TestMessageTemplateValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.SendTo).NotEmpty();
            RuleFor(x => x.SendTo).EmailAddress().WithMessage(localizationService.GetResource("Admin.Common.WrongEmail"));
        }
    }
}