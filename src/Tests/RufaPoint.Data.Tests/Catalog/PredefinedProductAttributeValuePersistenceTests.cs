using RufaPoint.Tests;
using NUnit.Framework;

namespace RufaPoint.Data.Tests.Catalog
{
    [TestFixture]
    public class PredefinedProductAttributeValuePersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_predefinedProductAttributeValue()
        {
            var pav = this.GetTestPredefinedProductAttributeValue();

            var fromDb = SaveAndLoadEntity(this.GetTestPredefinedProductAttributeValue());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(pav);
        }        
    }
}
