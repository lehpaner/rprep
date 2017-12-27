using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Catalog
{

    public class ManufacturerPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_manufacturer()
        {
            var manufacturer = this.GetTestManufacturer();

            var fromDb = SaveAndLoadEntity(this.GetTestManufacturer());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(manufacturer);
        }        
    }
}
