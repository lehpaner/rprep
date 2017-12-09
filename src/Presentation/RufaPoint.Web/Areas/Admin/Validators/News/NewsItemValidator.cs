using FluentValidation;
using RufaPoint.Web.Areas.Admin.Models.News;
using RufaPoint.Core.Domain.News;
using RufaPoint.Data;
using RufaPoint.Services.Localization;
using RufaPoint.Web.Framework.Validators;

namespace RufaPoint.Web.Areas.Admin.Validators.News
{
    public partial class NewsItemValidator : BaseNopValidator<NewsItemModel>
    {
        public NewsItemValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.News.NewsItems.Fields.Title.Required"));

            RuleFor(x => x.Short).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.News.NewsItems.Fields.Short.Required"));

            RuleFor(x => x.Full).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.News.NewsItems.Fields.Full.Required"));

            SetDatabaseValidationRules<NewsItem>(dbContext);
        }
    }
}