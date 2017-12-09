﻿using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RufaPoint.Core;
using RufaPoint.Core.Data;
using RufaPoint.Core.Domain.Customers;
using RufaPoint.Services.Common;

namespace RufaPoint.Web.Framework.Mvc.Filters
{
    /// <summary>
    /// Represents filter attribute that saves last visited page by customer
    /// </summary>
    public class SaveLastVisitedPageAttribute : TypeFilterAttribute
    {
        #region Ctor

        /// <summary>
        /// Create instance of the filter attribute
        /// </summary>
        public SaveLastVisitedPageAttribute() : base(typeof(SaveLastVisitedPageFilter))
        {
        }

        #endregion

        #region Nested filter

        /// <summary>
        /// Represents a filter that saves last visited page by customer
        /// </summary>
        private class SaveLastVisitedPageFilter : IActionFilter
        {
            #region Fields

            private readonly CustomerSettings _customerSettings;
            private readonly IGenericAttributeService _genericAttributeService;
            private readonly IWebHelper _webHelper;
            private readonly IWorkContext _workContext;

            #endregion

            #region Ctor

            public SaveLastVisitedPageFilter(CustomerSettings customerSettings,
                IGenericAttributeService genericAttributeService,
                IWebHelper webHelper, 
                IWorkContext workContext)
            {
                this._customerSettings = customerSettings;
                this._genericAttributeService = genericAttributeService;
                this._webHelper = webHelper;
                this._workContext = workContext;
            }

            #endregion

            #region Methods

            /// <summary>
            /// Called before the action executes, after model binding is complete
            /// </summary>
            /// <param name="context">A context for action filters</param>
            public void OnActionExecuting(ActionExecutingContext context)
            {
                if (context == null)
                    throw new ArgumentNullException(nameof(context));

                if (context.HttpContext.Request == null)
                    return;

                //only in GET requests
                if (!context.HttpContext.Request.Method.Equals(WebRequestMethods.Http.Get, StringComparison.InvariantCultureIgnoreCase))
                    return;

                if (!DataSettingsHelper.DatabaseIsInstalled())
                    return;

                //check whether we store last visited page URL
                if (!_customerSettings.StoreLastVisitedPage)
                    return;

                //get current page
                var pageUrl = _webHelper.GetThisPageUrl(true);
                if (string.IsNullOrEmpty(pageUrl))
                    return;
                
                //get previous last page
                var previousPageUrl = _workContext.CurrentCustomer.GetAttribute<string>(SystemCustomerAttributeNames.LastVisitedPage);

                //save new one if don't match
                if (!pageUrl.Equals(previousPageUrl, StringComparison.InvariantCultureIgnoreCase))
                    _genericAttributeService.SaveAttribute(_workContext.CurrentCustomer, SystemCustomerAttributeNames.LastVisitedPage, pageUrl);
                
            }

            /// <summary>
            /// Called after the action executes, before the action result
            /// </summary>
            /// <param name="context">A context for action filters</param>
            public void OnActionExecuted(ActionExecutedContext context)
            {
                //do nothing
            }

            #endregion
        }

        #endregion
    }
}