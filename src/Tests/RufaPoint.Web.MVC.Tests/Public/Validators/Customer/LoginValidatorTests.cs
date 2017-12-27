using FluentValidation.TestHelper;
using RufaPoint.Core.Domain.Customers;
using RufaPoint.Web.Models.Customer;
using RufaPoint.Web.Validators.Customer;
using Xunit;

namespace RufaPoint.Web.MVC.Tests.Public.Validators.Customer
{
    public class LoginValidatorTests : BaseValidatorTests
    {
        private LoginValidator _validator;
        private CustomerSettings _customerSettings;
        
        public LoginValidatorTests()
        {
            _customerSettings = new CustomerSettings();
            _validator = new LoginValidator(_localizationService.Object, _customerSettings);
        }
        
        [Fact]
        public void Should_have_error_when_email_is_null_or_empty()
        {
            var model = new LoginModel
            {
                Email = null
            };
            _validator.ShouldHaveValidationErrorFor(x => x.Email, model);
            model.Email = "";
            _validator.ShouldHaveValidationErrorFor(x => x.Email, model);
        }

        [Fact]
        public void Should_have_error_when_email_is_wrong_format()
        {
            var model = new LoginModel
            {
                Email = "adminexample.com"
            };
            _validator.ShouldHaveValidationErrorFor(x => x.Email, model);
        }

        [Fact]
        public void Should_not_have_error_when_email_is_correct_format()
        {
            var model = new LoginModel
            {
                Email = "admin@example.com"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Email, model);
        }

        [Fact]
        public void Should_not_have_error_when_email_is_null_but_usernames_are_enabled()
        {
            _customerSettings = new CustomerSettings
            {
                UsernamesEnabled = true
            };
            _validator = new LoginValidator(_localizationService.Object, _customerSettings);

            var model = new LoginModel
            {
                Email = null
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Email, model);
        }
    }
}
