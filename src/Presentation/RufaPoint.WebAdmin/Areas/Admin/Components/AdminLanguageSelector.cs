using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RufaPoint.Core;
using RufaPoint.Services.Localization;
using RufaPoint.Web.Areas.Admin.Extensions;
using RufaPoint.Web.Areas.Admin.Models.Common;
using RufaPoint.Web.Framework.Components;

namespace RufaPoint.Web.Areas.Admin.Components
{
    public class AdminLanguageSelectorViewComponent : NopViewComponent
    {
        private readonly ILanguageService _languageService;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;

        public AdminLanguageSelectorViewComponent(ILanguageService languageService,
            IStoreContext storeContext,
            IWorkContext workContext)
        {
            this._languageService = languageService;
            this._storeContext = storeContext;
            this._workContext = workContext;
        }

        public IViewComponentResult Invoke()
        {
            var model = new LanguageSelectorModel
            {
                CurrentLanguage = _workContext.WorkingLanguage.ToModel(),
                AvailableLanguages = _languageService
                .GetAllLanguages(storeId: _storeContext.CurrentStore.Id)
                .Select(x => x.ToModel())
                .ToList()
            };

            return View(model);
        }
    }
}
