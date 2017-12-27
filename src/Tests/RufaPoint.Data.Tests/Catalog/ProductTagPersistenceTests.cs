using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Catalog
{

    public class ProductTagPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_productTag()
        {
            var productTag = this.GetTestProductTag();

            var fromDb = SaveAndLoadEntity(this.GetTestProductTag());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(productTag);
        }
    }
}