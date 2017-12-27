using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Catalog
{
    public class ManufacturerTemplatePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_manufacturerTemplate()
        {
            var manufacturerTemplate = this.GetTestManufacturerTemplate();

            var fromDb = SaveAndLoadEntity(this.GetTestManufacturerTemplate());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(manufacturerTemplate);
        }        
    }
}
