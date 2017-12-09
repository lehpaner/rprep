using RufaPoint.Core.Infrastructure;
using RufaPoint.Web.Areas.Admin.Models.Orders;
using RufaPoint.Web.Areas.Admin.Validators.Common;
using RufaPoint.Web.Framework.Validators;

namespace RufaPoint.Web.Areas.Admin.Validators.Orders
{
    public partial class OrderAddressValidator : BaseNopValidator<OrderAddressModel>
    {
        public OrderAddressValidator()
        {
            var addressValidator = (AddressValidator) EngineContext.Current.ResolveUnregistered(typeof(AddressValidator));
            RuleFor(x => x.Address).SetValidator(addressValidator);
        }
    }
}