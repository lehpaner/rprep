using FluentValidation;
using RufaPoint.Services.Localization;
using RufaPoint.Web.Framework.Validators;
using RufaPoint.Web.Models.Blogs;

namespace RufaPoint.Web.Validators.Blogs
{
    public partial class BlogPostValidator : BaseNopValidator<BlogPostModel>
    {
        public BlogPostValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.AddNewComment.CommentText).NotEmpty().WithMessage(localizationService.GetResource("Blog.Comments.CommentText.Required")).When(x => x.AddNewComment != null);
        }
    }
}