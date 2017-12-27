using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Catalog
{

    public class ProductAttributeMappingPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_productAttributeMapping()
        {
            var productAttributeMapping = this.GetTestProductAttributeMapping();

            var fromDb = SaveAndLoadEntity(this.GetTestProductAttributeMapping());
            fromDb.ShouldNotBeNull();
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(productAttributeMapping);
            fromDb.Product.ShouldNotBeNull();
            fromDb.Product.PropertiesShouldEqual(productAttributeMapping.Product);
        }
    }
}
