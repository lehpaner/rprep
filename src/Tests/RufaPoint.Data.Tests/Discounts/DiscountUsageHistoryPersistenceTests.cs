using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Discounts
{
    public class DiscountUsageHistoryPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_discountUsageHistory()
        {
            var discount = this.GetTestDiscountUsageHistory();
         
            var fromDb = SaveAndLoadEntity(this.GetTestDiscountUsageHistory());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(discount);

            fromDb.Discount.ShouldNotBeNull();
            fromDb.Order.ShouldNotBeNull();
            fromDb.Order.PropertiesShouldEqual(discount.Order);
        }
    }
}