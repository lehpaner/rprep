using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Catalog
{
    public class CategoryTemplatePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_categoryTemplate()
        {
            var categoryTemplate = this.GetTestCategoryTemplate();

            var fromDb = SaveAndLoadEntity(this.GetTestCategoryTemplate());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(categoryTemplate);
        }        
    }
}
