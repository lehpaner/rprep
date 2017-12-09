﻿using RufaPoint.Tests;
using NUnit.Framework;

namespace RufaPoint.Data.Tests.Orders
{
    [TestFixture]
    public class CheckoutAttributeValuePersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_checkoutAttributeValue()
        {
            var cav = this.GetTestCheckoutAttributeValue();
            cav.CheckoutAttribute = this.GetTestCheckoutAttribute();

            var fromDb = SaveAndLoadEntity(cav);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestCheckoutAttributeValue());

            fromDb.CheckoutAttribute.ShouldNotBeNull();
            fromDb.CheckoutAttribute.PropertiesShouldEqual(this.GetTestCheckoutAttribute());
        }
    }
}