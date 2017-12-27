using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Catalog
{

    public class ProductAttributeValuePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_productAttributeValue()
        {
            var pav = this.GetTestProductAttributeValue();

            var fromDb = SaveAndLoadEntity(this.GetTestProductAttributeValue());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(pav);

            fromDb.ProductAttributeMapping.ShouldNotBeNull();
            fromDb.ProductAttributeMapping.PropertiesShouldEqual(pav.ProductAttributeMapping);
        }        
    }
}
