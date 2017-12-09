using RufaPoint.Web.Framework.Mvc.Models;

namespace RufaPoint.Plugin.Payments.Worldpay.Models.Customer
{
    public class WorldpayCardModel : BaseNopModel
    {
        public string Id { get; set; }

        public string CardId { get; set; }
        
        public string MaskedNumber { get; set; }

        public string ExpirationDate { get; set; }
        
        public string CardType { get; set; }
    }
}