using FluentValidation.TestHelper;
using RufaPoint.Web.Infrastructure.Installation;
using RufaPoint.Web.Models.Install;
using RufaPoint.Web.Validators.Install;
using Xunit;
using Moq;

namespace RufaPoint.Web.MVC.Tests.Public.Validators.Install
{
    public class InstallValidatorTests : BaseValidatorTests
    {
        protected Mock<IInstallationLocalizationService> _ilService;
        private InstallValidator _validator;
        public InstallValidatorTests()
        {
            //set up localziation service used by almost all validators
            _ilService = new Mock<IInstallationLocalizationService>();
            _ilService.Setup(l => l.GetResource("")).Returns("Invalid");//.IgnoreArguments();

            _validator = new InstallValidator(_ilService.Object);
        }
        
        [Fact]
        public void Should_have_error_when_adminEmail_is_null_or_empty()
        {
            var model = new InstallModel
            {
                AdminEmail = null
            };
            _validator.ShouldHaveValidationErrorFor(x => x.AdminEmail, model);
            model.AdminEmail = "";
            _validator.ShouldHaveValidationErrorFor(x => x.AdminEmail, model);
        }

        [Fact]
        public void Should_have_error_when_adminEmail_is_wrong_format()
        {
            var model = new InstallModel
            {
                AdminEmail = "adminexample.com"
            };
            _validator.ShouldHaveValidationErrorFor(x => x.AdminEmail, model);
        }

        [Fact]
        public void Should_not_have_error_when_adminEmail_is_correct_format()
        {
            var model = new InstallModel
            {
                AdminEmail = "admin@example.com"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.AdminEmail, model);
        }

        [Fact]
        public void Should_have_error_when_password_is_null_or_empty()
        {
            var model = new InstallModel
            {
                AdminPassword = null
            };
            //we know that password should equal confirmation password
            model.ConfirmPassword = model.AdminPassword;
            _validator.ShouldHaveValidationErrorFor(x => x.AdminPassword, model);
            model.AdminPassword = "";
            //we know that password should equal confirmation password
            model.ConfirmPassword = model.AdminPassword;
            _validator.ShouldHaveValidationErrorFor(x => x.AdminPassword, model);
        }

        [Fact]
        public void Should_not_have_error_when_password_is_specified()
        {
            var model = new InstallModel
            {
                AdminPassword = "password"
            };
            //we know that password should equal confirmation password
            model.ConfirmPassword = model.AdminPassword;
            _validator.ShouldNotHaveValidationErrorFor(x => x.AdminPassword, model);
        }

        [Fact]
        public void Should_have_error_when_confirmPassword_is_null_or_empty()
        {
            var model = new InstallModel
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
            var model = new InstallModel
            {
                ConfirmPassword = "some password"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.ConfirmPassword, model);
        }

        [Fact]
        public void Should_have_error_when_password_doesnot_equal_confirmationPassword()
        {
            var model = new InstallModel
            {
                AdminPassword = "some password",
                ConfirmPassword = "another password"
            };
            _validator.ShouldHaveValidationErrorFor(x => x.AdminPassword, model);
        }

        [Fact]
        public void Should_not_have_error_when_password_equals_confirmationPassword()
        {
            var model = new InstallModel
            {
                AdminPassword = "some password",
                ConfirmPassword = "some password"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.AdminPassword, model);
        }
    }
}
