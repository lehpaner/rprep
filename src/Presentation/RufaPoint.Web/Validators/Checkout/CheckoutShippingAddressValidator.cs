using RufaPoint.Core.Infrastructure;
using RufaPoint.Web.Framework.Validators;
using RufaPoint.Web.Models.Checkout;
using RufaPoint.Web.Validators.Common;

namespace RufaPoint.Web.Validators.Checkout
{
    public partial class CheckoutShippingAddressValidator : BaseNopValidator<CheckoutShippingAddressModel>
    {
        public CheckoutShippingAddressValidator()
        {
            var addressValidator = (AddressValidator)EngineContext.Current.ResolveUnregistered(typeof(AddressValidator));
            RuleFor(x => x.ShippingNewAddress).SetValidator(addressValidator);
        }
    }
}