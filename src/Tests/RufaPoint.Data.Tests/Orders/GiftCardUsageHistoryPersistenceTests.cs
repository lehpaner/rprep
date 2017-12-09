using RufaPoint.Tests;
using NUnit.Framework;

namespace RufaPoint.Data.Tests.Orders
{
    [TestFixture]
    public class GiftCardUsageHistoryPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_giftCardUsageHistory()
        {
            var gcuh = this.GetTestGiftCardUsageHistory();
            gcuh.GiftCard = this.GetTestGiftCard();
            gcuh.UsedWithOrder = this.GetTestOrder();
            gcuh.UsedWithOrder.Customer = this.GetTestCustomer();
            var fromDb = SaveAndLoadEntity(gcuh);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestGiftCardUsageHistory());

            fromDb.GiftCard.ShouldNotBeNull();
            fromDb.UsedWithOrder.ShouldNotBeNull();
            fromDb.UsedWithOrder.PropertiesShouldEqual(this.GetTestOrder());
        }
    }
}