using RufaPoint.Tests;
using NUnit.Framework;

namespace RufaPoint.Data.Tests.Catalog
{
    [TestFixture]
    public class ProductTemplatePersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_productTemplate()
        {
            var productTemplate = this.GetTestProductTemplate();

            var fromDb = SaveAndLoadEntity(this.GetTestProductTemplate());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(productTemplate);
        }
    }
}
