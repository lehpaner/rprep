using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Shipping
{

    public class DeliveryDatePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_deliveryDate()
        {
            var deliveryDate = this.GetTestDeliveryDate();

            var fromDb = SaveAndLoadEntity(this.GetTestDeliveryDate());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(deliveryDate);
        }
    }
}