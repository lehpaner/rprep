﻿using System;
using Microsoft.AspNetCore.Mvc;
using RufaPoint.Services.Customers;
using RufaPoint.Web.Factories;
using RufaPoint.Web.Framework.Components;

namespace RufaPoint.Web.Components
{
    public class ProfileInfoViewComponent : NopViewComponent
    {
        private readonly ICustomerService _customerService;
        private readonly IProfileModelFactory _profileModelFactory;

        public ProfileInfoViewComponent(ICustomerService customerService, IProfileModelFactory profileModelFactory)
        {
            this._customerService = customerService;
            this._profileModelFactory = profileModelFactory;
        }

        public IViewComponentResult Invoke(int customerProfileId)
        {
            var customer = _customerService.GetCustomerById(customerProfileId);
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            var model = _profileModelFactory.PrepareProfileInfoModel(customer);
            return View(model);
        }
    }
}
