﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RufaPoint.Web.Factories;
using RufaPoint.Web.Framework.Components;

namespace RufaPoint.Web.Components
{
    public class HomepagePollsViewComponent : NopViewComponent
    {
        private readonly IPollModelFactory _pollModelFactory;

        public HomepagePollsViewComponent(IPollModelFactory pollModelFactory)
        {
            this._pollModelFactory = pollModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _pollModelFactory.PrepareHomePagePollModels();
            if (!model.Any())
                Content("");

            return View(model);
        }
    }
}
