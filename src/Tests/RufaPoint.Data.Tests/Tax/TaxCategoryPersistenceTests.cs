using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Tax
{

    public class TaxCategoryPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_taxCategory()
        {
            var taxCategory = this.GetTestTaxCategory();

            var fromDb = SaveAndLoadEntity(this.GetTestTaxCategory());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(taxCategory);
        }
    }
}