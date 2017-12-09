using FluentValidation.Attributes;
using Microsoft.AspNetCore.Http;
using RufaPoint.Web.Framework.Mvc.Models;
using RufaPoint.Web.Models.Common;
using RufaPoint.Web.Validators.Customer;

namespace RufaPoint.Web.Models.Customer
{
    [Validator(typeof(CustomerAddressEditValidator))]
    public partial class CustomerAddressEditModel : BaseNopModel
    {
        public CustomerAddressEditModel()
        {
            this.Address = new AddressModel();
        }

        //MVC is suppressing further validation if the IFormCollection is passed to a controller method. That's why we add to the model
        public IFormCollection Form { get; set; }

        public AddressModel Address { get; set; }
    }
}