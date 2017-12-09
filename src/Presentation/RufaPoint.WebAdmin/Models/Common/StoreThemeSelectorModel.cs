using System.Collections.Generic;
using RufaPoint.Web.Framework.Mvc.Models;

namespace RufaPoint.Web.Models.Common
{
    public partial class StoreThemeSelectorModel : BaseNopModel
    {
        public StoreThemeSelectorModel()
        {
            AvailableStoreThemes = new List<StoreThemeModel>();
        }

        public IList<StoreThemeModel> AvailableStoreThemes { get; set; }

        public StoreThemeModel CurrentStoreTheme { get; set; }
    }
}