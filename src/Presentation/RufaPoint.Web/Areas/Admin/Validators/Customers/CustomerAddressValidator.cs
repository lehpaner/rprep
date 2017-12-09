using RufaPoint.Core.Infrastructure;
using RufaPoint.Web.Areas.Admin.Models.Customers;
using RufaPoint.Web.Areas.Admin.Validators.Common;
using RufaPoint.Web.Framework.Validators;

namespace RufaPoint.Web.Areas.Admin.Validators.Customers
{
    public partial class CustomerAddressValidator : BaseNopValidator<CustomerAddressModel>
    {
        public CustomerAddressValidator()
        {
            var addressValidator = (AddressValidator) EngineContext.Current.ResolveUnregistered(typeof(AddressValidator));
            RuleFor(x => x.Address).SetValidator(addressValidator);
        }
    }
}