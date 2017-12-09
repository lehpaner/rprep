using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;
using RufaPoint.Core.Domain.Customers;
using RufaPoint.Core.Domain.Payments;
using RufaPoint.Plugin.Payments.Worldpay.Models.Customer;
using RufaPoint.Services.Common;
using RufaPoint.Services.Customers;
using RufaPoint.Services.Events;
using RufaPoint.Services.Localization;
using RufaPoint.Services.Payments;
using RufaPoint.Web.Areas.Admin.Models.Customers;
using RufaPoint.Web.Framework.Events;
using RufaPoint.Web.Framework.Extensions;
using RufaPoint.Web.Framework.UI;

namespace RufaPoint.Plugin.Payments.Worldpay.Services
{
    /// <summary>
    /// Represents event consumer of the Worldpay payment plugin
    /// </summary>
    public class EventConsumer : 
        IConsumer<PageRenderingEvent>, 
        IConsumer<AdminTabStripCreated>
    {
        #region Fields

        private readonly ICustomerService _customerService;
        private readonly ILocalizationService _localizationService;
        private readonly IPaymentService _paymentService;
        private readonly PaymentSettings _paymentSettings;
        private readonly WorldpayPaymentManager _worldpayPaymentManager;

        #endregion

        #region Ctor

        public EventConsumer(ICustomerService customerService,
            ILocalizationService localizationService,
            IPaymentService paymentService,
            PaymentSettings paymentSettings,
            WorldpayPaymentManager worldpayPaymentManager)
        {
            this._customerService = customerService;
            this._localizationService = localizationService;
            this._paymentService = paymentService;
            this._paymentSettings = paymentSettings;
            this._worldpayPaymentManager = worldpayPaymentManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handle page rendering event
        /// </summary>
        /// <param name="eventMessage">Event message</param>
        public void HandleEvent(PageRenderingEvent eventMessage)
        {
            if (eventMessage?.Helper?.ViewContext?.ActionDescriptor == null)
                return;

            //check whether the payment plugin is installed and is active
            var worldpayPaymentMethod = _paymentService.LoadPaymentMethodBySystemName(WorldpayPaymentDefaults.SystemName);
            if (!(worldpayPaymentMethod?.PluginDescriptor?.Installed ?? false) || !worldpayPaymentMethod.IsPaymentMethodActive(_paymentSettings))
                return;

            //add js sсript to one page checkout
            if (eventMessage.Helper.ViewContext.ActionDescriptor is ControllerActionDescriptor actionDescriptor &&
                actionDescriptor.ControllerName == "Checkout" && actionDescriptor.ActionName == "OnePageCheckout")
            {
                eventMessage.Helper.AddScriptParts(ResourceLocation.Footer, "https://gwapi.demo.securenet.com/v1/PayOS.js");
            }
        }

        /// <summary>
        /// Handle admin tabstrip created event
        /// </summary>
        /// <param name="eventMessage">Event message</param>
        public void HandleEvent(AdminTabStripCreated eventMessage)
        {
            if (eventMessage?.Helper == null)
                return;

            //we need customer details page
            var tabsElementId = "customer-edit"; 
            if (!eventMessage.TabStripName.Equals(tabsElementId))
                return;

            //check whether the payment plugin is installed and is active
            var worldpayPaymentMethod = _paymentService.LoadPaymentMethodBySystemName(WorldpayPaymentDefaults.SystemName);
            if (!(worldpayPaymentMethod?.PluginDescriptor?.Installed ?? false) || !worldpayPaymentMethod.IsPaymentMethodActive(_paymentSettings))
                return;

            //get the view model
            if (!(eventMessage.Helper.ViewData.Model is CustomerModel customerModel))
                return;

            //check whether a customer exists and isn't guest
            var customer = _customerService.GetCustomerById(customerModel.Id);
            if (customer == null || customer.IsGuest())
                return;

            //try to get stored in Vault customer
            var vaultCustomer = _worldpayPaymentManager.GetCustomer(customer.GetAttribute<string>(WorldpayPaymentDefaults.CustomerIdAttribute));

            //prepare model
            var model = new WorldpayCustomerModel
            {
                Id = customerModel.Id,
                CustomerExists = vaultCustomer != null,
                WorldpayCustomerId = vaultCustomer?.CustomerId
            };

            //compose script to create a new tab
            var worldpayCustomerTabElementId = "tab-worldpay";
            var worldpayCustomerTab = new HtmlString($@"
                <script type='text/javascript'>
                    $(document).ready(function() {{
                        $(`
                            <li>
                                <a data-tab-name='{worldpayCustomerTabElementId}' data-toggle='tab' href='#{worldpayCustomerTabElementId}'>
                                    {_localizationService.GetResource("Plugins.Payments.Worldpay.WorldpayCustomer")}
                                </a>
                            </li>
                        `).appendTo('#{tabsElementId} .nav-tabs:first');
                        $(`
                            <div class='tab-pane' id='{worldpayCustomerTabElementId}'>
                                {
                                    eventMessage.Helper.Partial("~/Plugins/Payments.Worldpay/Views/Customer/_CreateOrUpdate.Worldpay.cshtml", model).RenderHtmlContent()
                                        .Replace("</script>", "<\\/script>") //we need escape a closing script tag to prevent terminating the script block early
                                }
                            </div>
                        `).appendTo('#{tabsElementId} .tab-content:first');
                    }});
                </script>");

            //add this tab as a block to render on the customer details page
            eventMessage.BlocksToRender.Add(worldpayCustomerTab);
        }

        #endregion
    }
}