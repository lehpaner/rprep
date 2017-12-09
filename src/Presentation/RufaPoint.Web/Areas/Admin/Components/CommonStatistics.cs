using Microsoft.AspNetCore.Mvc;
using RufaPoint.Core;
using RufaPoint.Core.Domain.Customers;
using RufaPoint.Core.Domain.Orders;
using RufaPoint.Services.Catalog;
using RufaPoint.Services.Customers;
using RufaPoint.Services.Orders;
using RufaPoint.Services.Security;
using RufaPoint.Web.Areas.Admin.Models.Home;
using RufaPoint.Web.Framework.Components;

namespace RufaPoint.Web.Areas.Admin.Components
{
    public class CommonStatisticsViewComponent : NopViewComponent
    {
        private readonly IPermissionService _permissionService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly IReturnRequestService _returnRequestService;
        private readonly IWorkContext _workContext;

        public CommonStatisticsViewComponent(IPermissionService permissionService,
            IProductService productService,
            IOrderService orderService,
            ICustomerService customerService,
            IReturnRequestService returnRequestService,
            IWorkContext workContext)
        {
            this._permissionService = permissionService;
            this._productService = productService;
            this._orderService = orderService;
            this._customerService = customerService;
            this._returnRequestService = returnRequestService;
            this._workContext = workContext;
        }

        public IViewComponentResult Invoke()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageCustomers) ||
                !_permissionService.Authorize(StandardPermissionProvider.ManageOrders) ||
                !_permissionService.Authorize(StandardPermissionProvider.ManageReturnRequests) ||
                !_permissionService.Authorize(StandardPermissionProvider.ManageProducts))
                return Content("");

            //a vendor doesn't have access to this report
            if (_workContext.CurrentVendor != null)
                return Content("");

            var model = new CommonStatisticsModel
            {
                NumberOfOrders = _orderService.SearchOrders(
                pageIndex: 0,
                pageSize: 1).TotalCount,

                NumberOfCustomers = _customerService.GetAllCustomers(
                customerRoleIds: new[] { _customerService.GetCustomerRoleBySystemName(SystemCustomerRoleNames.Registered).Id },
                pageIndex: 0,
                pageSize: 1).TotalCount,

                NumberOfPendingReturnRequests = _returnRequestService.SearchReturnRequests(
                rs: ReturnRequestStatus.Pending,
                pageIndex: 0,
                pageSize: 1).TotalCount,

                NumberOfLowStockProducts = _productService.GetLowStockProducts(0, 0, 1).TotalCount +
                                             _productService.GetLowStockProductCombinations(0, 0, 1).TotalCount
            };

            return View(model);
        }
    }
}
