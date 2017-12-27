using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Shipping
{

    public class ProductAvailabilityRangePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_productAvailabilityRange()
        {
            var productAvailabilityRange = this.GetTestProductAvailabilityRange();

            var fromDb = SaveAndLoadEntity(this.GetTestProductAvailabilityRange());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(productAvailabilityRange);
        }
    }
}