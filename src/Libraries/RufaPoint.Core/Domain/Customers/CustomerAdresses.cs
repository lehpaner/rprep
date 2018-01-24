using RufaPoint.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RufaPoint.Core.Domain.Customers
{
    public class CustomerAdresses:BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int Address_Id { get; set; }
        public Address Address { get; set; }
    } 
}
