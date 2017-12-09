using RufaPoint.Web.Framework.Mvc.Models;

namespace RufaPoint.Web.Models.Common
{
    public partial class LogoModel : BaseNopModel
    {
        public string StoreName { get; set; }

        public string LogoPath { get; set; }
    }
}