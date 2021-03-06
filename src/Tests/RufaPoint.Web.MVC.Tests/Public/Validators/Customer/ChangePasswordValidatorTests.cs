﻿using FluentValidation.TestHelper;
using RufaPoint.Core.Domain.Customers;
using RufaPoint.Web.Models.Customer;
using RufaPoint.Web.Validators.Customer;
using Xunit;

namespace RufaPoint.Web.MVC.Tests.Public.Validators.Customer
{

    public class ChangePasswordValidatorTests : BaseValidatorTests
    {
        private ChangePasswordValidator _validator;
        private CustomerSettings _customerSettings;
        

        public ChangePasswordValidatorTests()
        {
            _customerSettings = new CustomerSettings();
            _validator = new ChangePasswordValidator(_localizationService.Object, _customerSettings);
        }
        
        [Fact]
        public void Should_have_error_when_oldPassword_is_null_or_empty()
        {
            var model = new ChangePasswordModel
            {
                OldPassword = null
            };
            _validator.ShouldHaveValidationErrorFor(x => x.OldPassword, model);
            model.OldPassword = "";
            _validator.ShouldHaveValidationErrorFor(x => x.OldPassword, model);
        }

        [Fact]
        public void Should_not_have_error_when_oldPassword_is_specified()
        {
            var model = new ChangePasswordModel
            {
                OldPassword = "old password"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.OldPassword, model);
        }

        [Fact]
        public void Should_have_error_when_newPassword_is_null_or_empty()
        {
            var model = new ChangePasswordModel
            {
                NewPassword = null
            };
            //we know that new password should equal confirmation password
            model.ConfirmNewPassword = model.NewPassword;
            _validator.ShouldHaveValidationErrorFor(x => x.NewPassword, model);
            model.NewPassword = "";
            //we know that new password should equal confirmation password
            model.ConfirmNewPassword = model.NewPassword;
            _validator.ShouldHaveValidationErrorFor(x => x.NewPassword, model);
        }

        [Fact]
        public void Should_not_have_error_when_newPassword_is_specified()
        {
            var model = new ChangePasswordModel
            {
                NewPassword = "new password"
            };
            //we know that new password should equal confirmation password
            model.ConfirmNewPassword = model.NewPassword;
            _validator.ShouldNotHaveValidationErrorFor(x => x.NewPassword, model);
        }

        [Fact]
        public void Should_have_error_when_confirmNewPassword_is_null_or_empty()
        {
            var model = new ChangePasswordModel
            {
                ConfirmNewPassword = null
            };
            _validator.ShouldHaveValidationErrorFor(x => x.ConfirmNewPassword, model);
            model.ConfirmNewPassword = "";
            _validator.ShouldHaveValidationErrorFor(x => x.ConfirmNewPassword, model);
        }

        [Fact]
        public void Should_not_have_error_when_confirmNewPassword_is_specified()
        {
            var model = new ChangePasswordModel
            {
                ConfirmNewPassword = "some password"
            };
            //we know that new password should equal confirmation password
            model.NewPassword = model.ConfirmNewPassword;
            _validator.ShouldNotHaveValidationErrorFor(x => x.ConfirmNewPassword, model);
        }

        [Fact]
        public void Should_have_error_when_newPassword_doesnot_equal_confirmationPassword()
        {
            var model = new ChangePasswordModel
            {
                NewPassword = "some password",
                ConfirmNewPassword = "another password"
            };
            _validator.ShouldHaveValidationErrorFor(x => x.ConfirmNewPassword, model);
        }

        [Fact]
        public void Should_not_have_error_when_newPassword_equals_confirmationPassword()
        {
            var model = new ChangePasswordModel
            {
                NewPassword = "some password",
                ConfirmNewPassword = "some password"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.NewPassword, model);
        }

        [Fact]
        public void Should_validate_newPassword_is_length()
        {
            _customerSettings.PasswordMinLength = 5;
            _validator = new ChangePasswordValidator(_localizationService.Object, _customerSettings);

            var model = new ChangePasswordModel
            {
                NewPassword = "1234"
            };
            //we know that new password should equal confirmation password
            model.ConfirmNewPassword = model.NewPassword;
            _validator.ShouldHaveValidationErrorFor(x => x.NewPassword, model);
            model.NewPassword = "12345";
            //we know that new password should equal confirmation password
            model.ConfirmNewPassword = model.NewPassword;
            _validator.ShouldNotHaveValidationErrorFor(x => x.NewPassword, model);
        }
    }
}
