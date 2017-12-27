using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Shipping
{

    public class WarehousePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_warehouse()
        {
            var warehouse = this.GetTestWarehouse();

            var fromDb = SaveAndLoadEntity(this.GetTestWarehouse());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(warehouse);
        }
    }
}