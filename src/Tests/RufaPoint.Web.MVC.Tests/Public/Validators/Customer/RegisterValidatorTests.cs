using FluentValidation.TestHelper;
using RufaPoint.Core.Domain.Customers;
using RufaPoint.Services.Directory;
using RufaPoint.Web.Models.Customer;
using RufaPoint.Web.Validators.Customer;
using Xunit;
using Moq;

namespace RufaPoint.Web.MVC.Tests.Public.Validators.Customer
{
    public class RegisterValidatorTests : BaseValidatorTests
    {
        private RegisterValidator _validator;
        private Mock<IStateProvinceService> _stateProvinceService;
        private CustomerSettings _customerSettings;
        
        public RegisterValidatorTests()
        {
            _customerSettings = new CustomerSettings();
            _stateProvinceService = new Mock<IStateProvinceService>();
            _validator = new RegisterValidator(_localizationService.Object, _stateProvinceService.Object, _customerSettings);
        }
        
        [Fact]
        public void Should_have_error_when_email_is_null_or_empty()
        {
            var model = new RegisterModel
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
            var model = new RegisterModel
            {
                Email = "adminexample.com"
            };
            _validator.ShouldHaveValidationErrorFor(x => x.Email, model);
        }

        [Fact]
        public void Should_not_have_error_when_email_is_correct_format()
        {
            var model = new RegisterModel
            {
                Email = "admin@example.com"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Email, model);
        }

        [Fact]
        public void Should_have_error_when_firstName_is_null_or_empty()
        {
            var model = new RegisterModel
            {
                FirstName = null
            };
            _validator.ShouldHaveValidationErrorFor(x => x.FirstName, model);
            model.FirstName = "";
            _validator.ShouldHaveValidationErrorFor(x => x.FirstName, model);
        }

        [Fact]
        public void Should_not_have_error_when_firstName_is_specified()
        {
            var model = new RegisterModel
            {
                FirstName = "John"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.FirstName, model);
        }

        [Fact]
        public void Should_have_error_when_lastName_is_null_or_empty()
        {
            var model = new RegisterModel
            {
                LastName = null
            };
            _validator.ShouldHaveValidationErrorFor(x => x.LastName, model);
            model.LastName = "";
            _validator.ShouldHaveValidationErrorFor(x => x.LastName, model);
        }

        [Fact]
        public void Should_not_have_error_when_lastName_is_specified()
        {
            var model = new RegisterModel
            {
                LastName = "Smith"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.LastName, model);
        }

        [Fact]
        public void Should_have_error_when_password_is_null_or_empty()
        {
            var model = new RegisterModel
            {
                Password = null
            };
            //we know that password should equal confirmation password
            model.ConfirmPassword = model.Password;
            _validator.ShouldHaveValidationErrorFor(x => x.Password, model);
            model.Password = "";
            //we know that password should equal confirmation password
            model.ConfirmPassword = model.Password;
            _validator.ShouldHaveValidationErrorFor(x => x.Password, model);
        }

        [Fact]
        public void Should_not_have_error_when_password_is_specified()
        {
            var model = new RegisterModel
            {
                Password = "password"
            };
            //we know that password should equal confirmation password
            model.ConfirmPassword = model.Password;
            _validator.ShouldNotHaveValidationErrorFor(x => x.Password, model);
        }

        [Fact]
        public void Should_have_error_when_confirmPassword_is_null_or_empty()
        {
            var model = new RegisterModel
            {
                ConfirmPassword = null
            };
            _validator.ShouldHaveValidationErrorFor(x => x.ConfirmPassword, model);
            model.ConfirmPassword = "";
            _validator.ShouldHaveValidationErrorFor(x => x.ConfirmPassword, model);
        }

        [Fact]
        public void Should_not_have_error_when_confirmPassword_is_specified()
        {
            var model = new RegisterModel
            {
                ConfirmPassword = "some password"
            };
            //we know that new password should equal confirmation password
            model.Password = model.ConfirmPassword;
            _validator.ShouldNotHaveValidationErrorFor(x => x.ConfirmPassword, model);
        }

        [Fact]
        public void Should_have_error_when_password_doesnot_equal_confirmationPassword()
        {
            var model = new RegisterModel
            {
                Password = "some password",
                ConfirmPassword = "another password"
            };
            _validator.ShouldHaveValidationErrorFor(x => x.ConfirmPassword, model);
        }

        [Fact]
        public void Should_not_have_error_when_password_equals_confirmationPassword()
        {
            var model = new RegisterModel
            {
                Password = "some password",
                ConfirmPassword = "some password"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Password, model);
        }

        [Fact]
        public void Should_validate_password_is_length()
        {
            _customerSettings.PasswordMinLength = 5;
            _validator = new RegisterValidator(_localizationService.Object, _stateProvinceService.Object, _customerSettings);

            var model = new RegisterModel
            {
                Password = "1234"
            };
            //we know that password should equal confirmation password
            model.ConfirmPassword = model.Password;
            _validator.ShouldHaveValidationErrorFor(x => x.Password, model);
            model.Password = "12345";
            //we know that password should equal confirmation password
            model.ConfirmPassword = model.Password;
            _validator.ShouldNotHaveValidationErrorFor(x => x.Password, model);
        }
    }
}
