using FluentValidation.TestHelper;
using RufaPoint.Core.Domain.Common;
using RufaPoint.Web.Models.Common;
using RufaPoint.Web.Validators.Common;
using Xunit;

namespace RufaPoint.Web.MVC.Tests.Public.Validators.Common
{

    public class ContactVendorValidatorTests : BaseValidatorTests
    {
        private ContactVendorValidator _validator;
        private CommonSettings _commonSettings;
        
        public ContactVendorValidatorTests()
        {
            _commonSettings = new CommonSettings();
            _validator = new ContactVendorValidator(_localizationService.Object, _commonSettings);
        }
        
        [Fact]
        public void Should_have_error_when_email_is_null_or_empty()
        {
            var model = new ContactVendorModel
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
            var model = new ContactVendorModel
            {
                Email = "adminexample.com"
            };
            _validator.ShouldHaveValidationErrorFor(x => x.Email, model);
        }

        [Fact]
        public void Should_not_have_error_when_email_is_correct_format()
        {
            var model = new ContactVendorModel
            {
                Email = "admin@example.com"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Email, model);
        }

        [Fact]
        public void Should_have_error_when_fullName_is_null_or_empty()
        {
            var model = new ContactVendorModel
            {
                FullName = null
            };
            _validator.ShouldHaveValidationErrorFor(x => x.FullName, model);
            model.FullName = "";
            _validator.ShouldHaveValidationErrorFor(x => x.FullName, model);
        }

        [Fact]
        public void Should_not_have_error_when_fullName_is_specified()
        {
            var model = new ContactVendorModel
            {
                FullName = "John Smith"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.FullName, model);
        }

        [Fact]
        public void Should_have_error_when_enquiry_is_null_or_empty()
        {
            var model = new ContactVendorModel
            {
                Enquiry = null
            };
            _validator.ShouldHaveValidationErrorFor(x => x.Enquiry, model);
            model.Enquiry = "";
            _validator.ShouldHaveValidationErrorFor(x => x.Enquiry, model);
        }

        [Fact]
        public void Should_not_have_error_when_enquiry_is_specified()
        {
            var model = new ContactVendorModel
            {
                Enquiry = "please call me back"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Enquiry, model);
        }
    }
}
