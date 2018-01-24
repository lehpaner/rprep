using RufaPoint.Core.Data;
using RufaPoint.Core.Domain.Customers;
using System;
using Xunit;

namespace RufaPoint.Services.Tests.Customers
{

    public class CustomerExtensionTests : ServiceTest
    {
        Guid userGID = new Guid("4c976af-b09f-4f58-a3fa-0692fb4df5d8");
        private IRepository<Customer> _customerRepo;
        //public CustomerExtensionTests()
        //{
           
        //}
        //[Fact]
        //public void Get_all_customers()
        //{
        //    var cusomers= _
        //}
        //[Test]
        //public void Can_get_add_remove_giftCardCouponCodes()
        //{
        //    var customer = new Customer();
        //    customer.ApplyGiftCardCouponCode("code1");
        //    customer.ApplyGiftCardCouponCode("code2");
        //    customer.RemoveGiftCardCouponCode("code2");
        //    customer.ApplyGiftCardCouponCode("code3");

        //    var codes = customer.ParseAppliedGiftCardCouponCodes();
        //    codes.Length.ShouldEqual(2);
        //    codes[0].ShouldEqual("code1");
        //    codes[1].ShouldEqual("code3");
        //}
        //[Test]
        //public void Can_not_add_duplicate_giftCardCouponCodes()
        //{
        //    var customer = new Customer();
        //    customer.ApplyGiftCardCouponCode("code1");
        //    customer.ApplyGiftCardCouponCode("code2");
        //    customer.ApplyGiftCardCouponCode("code1");

        //    var codes = customer.ParseAppliedGiftCardCouponCodes();
        //    codes.Length.ShouldEqual(2);
        //    codes[0].ShouldEqual("code1");
        //    codes[1].ShouldEqual("code2");
        //}
    }
}
