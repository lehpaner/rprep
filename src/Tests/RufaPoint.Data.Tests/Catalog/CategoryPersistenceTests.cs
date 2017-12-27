using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Catalog
{

    public class CategoryPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_category()
        {
            var category = this.GetTestCategory();

            var fromDb = SaveAndLoadEntity(this.GetTestCategory());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(category);
        }        
    }
}