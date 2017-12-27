using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Catalog
{

    public class ProductAttributeCombinationPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_productAttributeCombination()
        {
            var combination = this.GetTestProductAttributeCombination();

            var fromDb = SaveAndLoadEntity(this.GetTestProductAttributeCombination());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(combination);
            fromDb.Product.ShouldNotBeNull();
            fromDb.Product.PropertiesShouldEqual(combination.Product);
        }        
    }
}