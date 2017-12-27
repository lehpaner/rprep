using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Catalog
{

    public class ProductTemplatePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_productTemplate()
        {
            var productTemplate = this.GetTestProductTemplate();

            var fromDb = SaveAndLoadEntity(this.GetTestProductTemplate());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(productTemplate);
        }
    }
}
