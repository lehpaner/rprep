using FluentValidation.TestHelper;
using RufaPoint.Web.Areas.Admin.Models.Vendors;
using RufaPoint.Web.Areas.Admin.Validators.Vendors;
using RufaPoint.Web.MVC.Tests.Public.Validators;
using Xunit;

namespace RufaPoint.Web.MVC.Tests.Admin.Validators.Vendors
{

    public class VendorValidatorTests : BaseValidatorTests
    {
        private VendorValidator _validator;

        public VendorValidatorTests()
        {
            _validator = new VendorValidator(_localizationService.Object, null);
        }

        [Fact]
        public void Should_have_error_when_pageSizeOptions_has_duplicate_items()
        {
            var model = new VendorModel
            {
                PageSizeOptions = "1, 2, 3, 5, 2"
            };
            _validator.ShouldHaveValidationErrorFor(x => x.PageSizeOptions, model);
        }

        [Fact]
        public void Should_not_have_error_when_pageSizeOptions_has_not_duplicate_items()
        {
            var model = new VendorModel
            {
                PageSizeOptions = "1, 2, 3, 5, 9"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.PageSizeOptions, model);
        }

        [Fact]
        public void Should_not_have_error_when_pageSizeOptions_is_null_or_empty()
        {
            var model = new VendorModel
            {
                PageSizeOptions = null
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.PageSizeOptions, model);
            model.PageSizeOptions = "";
            _validator.ShouldNotHaveValidationErrorFor(x => x.PageSizeOptions, model);
        }
    }
}