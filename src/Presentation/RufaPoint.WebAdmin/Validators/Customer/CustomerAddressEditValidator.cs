using RufaPoint.Core.Infrastructure;
using RufaPoint.Web.Framework.Validators;
using RufaPoint.Web.Models.Customer;
using RufaPoint.Web.Validators.Common;

namespace RufaPoint.Web.Validators.Customer
{
    public partial class CustomerAddressEditValidator : BaseNopValidator<CustomerAddressEditModel>
    {
        public CustomerAddressEditValidator()
        {
            var addressValidator = (AddressValidator)EngineContext.Current.ResolveUnregistered(typeof(AddressValidator));
            RuleFor(x => x.Address).SetValidator(addressValidator);
        }
    }
}