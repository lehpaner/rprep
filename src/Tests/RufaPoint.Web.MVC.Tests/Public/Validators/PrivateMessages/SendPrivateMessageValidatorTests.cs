using FluentValidation.TestHelper;
using RufaPoint.Web.Models.PrivateMessages;
using RufaPoint.Web.Validators.PrivateMessages;
using Xunit;

namespace RufaPoint.Web.MVC.Tests.Public.Validators.PrivateMessages
{

    public class SendPrivateMessageValidatorTests : BaseValidatorTests
    {
        private SendPrivateMessageValidator _validator;
        
        public SendPrivateMessageValidatorTests()
        {
            _validator = new SendPrivateMessageValidator(_localizationService.Object);
        }

        [Fact]
        public void Should_have_error_when_subject_is_null_or_empty()
        {
            var model = new SendPrivateMessageModel
            {
                Subject = null
            };
            _validator.ShouldHaveValidationErrorFor(x => x.Subject, model);
            model.Subject = "";
            _validator.ShouldHaveValidationErrorFor(x => x.Subject, model);
        }

        [Fact]
        public void Should_not_have_error_when_subject_is_specified()
        {
            var model = new SendPrivateMessageModel
            {
                Subject = "some comment"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Subject, model);
        }

        [Fact]
        public void Should_have_error_when_message_is_null_or_empty()
        {
            var model = new SendPrivateMessageModel
            {
                Message = null
            };
            _validator.ShouldHaveValidationErrorFor(x => x.Message, model);
            model.Message = "";
            _validator.ShouldHaveValidationErrorFor(x => x.Message, model);
        }

        [Fact]
        public void Should_not_have_error_when_message_is_specified()
        {
            var model = new SendPrivateMessageModel
            {
                Message = "some comment"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Message, model);
        }
    }
}
