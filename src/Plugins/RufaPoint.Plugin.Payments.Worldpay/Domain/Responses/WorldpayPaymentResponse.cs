using Newtonsoft.Json;
using RufaPoint.Plugin.Payments.Worldpay.Domain.Models;

namespace RufaPoint.Plugin.Payments.Worldpay.Domain.Responses
{
    /// <summary>
    /// Represents return values of payment Worldpay requests
    /// </summary>
    public class WorldpayPaymentResponse : WorldpayResponse
    {
        /// <summary>
        /// Gets or sets a detailed information about the transaction, including but not limited to: transaction id; authorization code; avs result code; and cvv result code.
        /// </summary>
        [JsonProperty("transaction")]
        public Transaction Transaction { get; set; }
    }
}