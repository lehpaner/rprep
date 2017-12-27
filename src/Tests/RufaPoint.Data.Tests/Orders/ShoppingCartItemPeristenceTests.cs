﻿using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Orders
{

    public class ShoppingCartItemPeristenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_shoppingCartItem()
        {
            var sci = this.GetTestShoppingCartItem();
            sci.Product = this.GetTestProduct();
            sci.Customer = this.GetTestCustomer();

            var testShoppingCartItem = this.GetTestShoppingCartItem();
            testShoppingCartItem.Product = this.GetTestProduct();
            testShoppingCartItem.Customer = this.GetTestCustomer();

            var fromDb = SaveAndLoadEntity(sci);
            fromDb.ShouldNotBeNull();

            fromDb.PropertiesShouldEqual(testShoppingCartItem);

            fromDb.Customer.ShouldNotBeNull();
            fromDb.Customer.PropertiesShouldEqual(testShoppingCartItem.Customer);

            fromDb.Product.ShouldNotBeNull();
            fromDb.Product.PropertiesShouldEqual(testShoppingCartItem.Product);
        }
    }
}
