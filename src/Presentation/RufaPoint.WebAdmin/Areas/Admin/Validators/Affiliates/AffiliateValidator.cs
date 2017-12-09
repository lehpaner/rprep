using RufaPoint.Core.Infrastructure;
using RufaPoint.Web.Areas.Admin.Models.Affiliates;
using RufaPoint.Web.Areas.Admin.Validators.Common;
using RufaPoint.Web.Framework.Validators;

namespace RufaPoint.Web.Areas.Admin.Validators.Affiliates
{
    public partial class AffiliateValidator : BaseNopValidator<AffiliateModel>
    {
        public AffiliateValidator()
        {
            var addressValidator = (AddressValidator) EngineContext.Current.ResolveUnregistered(typeof(AddressValidator));
            RuleFor(x => x.Address).SetValidator(addressValidator);
        }
    }
}