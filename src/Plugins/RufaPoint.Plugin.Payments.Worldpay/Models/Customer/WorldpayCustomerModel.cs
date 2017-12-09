using RufaPoint.Web.Framework.Mvc.ModelBinding;
using RufaPoint.Web.Framework.Mvc.Models;

namespace RufaPoint.Plugin.Payments.Worldpay.Models.Customer
{
    public class WorldpayCustomerModel : BaseNopEntityModel
    {
        [NopResourceDisplayName("Plugins.Payments.Worldpay.Fields.WorldpayCustomerId")]
        public string WorldpayCustomerId { get; set; }

        public bool CustomerExists { get; set; }
    }
}