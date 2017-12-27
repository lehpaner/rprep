using FluentValidation.TestHelper;
using RufaPoint.Web.Models.Customer;
using RufaPoint.Web.Validators.Customer;
using Xunit;

namespace RufaPoint.Web.MVC.Tests.Public.Validators.Customer
{
    public class PasswordRecoveryValidatorTests : BaseValidatorTests
    {
        private PasswordRecoveryValidator _validator;
    
        public PasswordRecoveryValidatorTests()
        {
            _validator = new PasswordRecoveryValidator(_localizationService.Object);
        }
        
        [Fact]
        public void Should_have_error_when_email_is_null_or_empty()
        {
            var model = new PasswordRecoveryModel
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
            var model = new PasswordRecoveryModel
            {
                Email = "adminexample.com"
            };
            _validator.ShouldHaveValidationErrorFor(x => x.Email, model);
        }

        [Fact]
        public void Should_not_have_error_when_email_is_correct_format()
        {
            var model = new PasswordRecoveryModel
            {
                Email = "admin@example.com"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Email, model);
        }
    }
}
