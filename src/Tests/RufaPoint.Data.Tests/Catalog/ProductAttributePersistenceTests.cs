using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Catalog
{

    public class ProductAttributePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_productAttribute()
        {
            var pa = this.GetTestProductAttribute();

            var fromDb = SaveAndLoadEntity(this.GetTestProductAttribute());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(pa);
        }       
    }
}