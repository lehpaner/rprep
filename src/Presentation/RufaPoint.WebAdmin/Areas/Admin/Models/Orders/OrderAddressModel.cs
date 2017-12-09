using FluentValidation.Attributes;
using Microsoft.AspNetCore.Http;
using RufaPoint.Web.Areas.Admin.Models.Common;
using RufaPoint.Web.Areas.Admin.Validators.Orders;
using RufaPoint.Web.Framework.Mvc.Models;

namespace RufaPoint.Web.Areas.Admin.Models.Orders
{
    [Validator(typeof(OrderAddressValidator))]
    public partial class OrderAddressModel : BaseNopModel
    {
        //MVC is suppressing further validation if the IFormCollection is passed to a controller method. That's why we add to the model
        public IFormCollection Form { get; set; }

        public int OrderId { get; set; }

        public AddressModel Address { get; set; }
    }
}