﻿using FluentValidation.TestHelper;
using RufaPoint.Core.Domain.Common;
using RufaPoint.Services.Directory;
using RufaPoint.Web.Models.Common;
using RufaPoint.Web.Validators.Common;
using Xunit;
using Moq;

namespace RufaPoint.Web.MVC.Tests.Public.Validators.Common
{

    public class AddressValidatorTests : BaseValidatorTests
    {
        private Mock<IStateProvinceService> _stateProvinceService;

        public AddressValidatorTests()
        {
            _stateProvinceService = new Mock<IStateProvinceService>();
        }

        [Fact]
        public void Should_have_error_when_email_is_null_or_empty()
        {
            var validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings());

            var model = new AddressModel
            {
                Email = null
            };
            validator.ShouldHaveValidationErrorFor(x => x.Email, model);
            model.Email = "";
            validator.ShouldHaveValidationErrorFor(x => x.Email, model);
        }
        [Fact]
        public void Should_have_error_when_email_is_wrong_format()
        {
            var validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings());

            var model = new AddressModel
            {
                Email = "adminexample.com"
            };
            validator.ShouldHaveValidationErrorFor(x => x.Email, model);
        }
        [Fact]
        public void Should_not_have_error_when_email_is_correct_format()
        {
            var validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings());

            var model = new AddressModel
            {
                Email = "admin@example.com"
            };
            validator.ShouldNotHaveValidationErrorFor(x => x.Email, model);
        }

        [Fact]
        public void Should_have_error_when_firstName_is_null_or_empty()
        {
            var validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings());

            var model = new AddressModel
            {
                FirstName = null
            };
            validator.ShouldHaveValidationErrorFor(x => x.FirstName, model);
            model.FirstName = "";
            validator.ShouldHaveValidationErrorFor(x => x.FirstName, model);
        }
        [Fact]
        public void Should_not_have_error_when_firstName_is_specified()
        {
            var validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings());

            var model = new AddressModel
            {
                FirstName = "John"
            };
            validator.ShouldNotHaveValidationErrorFor(x => x.FirstName, model);
        }

        [Fact]
        public void Should_have_error_when_lastName_is_null_or_empty()
        {
            var validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings());

            var model = new AddressModel
            {
                LastName = null
            };
            validator.ShouldHaveValidationErrorFor(x => x.LastName, model);
            model.LastName = "";
            validator.ShouldHaveValidationErrorFor(x => x.LastName, model);
        }
        [Fact]
        public void Should_not_have_error_when_lastName_is_specified()
        {
            var validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings());

            var model = new AddressModel
            {
                LastName = "Smith"
            };
            validator.ShouldNotHaveValidationErrorFor(x => x.LastName, model);
        }

        [Fact]
        public void Should_have_error_when_company_is_null_or_empty_based_on_required_setting()
        {
            var model = new AddressModel();

            //required
            var validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings
                {
                    CompanyEnabled = true,
                    CompanyRequired = true
                });
            model.Company = null;
            validator.ShouldHaveValidationErrorFor(x => x.Company, model);
            model.Company = "";
            validator.ShouldHaveValidationErrorFor(x => x.Company, model);


            //not required
            validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings
                {
                    CompanyEnabled = true,
                    CompanyRequired = false
                });
            model.Company = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.Company, model);
            model.Company = "";
            validator.ShouldNotHaveValidationErrorFor(x => x.Company, model);
        }
        [Fact]
        public void Should_not_have_error_when_company_is_specified()
        {
            var validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings
                {
                    CompanyEnabled = true
                });

            var model = new AddressModel
            {
                Company = "Company"
            };
            validator.ShouldNotHaveValidationErrorFor(x => x.Company, model);
        }

        [Fact]
        public void Should_have_error_when_streetaddress_is_null_or_empty_based_on_required_setting()
        {
            var model = new AddressModel();

            //required
            var validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings
                {
                    StreetAddressEnabled = true,
                    StreetAddressRequired = true
                });
            model.Address1 = null;
            validator.ShouldHaveValidationErrorFor(x => x.Address1, model);
            model.Address1 = "";
            validator.ShouldHaveValidationErrorFor(x => x.Address1, model);

            //not required
            validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings
                {
                    StreetAddressEnabled = true,
                    StreetAddressRequired = false
                });
            model.Address1 = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.Address1, model);
            model.Address1 = "";
            validator.ShouldNotHaveValidationErrorFor(x => x.Address1, model);
        }
        [Fact]
        public void Should_not_have_error_when_streetaddress_is_specified()
        {
            var validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings
                {
                    StreetAddressEnabled = true
                });

            var model = new AddressModel
            {
                Address1 = "Street address"
            };
            validator.ShouldNotHaveValidationErrorFor(x => x.Address1, model);
        }

        [Fact]
        public void Should_have_error_when_streetaddress2_is_null_or_empty_based_on_required_setting()
        {
            var model = new AddressModel();

            //required
            var validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings
                {
                    StreetAddress2Enabled = true,
                    StreetAddress2Required = true
                });
            model.Address2 = null;
            validator.ShouldHaveValidationErrorFor(x => x.Address2, model);
            model.Address2 = "";
            validator.ShouldHaveValidationErrorFor(x => x.Address2, model);

            //not required
            validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings
                {
                    StreetAddress2Enabled = true,
                    StreetAddress2Required = false
                });
            model.Address2 = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.Address2, model);
            model.Address2 = "";
            validator.ShouldNotHaveValidationErrorFor(x => x.Address2, model);
        }
        [Fact]
        public void Should_not_have_error_when_streetaddress2_is_specified()
        {
            var validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings
                {
                    StreetAddress2Enabled = true
                });

            var model = new AddressModel
            {
                Address2 = "Street address 2"
            };
            validator.ShouldNotHaveValidationErrorFor(x => x.Address2, model);
        }

        [Fact]
        public void Should_have_error_when_zippostalcode_is_null_or_empty_based_on_required_setting()
        {
            var model = new AddressModel();

            //required
            var validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings
                {
                    ZipPostalCodeEnabled = true,
                    ZipPostalCodeRequired = true
                });
            model.ZipPostalCode = null;
            validator.ShouldHaveValidationErrorFor(x => x.ZipPostalCode, model);
            model.ZipPostalCode = "";
            validator.ShouldHaveValidationErrorFor(x => x.ZipPostalCode, model);


            //not required
            validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings
                {
                    ZipPostalCodeEnabled = true,
                    ZipPostalCodeRequired = false
                });
            model.ZipPostalCode = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.ZipPostalCode, model);
            model.ZipPostalCode = "";
            validator.ShouldNotHaveValidationErrorFor(x => x.ZipPostalCode, model);
        }
        [Fact]
        public void Should_not_have_error_when_zippostalcode_is_specified()
        {
            var validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings
                {
                    StreetAddress2Enabled = true
                });

            var model = new AddressModel
            {
                ZipPostalCode = "zip"
            };
            validator.ShouldNotHaveValidationErrorFor(x => x.ZipPostalCode, model);
        }

        [Fact]
        public void Should_have_error_when_city_is_null_or_empty_based_on_required_setting()
        {
            var model = new AddressModel();

            //required
            var validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings
                {
                    CityEnabled = true,
                    CityRequired = true
                });
            model.City = null;
            validator.ShouldHaveValidationErrorFor(x => x.City, model);
            model.City = "";
            validator.ShouldHaveValidationErrorFor(x => x.City, model);


            //not required
            validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings
                {
                    CityEnabled = true,
                    CityRequired = false
                });
            model.City = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.City, model);
            model.City = "";
            validator.ShouldNotHaveValidationErrorFor(x => x.City, model);
        }
        [Fact]
        public void Should_not_have_error_when_city_is_specified()
        {
            var validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings
                {
                    CityEnabled = true
                });

            var model = new AddressModel
            {
                City = "City"
            };
            validator.ShouldNotHaveValidationErrorFor(x => x.City, model);
        }

        [Fact]
        public void Should_have_error_when_phone_is_null_or_empty_based_on_required_setting()
        {
            var model = new AddressModel();

            //required
            var validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings
                {
                    PhoneEnabled = true,
                    PhoneRequired = true
                });
            model.PhoneNumber = null;
            validator.ShouldHaveValidationErrorFor(x => x.PhoneNumber, model);
            model.PhoneNumber = "";
            validator.ShouldHaveValidationErrorFor(x => x.PhoneNumber, model);

            //not required
            validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings
                {
                    PhoneEnabled = true,
                    PhoneRequired = false
                });
            model.PhoneNumber = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.PhoneNumber, model);
            model.PhoneNumber = "";
            validator.ShouldNotHaveValidationErrorFor(x => x.PhoneNumber, model);
        }
        [Fact]
        public void Should_not_have_error_when_phone_is_specified()
        {
            var validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings
                {
                    PhoneEnabled = true
                });

            var model = new AddressModel
            {
                PhoneNumber = "Phone"
            };
            validator.ShouldNotHaveValidationErrorFor(x => x.PhoneNumber, model);
        }

        [Fact]
        public void Should_have_error_when_fax_is_null_or_empty_based_on_required_setting()
        {
            var model = new AddressModel();

            //required
            var validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings
                {
                    FaxEnabled = true,
                    FaxRequired = true
                });
            model.FaxNumber = null;
            validator.ShouldHaveValidationErrorFor(x => x.FaxNumber, model);
            model.FaxNumber = "";
            validator.ShouldHaveValidationErrorFor(x => x.FaxNumber, model);


            //not required
            validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings
                {
                    FaxEnabled = true,
                    FaxRequired = false
                });
            model.FaxNumber = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.FaxNumber, model);
            model.FaxNumber = "";
            validator.ShouldNotHaveValidationErrorFor(x => x.FaxNumber, model);
        }
        [Fact]
        public void Should_not_have_error_when_fax_is_specified()
        {
            var validator = new AddressValidator(_localizationService.Object, _stateProvinceService.Object,
                new AddressSettings
                {
                    FaxEnabled = true
                });

            var model = new AddressModel
            {
                FaxNumber = "Fax"
            };
            validator.ShouldNotHaveValidationErrorFor(x => x.FaxNumber, model);
        }
    }
}
