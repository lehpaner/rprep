using System.Linq;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Orders
{

    public class GiftCardPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_giftCard()
        {
            var giftCard = this.GetTestGiftCard();

            var fromDb = SaveAndLoadEntity(this.GetTestGiftCard());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(giftCard);
        }

        [Fact]
        public void Can_save_and_load_giftCard_with_usageHistory()
        {
            var giftCard = this.GetTestGiftCard();
            var gcuh = this.GetTestGiftCardUsageHistory();
            gcuh.UsedWithOrder = this.GetTestOrder();
            gcuh.UsedWithOrder.Customer = this.GetTestCustomer();
            gcuh.GiftCard = null;
            giftCard.GiftCardUsageHistory.Add(gcuh);
            var fromDb = SaveAndLoadEntity(giftCard);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestGiftCard());

            fromDb.GiftCardUsageHistory.ShouldNotBeNull();
            (fromDb.GiftCardUsageHistory.Count == 1).ShouldBeTrue();
            fromDb.GiftCardUsageHistory.First().PropertiesShouldEqual(this.GetTestGiftCardUsageHistory());
        }
        
        [Fact]
        public void Can_save_and_load_giftCard_with_associatedItem()
        {
            var giftCard = this.GetTestGiftCard();
            giftCard.PurchasedWithOrderItem = this.GetTestOrderItem();
            giftCard.PurchasedWithOrderItem.Order = this.GetTestOrder();
            giftCard.PurchasedWithOrderItem.Order.Customer = this.GetTestCustomer();
            var fromDb = SaveAndLoadEntity(giftCard);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestGiftCard());

            fromDb.PurchasedWithOrderItem.ShouldNotBeNull();
            fromDb.PurchasedWithOrderItem.Product.ShouldNotBeNull();
            fromDb.PurchasedWithOrderItem.Product.PropertiesShouldEqual(this.GetTestProduct());
        }
    }
}