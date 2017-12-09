using Microsoft.AspNetCore.Mvc;
using RufaPoint.Web.Framework.Controllers;
using RufaPoint.Web.Framework.Mvc.Filters;
using RufaPoint.Web.Framework.Security;

namespace RufaPoint.Web.Controllers
{
    [HttpsRequirement(SslRequirement.NoMatter)]
    [WwwRequirement]
    [CheckAccessPublicStore]
    [CheckAccessClosedStore]
    [CheckLanguageSeoCode]
    [CheckAffiliate]
    public abstract partial class BasePublicController : BaseController
    {
        protected virtual IActionResult InvokeHttp404()
        {
            Response.StatusCode = 404;
            return new EmptyResult();
        }
    }
}