using FluentValidation.TestHelper;
using RufaPoint.Web.Models.Boards;
using RufaPoint.Web.Validators.Boards;
using Xunit;

namespace RufaPoint.Web.MVC.Tests.Public.Validators.Boards
{
    public class EditForumPostValidatorTests : BaseValidatorTests
    {
        private EditForumPostValidator _validator;
        
        public EditForumPostValidatorTests()
        {
            _validator = new EditForumPostValidator(_localizationService.Object);
        }
        
        [Fact]
        public void Should_have_error_when_text_is_null_or_empty()
        {
            var model = new EditForumPostModel
            {
                Text = null
            };
            _validator.ShouldHaveValidationErrorFor(x => x.Text, model);
            model.Text = "";
            _validator.ShouldHaveValidationErrorFor(x => x.Text, model);
        }

        [Fact]
        public void Should_not_have_error_when_text_is_specified()
        {
            var model = new EditForumPostModel
            {
                Text = "some comment"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Text, model);
        }
    }
}
