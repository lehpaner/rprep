using System.Linq;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Orders
{

    public class OrderItemPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_orderItem()
        {
            var orderItem = this.GetTestOrderItem();
            orderItem.Order = this.GetTestOrder();
            orderItem.Order.Customer = this.GetTestCustomer();
            var fromDb = SaveAndLoadEntity(orderItem);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestOrderItem());

            fromDb.Order.ShouldNotBeNull();
            fromDb.Order.PropertiesShouldEqual(this.GetTestOrder());
        }

        [Fact]
        public void Can_save_and_load_orderItem_with_giftCard()
        {
            var orderItem = this.GetTestOrderItem();
            orderItem.Order = this.GetTestOrder();
            orderItem.Order.Customer = this.GetTestCustomer();
            orderItem.AssociatedGiftCards.Add(this.GetTestGiftCard());

            var fromDb = SaveAndLoadEntity(orderItem);
            fromDb.ShouldNotBeNull();

            fromDb.AssociatedGiftCards.ShouldNotBeNull();
            (fromDb.AssociatedGiftCards.Count == 1).ShouldBeTrue();
            fromDb.AssociatedGiftCards.First().PropertiesShouldEqual(this.GetTestGiftCard());
        }
    }
}