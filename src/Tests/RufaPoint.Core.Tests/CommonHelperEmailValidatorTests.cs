﻿using System;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Core.Tests
{

    public class CommonHelperEmailValidatorTests
    {
        [Fact]
        public void When_the_text_is_a_valid_email_address_then_the_validator_should_pass()
        {
            var email = "testperson@gmail.com";
            var result = CommonHelper.IsValidEmail(email);
            result.ShouldEqual(true);
        }

        [Fact]
        public void When_the_text_is_a_valid_email_address_including_plus_validator_should_pass()
        {
            var email = "testperson+label@gmail.com";
            var result = CommonHelper.IsValidEmail(email);
            result.ShouldEqual(true);
        }

        [Fact]
        public void When_the_text_is_null_then_the_validator_should_fail()
        {
            string email = null;
            var result = CommonHelper.IsValidEmail(email);
            result.ShouldEqual(false);
        }

        [Fact]
        public void When_the_text_is_empty_then_the_validator_should_fail()
        {
            var email = string.Empty;
            var result = CommonHelper.IsValidEmail(email);
            result.ShouldEqual(false);
        }

        [Fact]
        public void When_the_text_is_not_a_valid_email_address_then_the_validator_should_fail()
        {
            var email = "testperso";
            var result = CommonHelper.IsValidEmail(email);
            result.ShouldEqual(false);
        }


        [Fact]
        public void This_should_not_hang()
        {
            var email = "thisisaverylongstringcodeplex.com";
            var result = CommonHelper.IsValidEmail(email);
            result.ShouldEqual(false);
        }

        [Fact]
        public void When_email_address_contains_upper_cases_then_the_validator_should_pass()
        {
            var email = "testperson@gmail.com";
            var result = CommonHelper.IsValidEmail(email);
            result.ShouldEqual(true);

            email = "TestPerson@gmail.com";
            result = CommonHelper.IsValidEmail(email);
            result.ShouldEqual(true);
        }
    }
}
