using System.Collections.Generic;
using RufaPoint.Web.Framework.Mvc.Models;
using RufaPoint.Web.Models.Common;

namespace RufaPoint.Web.Models.Customer
{
    public partial class CustomerAddressListModel : BaseNopModel
    {
        public CustomerAddressListModel()
        {
            Addresses = new List<AddressModel>();
        }

        public IList<AddressModel> Addresses { get; set; }
    }
}