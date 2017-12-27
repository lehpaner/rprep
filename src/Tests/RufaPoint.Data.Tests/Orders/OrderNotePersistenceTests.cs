using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Orders
{

    public class OrderNotePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_orderNote()
        {
            var on = this.GetTestOrderNote();
            on.Order = this.GetTestOrder();
            on.Order.Customer = this.GetTestCustomer();
            var fromDb = SaveAndLoadEntity(on);
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(this.GetTestOrderNote());

            fromDb.Order.ShouldNotBeNull();
            fromDb.Order.PropertiesShouldEqual(this.GetTestOrder());
        }
    }
}