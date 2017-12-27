using FluentValidation.TestHelper;
using RufaPoint.Web.Models.Catalog;
using RufaPoint.Web.Validators.Catalog;
using Xunit;

namespace RufaPoint.Web.MVC.Tests.Public.Validators.Catalog
{

    public class ProductEmailAFriendValidatorTests : BaseValidatorTests
    {
        private ProductEmailAFriendValidator _validator;
        
        public ProductEmailAFriendValidatorTests()
        {
            _validator = new ProductEmailAFriendValidator(_localizationService.Object);
        }
        
        [Fact]
        public void Should_have_error_when_friendEmail_is_null_or_empty()
        {
            var model = new ProductEmailAFriendModel
            {
                FriendEmail = null
            };
            _validator.ShouldHaveValidationErrorFor(x => x.FriendEmail, model);
            model.FriendEmail = "";
            _validator.ShouldHaveValidationErrorFor(x => x.FriendEmail, model);
        }

        [Fact]
        public void Should_have_error_when_friendEmail_is_wrong_format()
        {
            var model = new ProductEmailAFriendModel
            {
                FriendEmail = "adminexample.com"
            };
            _validator.ShouldHaveValidationErrorFor(x => x.FriendEmail, model);
        }

        [Fact]
        public void Should_not_have_error_when_friendEmail_is_correct_format()
        {
            var model = new ProductEmailAFriendModel
            {
                FriendEmail = "admin@example.com"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.FriendEmail, model);
        }

        [Fact]
        public void Should_have_error_when_yourEmailAddress_is_null_or_empty()
        {
            var model = new ProductEmailAFriendModel
            {
                YourEmailAddress = null
            };
            _validator.ShouldHaveValidationErrorFor(x => x.YourEmailAddress, model);
            model.YourEmailAddress = "";
            _validator.ShouldHaveValidationErrorFor(x => x.YourEmailAddress, model);
        }

        [Fact]
        public void Should_have_error_when_yourEmailAddress_is_wrong_format()
        {
            var model = new ProductEmailAFriendModel
            {
                YourEmailAddress = "adminexample.com"
            };
            _validator.ShouldHaveValidationErrorFor(x => x.YourEmailAddress, model);
        }

        [Fact]
        public void Should_not_have_error_when_yourEmailAddress_is_correct_format()
        {
            var model = new ProductEmailAFriendModel
            {
                YourEmailAddress = "admin@example.com"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.YourEmailAddress, model);
        }
    }
}
