using Microsoft.AspNetCore.Mvc;
using RufaPoint.Core;
using RufaPoint.Services.Common;
using RufaPoint.Web.Areas.Admin.Models.Settings;
using RufaPoint.Web.Framework.Components;

namespace RufaPoint.Web.Areas.Admin.Components
{
    public class SettingModeViewComponent : NopViewComponent
    {
        private readonly IWorkContext _workContext;

        public SettingModeViewComponent(IWorkContext workContext)
        {
            this._workContext = workContext;
        }

        public IViewComponentResult Invoke(string modeName = "settings-advanced-mode")
        {
            var model = new ModeModel
            {
                ModeName = modeName,
                Enabled = _workContext.CurrentCustomer.GetAttribute<bool>(modeName)
            };

            return View(model);
        }
    }
}