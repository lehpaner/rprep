using Microsoft.AspNetCore.Mvc;
using RufaPoint.Web.Framework.Mvc.Filters;
using RufaPoint.Web.Framework.Security;

namespace RufaPoint.Web.Controllers
{
    public partial class HomeController : BasePublicController
    {
        [HttpsRequirement(SslRequirement.No)]
        public virtual IActionResult Index()
        {
            return View();
        }
    }
}