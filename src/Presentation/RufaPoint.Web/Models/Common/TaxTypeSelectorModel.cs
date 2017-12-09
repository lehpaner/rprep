using RufaPoint.Core.Domain.Tax;
using RufaPoint.Web.Framework.Mvc.Models;

namespace RufaPoint.Web.Models.Common
{
    public partial class TaxTypeSelectorModel : BaseNopModel
    {
        public TaxDisplayType CurrentTaxType { get; set; }
    }
}