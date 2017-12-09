using RufaPoint.Tests;
using NUnit.Framework;

namespace RufaPoint.Data.Tests.Catalog
{
    [TestFixture]
    public class CategoryTemplatePersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_categoryTemplate()
        {
            var categoryTemplate = this.GetTestCategoryTemplate();

            var fromDb = SaveAndLoadEntity(this.GetTestCategoryTemplate());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(categoryTemplate);
        }        
    }
}
