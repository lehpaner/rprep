using FluentValidation;
using RufaPoint.Services.Localization;
using RufaPoint.Web.Framework.Validators;
using RufaPoint.Web.Models.Boards;

namespace RufaPoint.Web.Validators.Boards
{
    public partial class EditForumPostValidator : BaseNopValidator<EditForumPostModel>
    {
        public EditForumPostValidator(ILocalizationService localizationService)
        {            
            RuleFor(x => x.Text).NotEmpty().WithMessage(localizationService.GetResource("Forum.TextCannotBeEmpty"));
        }
    }
}