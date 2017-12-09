using RufaPoint.Core.Infrastructure;
using RufaPoint.Web.Framework.Validators;
using RufaPoint.Web.Models.Checkout;
using RufaPoint.Web.Validators.Common;

namespace RufaPoint.Web.Validators.Checkout
{
    public partial class CheckoutBillingAddressValidator : BaseNopValidator<CheckoutBillingAddressModel>
    {
        public CheckoutBillingAddressValidator()
        {
            var addressValidator = (AddressValidator)EngineContext.Current.ResolveUnregistered(typeof(AddressValidator));
            RuleFor(x => x.BillingNewAddress).SetValidator(addressValidator);
        }
    }
}