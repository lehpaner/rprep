﻿using FluentValidation;
using RufaPoint.Web.Areas.Admin.Models.Templates;
using RufaPoint.Services.Localization;
using RufaPoint.Web.Framework.Validators;

namespace RufaPoint.Web.Areas.Admin.Validators.Templates
{
    public partial class CategoryTemplateValidator : BaseNopValidator<CategoryTemplateModel>
    {
        public CategoryTemplateValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Category.Name.Required"));
            RuleFor(x => x.ViewPath).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Category.ViewPath.Required"));
        }
    }
}