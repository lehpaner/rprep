using System.ComponentModel.DataAnnotations;
using RufaPoint.Web.Framework.Mvc.Models;

namespace RufaPoint.Web.Models.Newsletter
{
    public partial class NewsletterBoxModel : BaseNopModel
    {
        [DataType(DataType.EmailAddress)]
        public string NewsletterEmail { get; set; }
        public bool AllowToUnsubscribe { get; set; }
    }
}