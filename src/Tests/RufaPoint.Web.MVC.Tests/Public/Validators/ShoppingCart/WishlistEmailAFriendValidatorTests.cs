using FluentValidation.TestHelper;
using RufaPoint.Web.Models.ShoppingCart;
using RufaPoint.Web.Validators.ShoppingCart;
using Xunit;

namespace RufaPoint.Web.MVC.Tests.Public.Validators.ShoppingCart
{

    public class WishlistEmailAFriendValidatorTests : BaseValidatorTests
    {
        private WishlistEmailAFriendValidator _validator;
        public WishlistEmailAFriendValidatorTests()
        {
            _validator = new WishlistEmailAFriendValidator(_localizationService.Object);
        }
        
        [Fact]
        public void Should_have_error_when_friendEmail_is_null_or_empty()
        {
            var model = new WishlistEmailAFriendModel
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
            var model = new WishlistEmailAFriendModel
            {
                FriendEmail = "adminexample.com"
            };
            _validator.ShouldHaveValidationErrorFor(x => x.FriendEmail, model);
        }

        [Fact]
        public void Should_not_have_error_when_friendEmail_is_correct_format()
        {
            var model = new WishlistEmailAFriendModel
            {
                FriendEmail = "admin@example.com"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.FriendEmail, model);
        }

        [Fact]
        public void Should_have_error_when_yourEmailAddress_is_null_or_empty()
        {
            var model = new WishlistEmailAFriendModel
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
            var model = new WishlistEmailAFriendModel
            {
                YourEmailAddress = "adminexample.com"
            };
            _validator.ShouldHaveValidationErrorFor(x => x.YourEmailAddress, model);
        }

        [Fact]
        public void Should_not_have_error_when_yourEmailAddress_is_correct_format()
        {
            var model = new WishlistEmailAFriendModel
            {
                YourEmailAddress = "admin@example.com"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.YourEmailAddress, model);
        }
    }
}
