using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Catalog
{

    public class PredefinedProductAttributeValuePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_predefinedProductAttributeValue()
        {
            var pav = this.GetTestPredefinedProductAttributeValue();

            var fromDb = SaveAndLoadEntity(this.GetTestPredefinedProductAttributeValue());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(pav);
        }        
    }
}
